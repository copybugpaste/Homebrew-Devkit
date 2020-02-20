
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml.Linq;
using System.Threading;
using System.Text.RegularExpressions;
using CielaSpike;
using System.Linq;

namespace HBWorld { 
    public static class AssetManager {

        public static AssetManagerInstance instance;    
        public static List<string> cacheFolders = new List<string>();
        public static GameObject curInstantiateGameObjectRoot = null;
        public static string curQueID = "";
        public static Dictionary<string, QueData> que = new Dictionary<string, QueData>();
        public static Task curInstantiateTask;

        public static void OnApplicationQuit() {
            try {
                //cleanup all leftover cachfolders if any
                foreach (string c in cacheFolders) {
                    if (Directory.Exists(c)) {
                        Directory.Delete(c, true);
                        Debug.LogWarningFormat("[OnApplicationQuit] Cleaned up {0}.", c);
                    }
                }
            } catch { }
        }

        //async que
        public static IEnumerator RunQue() {
            yield return Ninja.JumpToUnity;
            while (true) {
                if (que.Count() == 0) { yield return new WaitForEndOfFrame(); continue; }
                curQueID = que.Keys.First();
                var q = que.ContainsKey(curQueID) ? que[curQueID] : null;
                if (q == null) { yield return new WaitForEndOfFrame(); continue; }
                if (q.isSave) {
                    if (q.smooth) {
                        yield return instance.StartCoroutineAsync(_SaveAssetAsyncSmooth(q.assetPath, q.assetType, q.obj, q.makeHBM, q.onReturn, q.onProgress), out curInstantiateTask);
                    } else {

                    }
                } else {
                    if (q.smooth) {
                        yield return instance.StartCoroutineAsync(_InstantiateAssetAsyncSmooth(q.assetPath, q.onReturn, q.onProgress), out curInstantiateTask);
                    } else {

                        yield return instance.StartCoroutineAsync(_InstantiateAssetAsync(q.assetPath, q.onReturn, q.onProgress), out curInstantiateTask);
                    }
                }
                if (que.ContainsKey(curQueID)) { que.Remove(curQueID); }
                yield return new WaitForEndOfFrame();
            }
        }

