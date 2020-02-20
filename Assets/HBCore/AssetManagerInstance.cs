using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Linq;
using CielaSpike;
using System.Linq;


namespace HBWorld { 
    public class AssetManagerInstance : MonoBehaviour {

        public GameObject curInstantiateGameObjectRoot = null;
        public Task curInstantiateTask;
        public string curQueID = "";
        public Dictionary<string, QueData> que = new Dictionary<string, QueData>();
        private Task runQueue;
        void Awake() {
            AssetManager.instance = this;
            //load serializer extensions ( is basically init )
            HBS.Serializer.LoadExtensions();

            this.StartCoroutineAsync(RunQue(), out runQueue);
        }
        void OnDestroy() {
            AssetManager.instance = null;
        }
        private void Update() {
            if (runQueue != null) {
                if(runQueue.Exception != null) {
                    Debug.LogErrorFormat("[AssetManagerInstance] ERROR: {0}", runQueue.Exception);
                    this.StartCoroutineAsync(RunQue(), out runQueue);
                }
            }
        }
        //can only pop one async asset at a time so this is the que systeù
        IEnumerator RunQue() {
            yield return Ninja.JumpToUnity;
            while (true) {
                if (que.Count() == 0) { yield return new WaitForEndOfFrame(); continue; }
                curQueID = que.Keys.First();
                QueData q = que.ContainsKey(curQueID) ? que[curQueID] : null;
                if (q == null) { yield return new WaitForEndOfFrame(); continue; }
                yield return this.StartCoroutineAsync(InstantiateAssetAsync(que[curQueID].assetPath, que[curQueID].onReturn), out curInstantiateTask);
                if (que.ContainsKey(curQueID)) { que.Remove(curQueID); }
                yield return new WaitForEndOfFrame();
            }
        }

        //Instantiating Assets Async
        public string InvokeInstantiateAssetAsync(string path, System.Action<GameObject, string> onReturn) {
            string queID = IDManager.GetNewIDShort();
            que.Add(queID, new QueData(path, onReturn));
            return queID;
        }
        public void CancelInstantiateAssetAsync(string id) {
            if (que.ContainsKey(id)) {
                que.Remove(id);
            }
            if (id == curQueID) {
                curInstantiateTask.Cancel();
                if (curInstantiateGameObjectRoot != null) {
                    GameObject.Destroy(curInstantiateGameObjectRoot);
                }
            }
        }
        IEnumerator InstantiateAssetAsync(string path, System.Action<GameObject, string> onReturn) {

            yield return Ninja.JumpToUnity;

            if (AssetManager.FileExists(path) == false) { onReturn(null, "cant find file at: "+path); yield break; }

            string persistentDataPath = Application.persistentDataPath;
            
            yield return Ninja.JumpBack;

            
            //create cache folder
            string c = AssetManager.CreateCacheFolder(persistentDataPath);

            //setup mesh extension to async
            HBS.MeshExtension.savePath = c;
            HBS.MeshExtension.async = true;

            //unzip to
            HBS.Serializer.UnzipFolderTo(path, c);

            yield return Ninja.JumpToUnity;

            //load gameObject
            GameObject o = null;
            yield return HBS.Serializer.LoadGameObjectAsync(c + "/data.txt",(ret)=> {
                o = ret;
            });
            //GameObject o = HBS.Serializer.LoadGameObject(c + "/data.txt");

            if( o != null ) {
                curInstantiateGameObjectRoot = o;
                //call the async load method on MeshExtension
                foreach (KeyValuePair<string, Mesh> v in HBS.MeshExtension.asyncTodo) {
                    yield return this.StartCoroutineAsync(MeshUtilities.LoadH3dOntoMeshAsync(v.Key, v.Value));
                }

                yield return Ninja.JumpBack;

                //delete cache folder
                AssetManager.DeleteCacheFolder(c);

                yield return Ninja.JumpToUnity;
                o.SetActive(true);

                //assign asset comp if not already
                Asset a = o.GetComponent<Asset>();
                if (a == null) { a = o.AddComponent<Asset>(); }
                a.path = path;

                //reset meshExtension back to normal
                //HBS.MeshExtension.cache.Clear();
                HBS.MeshExtension.asyncTodo.Clear();
                HBS.MeshExtension.async = false;

                curInstantiateGameObjectRoot = null;

                yield return Ninja.JumpToUnity;
            }
            

            //call onReturn
            onReturn(o, "succes");
            yield return Ninja.JumpBack;
        }

        //Utilities
        public class QueData {
            public string assetPath;
            public System.Action<GameObject, string> onReturn;
            public QueData(string _assetPath, System.Action<GameObject, string> _onReturn) {
                assetPath = _assetPath;
                onReturn = _onReturn;
            }
        }
    }
}