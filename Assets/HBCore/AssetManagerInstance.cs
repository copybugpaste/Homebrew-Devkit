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
                if(q.smooth ) {
                    yield return this.StartCoroutineAsync(InstantiateAssetAsyncSmooth(q.assetPath, q.onReturn, q.onProgress), out curInstantiateTask);
                } else {

                    yield return this.StartCoroutineAsync(InstantiateAssetAsync(q.assetPath, q.onReturn, q.onProgress), out curInstantiateTask);
                }
                if (que.ContainsKey(curQueID)) { que.Remove(curQueID); }
                yield return new WaitForEndOfFrame();
            }
        }

        //Instantiating Assets Async
        public string InvokeInstantiateAssetAsyncSmooth(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {

            string queID = IDManager.GetNewIDShort();
            que.Add(queID, new QueData(path, onReturn, onProgress,true));
            return queID;
        }
        public string InvokeInstantiateAssetAsync(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {
            
            string queID = IDManager.GetNewIDShort();
            que.Add(queID, new QueData(path, onReturn, onProgress,false));
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

        void PostProgress(System.Action<float> onProgress,float f) {
            if( onProgress != null ) {
                onProgress(f);
            }

        }

        IEnumerator InstantiateAssetAsyncSmooth(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {

            yield return Ninja.JumpToUnity;

            PostProgress(onProgress, 0.01f);

            var startTime = Time.time;

            if (AssetManager.FileExists(path) == false) { onReturn(null, "cant find file at: " + path); yield break; }

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

            PostProgress(onProgress, 0.02f);

            //load gameObject
            GameObject o = null;
            yield return HBS.Serializer.LoadGameObjectAsync(c + "/data.txt", 5, (ret) => {
                o = ret;
            }, (progress) => {
                PostProgress(onProgress, 0.02f + (progress * 0.88f));
            });
            //GameObject o = HBS.Serializer.LoadGameObject(c + "/data.txt");

            if (o != null) {
                curInstantiateGameObjectRoot = o;
                //call the async load method on MeshExtension
                foreach (KeyValuePair<string, Mesh> v in HBS.MeshExtension.asyncTodo) {
                    yield return this.StartCoroutineAsync(MeshUtilities.LoadH3dOntoMeshAsync(v.Key, v.Value));
                }

                yield return Ninja.JumpBack;

                //delete cache folder
                AssetManager.DeleteCacheFolder(c);

                yield return Ninja.JumpToUnity;

                //smoothly enable collision
                var allMeshColliders = o.GetComponentsInChildren<MeshCollider>(true);
                foreach (var mc in allMeshColliders) {
                    mc.enabled = false;
                }


                o.SetActive(true);

                var cc = 0;
                foreach (var mc in allMeshColliders) {

                    yield return new WaitForEndOfFrame();

                    PostProgress(onProgress, 0.9f + (cc / (float)allMeshColliders.Length * 0.1f));
                    cc++;
                    mc.enabled = false;
                }


                //assign asset comp if not already
                Asset a = o.GetComponent<Asset>();
                if (a == null) { a = o.AddComponent<Asset>(); }
                a.path = path;

                //reset meshExtension back to normal
                //HBS.MeshExtension.cache.Clear();
                HBS.MeshExtension.asyncTodo.Clear();
                HBS.MeshExtension.async = false;

                curInstantiateGameObjectRoot = null;

                PostProgress(onProgress, 1f);

                yield return Ninja.JumpToUnity;
            }


            //call onReturn
            onReturn(o, "succes");
            Debug.Log("loaded asset t:" + (Time.time - startTime).ToString());
        }
        
        IEnumerator InstantiateAssetAsync(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {

            yield return Ninja.JumpToUnity;
            
            PostProgress(onProgress,0.01f);

            var startTime = Time.time;

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

            PostProgress(onProgress, 0.02f);

            //load gameObject
            GameObject o = HBS.Serializer.LoadGameObject(c + "/data.txt");

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

                //smoothly enable collision
                var allMeshColliders = o.GetComponentsInChildren<MeshCollider>(true);
                foreach (var mc in allMeshColliders) {
                    mc.enabled = false;
                }


                o.SetActive(true);

                var cc = 0;
                foreach (var mc in allMeshColliders) {

                    yield return new WaitForEndOfFrame();

                    PostProgress(onProgress, 0.9f + (cc/(float)allMeshColliders.Length * 0.1f));
                    cc++;
                    mc.enabled = false;
                }


                //assign asset comp if not already
                Asset a = o.GetComponent<Asset>();
                if (a == null) { a = o.AddComponent<Asset>(); }
                a.path = path;

                //reset meshExtension back to normal
                //HBS.MeshExtension.cache.Clear();
                HBS.MeshExtension.asyncTodo.Clear();
                HBS.MeshExtension.async = false;

                curInstantiateGameObjectRoot = null;

                PostProgress(onProgress, 1f);

                yield return Ninja.JumpToUnity;
            }

            HBS.Serializer.LogWarning("loaded asset t:" + (Time.time - startTime).ToString());

            //call onReturn
            onReturn(o, "succes");
            
        }

        //Utilities
        public class QueData {
            public string assetPath;
            public System.Action<GameObject, string> onReturn;
            public System.Action<float> onProgress;
            public bool smooth;

            public QueData(string assetPath, System.Action<GameObject, string> onReturn, System.Action<float> onProgress,bool smooth) {
                this.assetPath = assetPath;
                this.onReturn = onReturn;
                this.onProgress = onProgress;
                this.smooth = smooth;
            }
        }
    }
}