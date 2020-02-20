
using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml.Linq;
using System.Threading;
using System.Text.RegularExpressions;

namespace HBWorld { 
    public static class AssetManager {

        public static AssetManagerInstance instance; //used for async
        
        public static List<string> cacheFolders = new List<string>();

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


        //Instantiating Assets
        public static string InstantiateAssetAsyncSmooth(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {
            if (instance == null) { onReturn(null, "No AssetManagerInstance"); Debug.LogError("No AssetManagerInstance"); return ""; }
            return instance.InvokeInstantiateAssetAsyncSmooth(path, onReturn, onProgress);
        }
        public static string InstantiateAssetAsync(string path, System.Action<GameObject, string> onReturn, System.Action<float> onProgress = null) {
            if (instance == null) { onReturn(null, "No AssetManagerInstance"); Debug.LogError("No AssetManagerInstance"); return ""; }
            return instance.InvokeInstantiateAssetAsync(path, onReturn, onProgress);
        }
        public static void CancelInstantiateAsync(string id) {
            if (instance == null) { Debug.LogError("No AssetManagerInstance"); return; }
            instance.CancelInstantiateAssetAsync(id);
        }
	    public static GameObject InstantiateAsset( string path ) {
		    //load extensions 
		    HBS.Serializer.LoadExtensions();

            bool preAsync = HBS.MeshExtension.async;
            HBS.MeshExtension.async = false;


		    //create cache folder
		    string c = CreateCacheFolder();

		    //setup mesh extension
		    HBS.MeshExtension.savePath = c;

            //setup terraintile extension
            //HBS.TerrainTileExtension.savePath = c;

		    //unzip to
		    HBS.Serializer.UnzipFolderTo(path,c);

		    //load gameObject
		    GameObject o = HBS.Serializer.LoadGameObject(c+"/data.txt");

		    //delete cache folder
            DeleteCacheFolder(c);

            //reset extension
            HBS.MeshExtension.async = false;

		    //assign asset comp if not already
            if( o != null ) {
                Asset a = o.GetComponent<Asset>();
                if (a == null) { a = o.AddComponent<Asset>(); }
                a.path = path;

                o.SetActive(true);
            }
		  

		    return o;
	    }
	    
	    //saving Assets
	    public static void SaveAsset( string path , string assetType , GameObject obj , bool makeHbm = true  ) {

		    //remove Asset components before saving
		    Asset[] assets = obj.GetComponentsInChildren<Asset>();
		    foreach( Asset a in assets ) {
#if UNITY_EDITOR
                GameObject.DestroyImmediate(a,false); 
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

            //setup terraintile extension
            //HBS.TerrainTileExtension.savePath = cache;
		
		    //save gameObject
		    HBS.Serializer.SaveGameObject(cache+"/data.txt",obj);
		
		    //zip the folder
		    HBS.Serializer.ZipFolderTo(cache,path);

            //write HBM file
            if (makeHbm) {
                CreatMetaFile(path, assetType);
            }
		
		    //delete the folder
		    DeleteCacheFolder(cache);
	    }
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