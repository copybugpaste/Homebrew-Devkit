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
                var q = que.ContainsKey(curQueID) ? que[curQueID] : null;
                if (q == null) { yield return new WaitForEndOfFrame(); continue; }
                if( q.isSave ) {
                    if(q.smooth ) {
                        yield return this.StartCoroutineAsync(SaveAssetAsyncSmooth(q.assetPath, q.assetType,q.obj,q.makeHBM, q.onReturn, q.onProgress), out curInstantiateTask);
                    } else {

                    }
                } else {
                    if (q.smooth) {
                        yield return this.StartCoroutineAsync(InstantiateAssetAsyncSmooth(q.assetPath, q.onReturn, q.onProgress), out curInstantiateTask);
                    } else {

                        yield return this.StartCoroutineAsync(InstantiateAssetAsync(q.assetPath, q.onReturn, q.onProgress), out curInstantiateTask);
                    }
                }
                if (que.ContainsKey(curQueID)) { que.Remove(curQueID); }
                yield return new WaitForEndOfFrame();
            }
        }

        //Instantiating Assets Async
        public string InvokeSaveAssetAsyncSmooth(string path, string assetType, GameObject obj, bool makeHbm, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {

            var queID = IDManager.GetNewIDShort();
            que.Add(queID, new QueData(path, onReturn, onProgress, true,true,assetType,obj,makeHbm));
            return queID;
        }

        public string InvokeInstantiateAssetAsyncSmooth(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {

            var queID = IDManager.GetNewIDShort();
            que.Add(queID, new QueData(path, onReturn, onProgress, true, false,null,null,false));
            return queID;
        }
        public string InvokeInstantiateAssetAsync(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {
            
            var queID = IDManager.GetNewIDShort();
            que.Add(queID, new QueData(path, onReturn, onProgress,false,false, null, null, false));
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

        IEnumerator SaveAssetAsyncSmooth(string path,string assetType, GameObject obj,bool makeHbm, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {
            yield return Ninja.JumpToUnity;

            PostProgress(onProgress, 0.01f);

            var startTime = Time.time;

            string persistentDataPath = Application.persistentDataPath;


            //clone
            obj = GameObject.Instantiate(obj);

            obj.SetActive(false);

            //remove Asset components before saving
            Asset[] assets = obj.GetComponentsInChildren<Asset>(true);
            foreach (Asset a in assets) {
#if UNITY_EDITOR
                GameObject.DestroyImmediate(a, false);
#else
                GameObject.Destroy(a); 
#endif
            }
            
            yield return Ninja.JumpBack;
            
            //create cache folder
            string cache = AssetManager.CreateCacheFolder(persistentDataPath);

            yield return Ninja.JumpToUnity;

            //setup mesh extension
            HBS.MeshExtension.savePath = cache;
            HBS.MeshExtension.async = true;
            
            //save gameObject
            yield return HBS.Serializer.SaveGameObjectAsync(cache + "/data.txt", obj,5, (ret) => {
               
            }, (progress) => {
                PostProgress(onProgress, 0.02f + (progress * 0.78f));
            });


            var cc = 0;
            foreach (KeyValuePair<string, Mesh> v in HBS.MeshExtension.asyncTodo) {

                yield return new WaitForEndOfFrame();

                PostProgress(onProgress, 0.8f + (((float)cc/(float)HBS.MeshExtension.asyncTodo.Count) * 0.2f));

                var data = new byte[0];

                yield return this.StartCoroutineAsync(MeshUtilities.SaveH3dAsync( v.Value,(stream)=> {
                    data = stream.ToArray();
                }));

                yield return Ninja.JumpBack;
                
                File.WriteAllBytes(v.Key, data);

                yield return Ninja.JumpToUnity;

                cc++;
            }

            yield return Ninja.JumpBack;


            //zip the folder
            HBS.Serializer.ZipFolderTo(cache, path);

            //write HBM file
            if (makeHbm) {
                AssetManager.CreatMetaFile(path, assetType);
            }

            //delete the folder
            AssetManager.DeleteCacheFolder(cache);

            yield return Ninja.JumpToUnity;

            //reset meshextension
            HBS.MeshExtension.asyncTodo.Clear();
            HBS.MeshExtension.async = false;

            //Destroy clone
            GameObject.DestroyImmediate(obj);

            PostProgress(onProgress, 1f);
            onReturn(obj, "succes");
            HBS.Serializer.LogWarning("saved asset t:" + (Time.time - startTime).ToString());
        }

        IEnumerator InstantiateAssetAsyncSmooth(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {

            yield return Ninja.JumpToUnity;

            PostProgress(onProgress, 0.01f);

            var startTime = Time.time;

            if (AssetManager.FileExists(path) == false) { onReturn(null, "cant find file at: " + path); yield break; }

            var persistentDataPath = Application.persistentDataPath;

            yield return Ninja.JumpBack;


            //create cache folder
            var c = AssetManager.CreateCacheFolder(persistentDataPath);
            var c2 = AssetManager.CreateCacheFolder(persistentDataPath);

            //setup mesh extension to async
            HBS.MeshExtension.savePath = c;
            HBS.MeshExtension.async = true;

            //unzip to
            HBS.Serializer.UnzipFolderTo(path, c);
            
            //load gameObject

            //check if its a regular hbp 
            var filePath = c + "/data.txt";
            GameObject o = null;

            //check if its a regular hbp 
            if (File.Exists(filePath)) {

                yield return Ninja.JumpToUnity;
                PostProgress(onProgress, 0.02f);

                yield return HBS.Serializer.LoadGameObjectAsync(filePath, 5, (ret) => {
                    o = ret;
                }, (progress) => {
                    PostProgress(onProgress, 0.02f + (progress * 0.78f));
                });

            } else {

                //check if its a vehicle hbp wrap
                var exportedPath = c + "/exported.hbp";
                if (File.Exists(exportedPath)) {

                    //extract vehicle exported version
                    HBS.Serializer.UnzipFolderTo(exportedPath, c2);

                    //load vehicle exported version
                    filePath = c2 + "/data.txt";
                    if (File.Exists(filePath)) {

                        yield return Ninja.JumpToUnity;
                        HBS.MeshExtension.savePath = c2;
                        PostProgress(onProgress, 0.02f);

                        yield return HBS.Serializer.LoadGameObjectAsync(filePath, 5, (ret) => {
                            o = ret;
                        }, (progress) => {
                            PostProgress(onProgress, 0.02f + (progress * 0.78f));
                        });
                    }
                }
            }
            

            if (o != null) {
                curInstantiateGameObjectRoot = o;
                //call the async load method on MeshExtension
                var cc = 0;

                foreach (var v in HBS.MeshExtension.asyncTodo) {
                    
                    yield return this.StartCoroutineAsync(MeshUtilities.LoadH3dOntoMeshAsync(v.Key, v.Value));
                    
                    PostProgress(onProgress, 0.8f + (cc / (float)HBS.MeshExtension.asyncTodo.Count * 0.15f));
                    cc++;
                }

                yield return Ninja.JumpBack;

                //delete cache folder
                AssetManager.DeleteCacheFolder(c);
                AssetManager.DeleteCacheFolder(c2);

                yield return Ninja.JumpToUnity;

                //smoothly enable collision
                var allMeshColliders = o.GetComponentsInChildren<MeshCollider>(true);
                foreach (var mc in allMeshColliders) {
                    mc.enabled = false;
                }

                var allRenderers = o.GetComponentsInChildren<Renderer>(true);
                var allEnabledRenderers = new List<Renderer>();
                foreach (var r in allRenderers) {
                    if( r.enabled ) {
                        allEnabledRenderers.Add(r);
                        r.enabled = false;
                    }
                }

                o.SetActive(true);

                cc = 0;
                foreach (var mc in allMeshColliders) {

                    yield return new WaitForEndOfFrame();

                    PostProgress(onProgress, 0.95f + (cc / (float)allMeshColliders.Length * 0.05f));
                    cc++;
                    mc.enabled = true;
                }


                //assign asset comp if not already
                var a = o.GetComponent<Asset>();
                if (a == null) { a = o.AddComponent<Asset>(); }
                a.path = path;
                
                curInstantiateGameObjectRoot = null;

                PostProgress(onProgress, 1f);

                foreach (var r in allEnabledRenderers) {                    
                    r.enabled = true;
                }

            }

            yield return Ninja.JumpToUnity;

            HBS.MeshExtension.asyncTodo.Clear();
            HBS.MeshExtension.async = false;

            //call onReturn
            onReturn(o, "succes");
            HBS.Serializer.LogWarning("loaded asset t:" + (Time.time - startTime).ToString());
        }
        
        IEnumerator InstantiateAssetAsync(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {

            yield return Ninja.JumpToUnity;
            
            PostProgress(onProgress,0.01f);

            var startTime = Time.time;

            if (AssetManager.FileExists(path) == false) { onReturn(null, "cant find file at: "+path); yield break; }

            var persistentDataPath = Application.persistentDataPath;
            
            yield return Ninja.JumpBack;

            
            //create cache folder
            var c = AssetManager.CreateCacheFolder(persistentDataPath);
            var c2 = AssetManager.CreateCacheFolder(persistentDataPath);

            //setup mesh extension to async
            HBS.MeshExtension.savePath = c;
            HBS.MeshExtension.async = true;

            //unzip to
            HBS.Serializer.UnzipFolderTo(path, c);


            //load gameObject
            //GameObject o = HBS.Serializer.LoadGameObject(c + "/data.txt");

            //check if its a regular hbp 
            var filePath = c + "/data.txt";
            GameObject o = null;

            //check if its a regular hbp 
            if (File.Exists(filePath)) {
                
                yield return Ninja.JumpToUnity;

                PostProgress(onProgress, 0.02f);

                o = HBS.Serializer.LoadGameObject(filePath);

            } else {

                //check if its a vehicle hbp wrap
                var exportedPath = c + "/exported.hbp";
                if (File.Exists(exportedPath)) {

                    //extract vehicle exported version
                    HBS.Serializer.UnzipFolderTo(exportedPath, c2);

                    //load vehicle exported version
                    filePath = c2 + "/data.txt";
                    if (File.Exists(filePath)) {
                        HBS.MeshExtension.savePath = c2;
                        
                        yield return Ninja.JumpToUnity;

                        PostProgress(onProgress, 0.02f);

                        o = HBS.Serializer.LoadGameObject(filePath);
                    }
                    
                }
            }



            if ( o != null ) {
                curInstantiateGameObjectRoot = o;
                //call the async load method on MeshExtension
                foreach (var v in HBS.MeshExtension.asyncTodo) {
                    yield return this.StartCoroutineAsync(MeshUtilities.LoadH3dOntoMeshAsync(v.Key, v.Value));
                }

                yield return Ninja.JumpBack;

                //delete cache folder
                AssetManager.DeleteCacheFolder(c);
                AssetManager.DeleteCacheFolder(c2);

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
                var a = o.GetComponent<Asset>();
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
            HBS.Serializer.LogWarning("loaded asset t:" + (Time.time - startTime).ToString());
        }

        //Utilities
        public class QueData {
            public string assetPath;
            public System.Action<GameObject, string> onReturn;
            public System.Action<float> onProgress;
            public bool smooth;
            public bool isSave;
            public string assetType;
            public GameObject obj;
            public bool makeHBM;

            public QueData(string assetPath, System.Action<GameObject, string> onReturn, System.Action<float> onProgress, bool smooth, bool isSave,string assetType,GameObject obj,bool makeHBM) {
                this.assetPath = assetPath;
                this.onReturn = onReturn;
                this.onProgress = onProgress;
                this.smooth = smooth;
                this.isSave = isSave;
                this.assetType = assetType;
                this.obj = obj;
                this.makeHBM = makeHBM;

            }
        }
    }
}