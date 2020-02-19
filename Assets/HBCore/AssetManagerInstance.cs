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
            string queID = IDManager.GetNewID();
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

            if (AssetManager.FileExists(path) == false) { onReturn(null, "cant find file at: " + path); yield break; }

            string persistentDataPath = Application.persistentDataPath;

            yield return Ninja.JumpBack;


            //create cache folder
            string c = AssetManager.CreateCacheFolder(persistentDataPath);

            //setup mesh extension to async
            HBS.MeshExtension.savePath = c;
            HBS.MeshExtension.async = true;
            HBS.RevAudioClipExtension.savePath = c;
            HBS.RevAudioClipExtension.async = true;

            //unzip to
            HBS.Serializer.UnzipFolderTo(path, c);

            yield return Ninja.JumpToUnity;

            //load gameObject
            GameObject o = HBS.Serializer.LoadGameObject(c + "/data.txt");

            if (o != null) {
                yield return this.StartCoroutineAsync(HBS.MeshExtension.RunAsync(this));
                yield return this.StartCoroutineAsync(HBS.RevAudioClipExtension.RunAsync());
              
                //yield return Ninja.JumpToUnity;
                o.SetActive(true);

                //assign asset comp if not already
                Asset a = o.GetComponent<Asset>();
                if (a == null) { a = o.AddComponent<Asset>(); }
                a.path = path;
                
            }
            
            yield return Ninja.JumpBack;

            //delete cache folder
            AssetManager.DeleteCacheFolder(c);
            
            yield return Ninja.JumpToUnity;

            //call onReturn
            onReturn(o, "succes");

            yield return Ninja.JumpBack;
        }

        IEnumerator InstantiateAssetAsyncOld(string path, System.Action<GameObject, string> onReturn) {

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
            GameObject o = HBS.Serializer.LoadGameObject(c + "/data.txt");

            if( o != null ) {
                curInstantiateGameObjectRoot = o;
                //call the async load method on MeshExtension
                foreach (KeyValuePair<string, Mesh> v in HBS.MeshExtension.asyncTodo) {
                    yield return this.StartCoroutineAsync(MeshUtilities.LoadH3dOntoMeshAsync(v.Key, v.Value));
                }

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

        [ContextMenu("Async Test Save Load ")]
        void TestSaveLoadAsync() {
            var children = transform.GetComponentsInChildren<Transform>();
            if(children != null ) {

                var path = Application.dataPath + "/asyncSerializerTest";
                if (Directory.Exists(path) == false) { Directory.CreateDirectory(path); }

                foreach ( var child in children ) {
                    if( child == transform ) { continue; }
                    var g = child.gameObject;
                    AssetManager.SaveAsset(path + "/" + g.gameObject.name + "_asynctest.hbp", "GameObject", g, false);
                }
                
                Debug.Log("TestSaveLoadAsync: save@" + path);

                foreach (var child in children) {
                    if (child == transform) { continue; }
                    var g = child.gameObject;
                    AssetManager.InstantiateAssetAsync(path + "/" + g.gameObject.name + "_asynctest.hbp", (obj, err) => {
                        Debug.Log("TestSaveLoadAsync: loaded async @" + path);
                    });
                }

            } else {
                Debug.LogError("TestSaveLoadAsync: no child found to test save and load on, should be parented in AssetManagerInstance GameObject");
            }
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