        //Instantiating Assets
        public static string InstantiateAssetAsyncSmooth(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {
            if (instance == null) { onReturn(null, "No AssetManagerInstance"); Debug.LogError("No AssetManagerInstance"); return ""; }
            var queID = IDManager.GetNewIDShort();
            que.Add(queID, new QueData(path, onReturn, onProgress, true, false, null, null, false));
            return queID;
        }
        public static string InstantiateAssetAsync(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {
            if (instance == null) { onReturn(null, "No AssetManagerInstance"); Debug.LogError("No AssetManagerInstance"); return ""; }
            var queID = IDManager.GetNewIDShort();
            que.Add(queID, new QueData(path, onReturn, onProgress, false, false, null, null, false));
            return queID;
        }
        public static void CancelInstantiateAsync(string id) {
            if (instance == null) { Debug.LogError("No AssetManagerInstance"); return; }
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
	    
        public static IEnumerator _InstantiateAssetAsyncSmooth(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {

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
            HBS.RevExtension.savePath = c;
            HBS.RevExtension.async = true;

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
                        HBS.RevExtension.savePath = c2;
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

                    yield return instance.StartCoroutineAsync(MeshUtilities.LoadH3dOntoMeshAsync(v.Key, v.Value));

                    PostProgress(onProgress, 0.8f + (cc / (float)HBS.MeshExtension.asyncTodo.Count * 0.05f));
                    cc++;
                }

                foreach (var v in HBS.RevExtension.asyncTodo) {

                    yield return instance.StartCoroutineAsync(RevAudioClipUtilities.LoadHraOntoRevAudioClipAsync(v.Key, v.Value));

                    v.Value.SetReady();

                    PostProgress(onProgress, 0.85f + (cc / (float)HBS.RevExtension.asyncTodo.Count * 0.1f));
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
                    if (r.enabled) {
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
            HBS.RevExtension.asyncTodo.Clear();
            HBS.RevExtension.async = false;

            //call onReturn
            onReturn(o, "succes");
            HBS.Serializer.LogWarning("loaded asset t:" + (Time.time - startTime).ToString());
        }
        public static IEnumerator _InstantiateAssetAsync(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {

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
            HBS.RevExtension.savePath = c;
            HBS.RevExtension.async = true;

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
                        HBS.RevExtension.savePath = c2;

                        yield return Ninja.JumpToUnity;

                        PostProgress(onProgress, 0.02f);

                        o = HBS.Serializer.LoadGameObject(filePath);
                    }

                }
            }



            if (o != null) {
                curInstantiateGameObjectRoot = o;
                //call the async load method on MeshExtension
                foreach (var v in HBS.MeshExtension.asyncTodo) {
                    yield return instance.StartCoroutineAsync(MeshUtilities.LoadH3dOntoMeshAsync(v.Key, v.Value));
                }
                foreach (var v in HBS.RevExtension.asyncTodo) {
                    yield return instance.StartCoroutineAsync(RevAudioClipUtilities.LoadHraOntoRevAudioClipAsync(v.Key, v.Value));
                    v.Value.SetReady();
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

                    PostProgress(onProgress, 0.9f + (cc / (float)allMeshColliders.Length * 0.1f));
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
                HBS.RevExtension.asyncTodo.Clear();
                HBS.RevExtension.async = false;

                curInstantiateGameObjectRoot = null;

                PostProgress(onProgress, 1f);

                yield return Ninja.JumpToUnity;
            }

            HBS.Serializer.LogWarning("loaded asset t:" + (Time.time - startTime).ToString());

            //call onReturn
            onReturn(o, "succes");
            HBS.Serializer.LogWarning("loaded asset t:" + (Time.time - startTime).ToString());
        }
        public static GameObject InstantiateAsset(string path) {
            //load extensions 
            HBS.Serializer.LoadExtensions();

            
            HBS.MeshExtension.async = false;
            HBS.RevExtension.async = false;


            //create cache folder
            var c = CreateCacheFolder();

            //setup mesh extension
            HBS.MeshExtension.savePath = c;
            HBS.RevExtension.savePath = c;

            //setup terraintile extension
            //HBS.TerrainTileExtension.savePath = c;

            //unzip to
            HBS.Serializer.UnzipFolderTo(path, c);

            //load gameObject
            var filePath = c + "/data.txt";
            GameObject o = null;

            //check if its a regular hbp 
            if (File.Exists(filePath)) {

                o = HBS.Serializer.LoadGameObject(filePath);

            } else {

                //check if its a vehicle hbp wrap
                var exportedPath = c + "/exported.hbp";
                if (File.Exists(exportedPath)) {

                    //extract vehicle exported version
                    var c2 = CreateCacheFolder();
                    HBS.Serializer.UnzipFolderTo(exportedPath, c2);

                    //load vehicle exported version
                    filePath = c2 + "/data.txt";
                    if (File.Exists(filePath)) {
                        HBS.MeshExtension.savePath = c2;
                        HBS.RevExtension.savePath = c2;
                        o = HBS.Serializer.LoadGameObject(filePath);
                    }
                }
            }

            //delete cache folder
            DeleteCacheFolder(c);

            //reset extension
            HBS.MeshExtension.async = false;
            HBS.RevExtension.async = false;

            //assign asset comp if not already
            if (o != null) {
                Asset a = o.GetComponent<Asset>();
                if (a == null) { a = o.AddComponent<Asset>(); }
                a.path = path;

                o.SetActive(true);
            }


            return o;
        }

        //saving Assets
        public static string SaveAssetAsyncSmooth(string path, string assetType, GameObject obj, bool makeHbm , System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {
            if (instance == null) { onReturn(null, "No AssetManagerInstance"); Debug.LogError("No AssetManagerInstance"); return ""; }
            var queID = IDManager.GetNewIDShort();
            que.Add(queID, new QueData(path, onReturn, onProgress, true, true, assetType, obj, makeHbm));
            return queID;
        }

        public static IEnumerator _SaveAssetAsyncSmooth(string path, string assetType, GameObject obj, bool makeHbm, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {
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
            HBS.RevExtension.savePath = cache;
            HBS.RevExtension.async = true;

            //save gameObject
            yield return HBS.Serializer.SaveGameObjectAsync(cache + "/data.txt", obj, 5, (ret) => {

            }, (progress) => {
                PostProgress(onProgress, 0.02f + (progress * 0.78f));
            });


            var cc = 0;
            foreach (var v in HBS.MeshExtension.asyncTodo) {

                yield return new WaitForEndOfFrame();

                PostProgress(onProgress, 0.8f + (((float)cc / (float)HBS.MeshExtension.asyncTodo.Count) * 0.1f));

                var data = new byte[0];

                yield return instance.StartCoroutineAsync(MeshUtilities.SaveH3dAsync(v.Value, (stream) => {
                    data = stream.ToArray();
                }));

                yield return Ninja.JumpBack;

                File.WriteAllBytes(v.Key, data);

                yield return Ninja.JumpToUnity;

                cc++;
            }

            cc = 0;
            foreach (var v in HBS.RevExtension.asyncTodo) {

                yield return new WaitForEndOfFrame();

                PostProgress(onProgress, 0.9f + (((float)cc / (float)HBS.RevExtension.asyncTodo.Count) * 0.1f));

                var data = new byte[0];
                yield return instance.StartCoroutineAsync(RevAudioClipUtilities.SaveHraAsync(v.Value, (stream) => {
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
            HBS.RevExtension.asyncTodo.Clear();
            HBS.RevExtension.async = false;

            //Destroy clone
            GameObject.DestroyImmediate(obj);

            PostProgress(onProgress, 1f);
            onReturn(obj, "succes");
            HBS.Serializer.LogWarning("saved asset t:" + (Time.time - startTime).ToString());
        }
        public static void SaveAsset(string path, string assetType, GameObject obj, bool makeHbm = true) {

            //remove Asset components before saving
            Asset[] assets = obj.GetComponentsInChildren<Asset>();
            foreach (Asset a in assets) {
#if UNITY_EDITOR
                GameObject.DestroyImmediate(a, false);
#else
                GameObject.Destroy(a); 
#endif
            }

            //load extensions 
            HBS.Serializer.LoadExtensions();

            //create cache folder
            string cache = CreateCacheFolder();

            //setup mesh extension
            HBS.MeshExtension.savePath = cache;
            HBS.MeshExtension.async = false;
            HBS.RevExtension.savePath = cache;
            HBS.RevExtension.async = false;

            //setup terraintile extension
            //HBS.TerrainTileExtension.savePath = cache;

            //save gameObject
            HBS.Serializer.SaveGameObject(cache + "/data.txt", obj);

            //zip the folder
            HBS.Serializer.ZipFolderTo(cache, path);

            //write HBM file
            if (makeHbm) {
                CreatMetaFile(path, assetType);
            }

            //delete the folder
            DeleteCacheFolder(cache);
        }

        //utils
        public static void DeleteAsset( string path ) {
		    if( File.Exists( path )) { File.Delete(path); }
		    path = Path.GetDirectoryName(path)+"/"+System.IO.Path.GetFileName(path)+".hbm";
		    if( File.Exists( path )) { File.Delete(path); }
		    path = Path.GetDirectoryName(path)+"/"+System.IO.Path.GetFileName(path)+".png";
		    if( File.Exists( path )) { File.Delete(path); }
		    path = Path.GetDirectoryName(path)+"/"+System.IO.Path.GetFileName(path)+".hbp";
		    if( File.Exists( path )) { File.Delete(path); }
		    path = Path.GetDirectoryName(path)+"/"+System.IO.Path.GetFileName(path)+".hba";
		    if( File.Exists( path )) { File.Delete(path); }

	    }
        public static void CreatMetaFile(string path, string assetType) {
            path = ConvertToHbmPath(path);
            XElement hbm = new XElement("HBMETA");
            hbm.Add(new XElement("Type", assetType));
            hbm.Save(path);
        }
        public static string ConvertToHbmPath(string path) {
            return Path.GetDirectoryName(path) + "/" + Path.GetFileNameWithoutExtension(path) + ".hbm";
        }
        public static string GetRandomID() {
            return IDManager.GetNewID();
            //return DateTime.Now.Ticks.ToString();
        }
        public static bool DeleteCacheFolder(string path) {
            if (cacheFolders.Contains(path)) {
                Directory.Delete(path, true);
                return true;
            }
            Debug.LogWarningFormat("cache didn't contain {0}.", path);
            return false;
        }
        public static string CreateCacheFolder(string path = null) {
            if (string.IsNullOrEmpty(path)) {
                path = Application.persistentDataPath;
            }
            path += "/temp/" + GetRandomID();
            Directory.CreateDirectory(path);
            cacheFolders.Add(path);
            return WashPath(path);
        }
        public static void UnZip(string path, string extractPath) {
            try {
                ZipUtil.Unzip(path, extractPath);
            } catch (System.Exception e) {
                Debug.LogError(e.ToString());
            }
        }
        public static void ZipFile(string path, string destinationPath) {
            try {
                ZipUtil.Zip(destinationPath, new string[1] { path });
            } catch (System.Exception e) {
                Debug.LogError(e.ToString());
            }
        }
        public static void ZipDirectory(string path, string destinationPath) {
            DirectoryInfo dir = new DirectoryInfo(path);
            List<string> files = new List<string>();
            foreach (FileInfo f in dir.GetFiles()) {
                files.Add(f.FullName);
            }
            ZipUtil.Zip(destinationPath, files.ToArray());
        }
        public static string WashPath(string path) {
            if (string.IsNullOrEmpty(path)) { return ""; }
            return Regex.Replace(path, "[\\\\/][\\\\/]*", "/");
        }
        public static string WashPath(System.Object o) {
            return "";
        }
        public static bool FileExists(string p) {
            return File.Exists(p);
        }

        static void PostProgress(System.Action<float> onProgress, float f) {
            if (onProgress != null) {
                onProgress(f);
            }
        }
        
    }

    public class QueData {
        public string assetPath;
        public System.Action<GameObject, string> onReturn;
        public System.Action<float> onProgress;
        public bool smooth;
        public bool isSave;
        public string assetType;
        public GameObject obj;
        public bool makeHBM;

        public QueData(string assetPath, System.Action<GameObject, string> onReturn, System.Action<float> onProgress, bool smooth, bool isSave, string assetType, GameObject obj, bool makeHBM) {
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

public static class IDManager {
    public static char[] letters = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    public static char[] allletters = new char[62] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    //always returns a uniek string
    public static string GetHomebrewID() {
        string id = "";
        if (File.Exists(Application.persistentDataPath + "/uidhb.hbi") == false) {
            id = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
            File.WriteAllText(Application.persistentDataPath + "/uidhb.hbi", id);
        } else {
            id = File.ReadAllText(Application.persistentDataPath + "/uidhb.hbi");
        }
        return id;
    }
    public static string GetNewIDOld() {
        Guid g = Guid.NewGuid();
        string GuidString = Convert.ToBase64String(g.ToByteArray());
        //remove following chars
        GuidString = GuidString.Replace("=", "");
        GuidString = GuidString.Replace("+", "");
        GuidString = GuidString.Replace("/", "");
        return GuidString;
    }
    private static int seed {
        get {
            return Environment.TickCount * Thread.CurrentThread.ManagedThreadId;
        }
    }
    private static readonly ThreadLocal<System.Random> random = new ThreadLocal<System.Random>(() => new System.Random(seed));
    public static string GetNewIDShort() {
        char[] ret = new char[4];
        ret[00] = allletters[random.Value.Next(0, 62)];
        ret[01] = allletters[random.Value.Next(0, 62)];
        ret[02] = allletters[random.Value.Next(0, 62)];
        ret[03] = allletters[random.Value.Next(0, 62)];
        return new string(ret);
    }
    public static string GetNewID() {
        char[] ret = new char[32];
        ret[00] = letters[random.Value.Next(0, 26)];
        ret[01] = letters[random.Value.Next(0, 26)];
        ret[02] = letters[random.Value.Next(0, 26)];
        ret[03] = letters[random.Value.Next(0, 26)];
        ret[04] = letters[random.Value.Next(0, 26)];
        ret[05] = letters[random.Value.Next(0, 26)];
        ret[06] = letters[random.Value.Next(0, 26)];
        ret[07] = letters[random.Value.Next(0, 26)];
        ret[08] = letters[random.Value.Next(0, 26)];
        ret[09] = letters[random.Value.Next(0, 26)];
        ret[10] = letters[random.Value.Next(0, 26)];
        ret[11] = letters[random.Value.Next(0, 26)];
        ret[12] = letters[random.Value.Next(0, 26)];
        ret[13] = letters[random.Value.Next(0, 26)];
        ret[14] = letters[random.Value.Next(0, 26)];
        ret[15] = letters[random.Value.Next(0, 26)];
        ret[16] = letters[random.Value.Next(0, 26)];
        ret[17] = letters[random.Value.Next(0, 26)];
        ret[18] = letters[random.Value.Next(0, 26)];
        ret[19] = letters[random.Value.Next(0, 26)];
        ret[20] = letters[random.Value.Next(0, 26)];
        ret[21] = letters[random.Value.Next(0, 26)];
        ret[22] = letters[random.Value.Next(0, 26)];
        ret[23] = letters[random.Value.Next(0, 26)];
        ret[24] = letters[random.Value.Next(0, 26)];
        ret[25] = letters[random.Value.Next(0, 26)];
        ret[26] = letters[random.Value.Next(0, 26)];
        ret[27] = letters[random.Value.Next(0, 26)];
        ret[28] = letters[random.Value.Next(0, 26)];
        ret[29] = letters[random.Value.Next(0, 26)];
        ret[30] = letters[random.Value.Next(0, 26)];
        ret[31] = letters[random.Value.Next(0, 26)];
        return new string(ret);
    }
    
}