using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Threading;

#if UNITY_EDITOR
#endif

namespace HBS {

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct)] //wills serialize this class properly
    public class SerializeAttribute : System.Attribute { }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct)] //will serialize this class as part ( only saves properties )
    public class SerializePartAttribute : System.Attribute { }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)] //will serialize this class as part ( only saves properties )
    public class SerializePartVarAttribute : System.Attribute { }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct)] //will serialize component only , this will make serializer put this component back on but does not set any of its values
    public class SerializeComponentOnlyAttribute : System.Attribute { }

    public static class Serializer {

        public static bool debug = false;
        public static int prefix = 1;
        public static string persistentDataPath;
        private static int seed {
            get {
                return Environment.TickCount * Thread.CurrentThread.ManagedThreadId;
            }
        }
        public static char[] letters = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private static readonly ThreadLocal<System.Random> random = new ThreadLocal<System.Random>(() => new System.Random(seed));

        public static SerializerInstance instance;
        public static MethodInfo serializeMethod;
        public static MethodInfo unserializeMethod;
        public static GameObject currentRoot; //used in UnserializePath function ( no issue with unserializing multiple hbps at same time , this var is set before unserializing a chunk that never runs async )
        public static Dictionary<Type, Action<Writer, object>> specialCaseSerializers = new Dictionary<Type, Action<Writer, object>>();
        public static Dictionary<Type, Func<Reader, Type, object, object>> specialCaseUnserializers = new Dictionary<Type, Func<Reader, Type, object, object>>();
        public static List<string> cacheFolders = new List<string>();

        public static bool InitHooks() {
            if (serializeMethod == null || unserializeMethod == null) {
                HookToSerializeMethods();
            }
            return serializeMethod != null && unserializeMethod != null;
        }
        private static void HookToSerializeMethods() {
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies()) {
                if (a.GetName().Name == "Assembly-CSharp") {
                    Type binder = a.GetType("HBS.SerializerBinder");
                    if (binder == null) {
                        Debug.Log("No code for serialization generated");
                        return;
                    }
                    serializeMethod = binder.GetMethod("Serialize");
                    unserializeMethod = binder.GetMethod("Unserialize");
                    if (serializeMethod == null || unserializeMethod == null) {
                        Debug.Log("Cant find binder serialization methods");
                        return;
                    }
                }
            }
        }

        public static void OverrideSerializeType(Type type, Action<Writer, object> action) {
            if (specialCaseSerializers.ContainsKey(type) == false) {
                specialCaseSerializers.Add(type, action);
            } else {
                specialCaseSerializers[type] = action;
            }
        }
        public static void OverrideUnserializeType(Type type, Func<Reader, Type, object, object> func) {
            if (specialCaseUnserializers.ContainsKey(type) == false) {
                specialCaseUnserializers.Add(type, func);
            } else {
                specialCaseUnserializers[type] = func;
            }
        }

        public static void Serialize(Writer writer, object o) {
            SerializerBinder.Serialize(writer, o);
        }
        public static object Unserialize(Reader reader, Type t, object o = null) {
            return SerializerBinder.Unserialize(reader, t, o);
        }
        public static void SerializePath(Writer writer, object o) {
            if (writer.WriteNull(o)) { return; }

            GameObject obj = null;
            if (o.GetType() == typeof(GameObject)) {
                obj = (GameObject)o;
            } else {
                Component c = (Component)o;
                if (c != null) {
                    obj = c.gameObject;
                }
            }

            if (writer.WriteNull(obj)) { return; }

            string p = "";
            Transform t = obj.transform;
            while (t != null) {
                if (t.parent == null) {
                    break;
                }
                if (t == currentRoot.transform) {
                    break;
                }

                int index = -1;
                foreach (Transform neighbor in t.parent) {
                    index++;
                    if (neighbor == t) { break; }
                }
                if (p == "") {
                    p = "/" + index.ToString();
                } else {
                    p = "/" + index.ToString() + p;
                }

                t = t.parent;
            }
            if (p != "") {
                p = p.Substring(1, p.Length - 1);
            }
            if (o.GetType() != typeof(GameObject)) {
                Component c = (Component)o;
                Component[] comps = obj.GetComponents<Component>();
                p += "|" + Array.IndexOf(comps, c);
            }
            p += ".";
            writer.Write(p);
        }
        public static object UnserializePath(Reader reader) {
            if (reader.ReadNull()) { return null; }
            if (reader.ReadNull()) { return null; }

            string p = (string)reader.Read();

            if (p.Length <= 1) { return currentRoot; }
            p = p.Substring(0, p.Length - 1);

            string[] path = null;
            string comp = "";
            if (p.Contains("|")) {
                string[] compsplit = p.Split('|');
                path = compsplit[0].Split('/');
                comp = compsplit[1];
            } else {
                path = p.Split('/');
            }

            Transform par = currentRoot.transform;
            foreach (string s in path) {
                if (s == "") { continue; }
                int index = int.Parse(s);
                if (index >= 0 && index < par.childCount) {
                    par = par.GetChild(index);
                } else { return null; }
            }
            if (par == null) { return null; }
            GameObject obj = par.gameObject;

            if (comp != "") {
                int index = int.Parse(comp);
                Component[] comps = obj.GetComponents<Component>();
                if (index >= 0 && index < comps.Length) {
                    return (object)comps[index];
                } else { return false; }
            } else {
                return (object)obj;
            }
        }

        public static void ZipFolderTo(string p, string t) {
            try {

                DirectoryInfo dir = new DirectoryInfo(p);
                List<string> files = new List<string>();
                foreach (FileInfo f in dir.GetFiles()) {
                    files.Add(f.FullName);
                }

                ZipUtil.Zip(t, files.ToArray());
            } catch (System.Exception e) {
                Debug.LogError(e.ToString());
            }
        }
        public static void UnzipFolderTo(string p, string t) {
            try {
                ZipUtil.Unzip(p, t);
            } catch (System.Exception e) {
                Debug.LogError(e.ToString());
            }
        }
        public static void LogWarning(object o) {
            if (debug) {
                Debug.LogWarning(o);
            }
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
                path = persistentDataPath;
            }
            path += "/temp/" + GetRandomID();
            Directory.CreateDirectory(path);
            cacheFolders.Add(path);
            return WashPath(path);
        }
        public static string WashPath(string path) {
            if (string.IsNullOrEmpty(path)) { return ""; }
            return Regex.Replace(path, "[\\\\/][\\\\/]*", "/");
        }
        public static string WashPath(System.Object o) {
            return "";
        }

        public static string GetRandomID() {
            var length = letters.Length;
            var ret = new char[32];
            ret[00] = letters[random.Value.Next(0, length)];
            ret[01] = letters[random.Value.Next(0, length)];
            ret[02] = letters[random.Value.Next(0, length)];
            ret[03] = letters[random.Value.Next(0, length)];
            ret[04] = letters[random.Value.Next(0, length)];
            ret[05] = letters[random.Value.Next(0, length)];
            ret[06] = letters[random.Value.Next(0, length)];
            ret[07] = letters[random.Value.Next(0, length)];
            ret[08] = letters[random.Value.Next(0, length)];
            ret[09] = letters[random.Value.Next(0, length)];
            ret[10] = letters[random.Value.Next(0, length)];
            ret[11] = letters[random.Value.Next(0, length)];
            ret[12] = letters[random.Value.Next(0, length)];
            ret[13] = letters[random.Value.Next(0, length)];
            ret[14] = letters[random.Value.Next(0, length)];
            ret[15] = letters[random.Value.Next(0, length)];
            ret[16] = letters[random.Value.Next(0, length)];
            ret[17] = letters[random.Value.Next(0, length)];
            ret[18] = letters[random.Value.Next(0, length)];
            ret[19] = letters[random.Value.Next(0, length)];
            ret[20] = letters[random.Value.Next(0, length)];
            ret[21] = letters[random.Value.Next(0, length)];
            ret[22] = letters[random.Value.Next(0, length)];
            ret[23] = letters[random.Value.Next(0, length)];
            ret[24] = letters[random.Value.Next(0, length)];
            ret[25] = letters[random.Value.Next(0, length)];
            ret[26] = letters[random.Value.Next(0, length)];
            ret[27] = letters[random.Value.Next(0, length)];
            ret[28] = letters[random.Value.Next(0, length)];
            ret[29] = letters[random.Value.Next(0, length)];
            ret[30] = letters[random.Value.Next(0, length)];
            ret[31] = letters[random.Value.Next(0, length)];
            return new string(ret);
        }

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

        
        public static class GameObjects {

            public static GameObject LoadGameObject(string path) {

                if (!InitHooks()) { return null; }

                string workPath;
                string dataPath;
                Reader r;
                float mb;
                if (!StartLoad(path, out r, out workPath, out dataPath, out mb)) { return null; }

                OverrideUnserializeType(typeof(Mesh), (reader, type, mesh) => { return MeshExtension.LoadMesh(workPath, reader, type, mesh); });
                OverrideUnserializeType(typeof(RevAudioClip), (reader, type, revAudioClip) => { return RevExtension.LoadRevAudioClip(workPath, false, reader, type, revAudioClip); });

                int prefix;
                int gameObjectCount;
                GameObject[] objs;
                ReadGameObjectHead(r, out prefix, out gameObjectCount, out objs);

                GameObject o = null;
                ReadGameObjectStructureChunk(prefix, r, o, out o, objs, 0, gameObjectCount);

                for (var i = 0; i < gameObjectCount; i++) {
                    int componentCount;
                    Component[] comps;
                    ReadComponentStructureChunk(prefix, r, o, objs, i, 1, out componentCount, out comps);

                    ReadComponentChunk(prefix, r, o, 0, componentCount, componentCount, comps);
                }
                
                if (o != null) { o.SetActive(true); }

                StopLoad(r, workPath);

                return o;
                
            }
            public static bool SaveGameObject(string path, GameObject o) {

                if (o == null) { return false; }

                if (!InitHooks()) { return false; }

                string workPath;
                string dataPath;
                Writer w;
                if (!StartSave(out w, out workPath, out dataPath)) { return false; }

                OverrideSerializeType(typeof(Mesh), (writer, mesh) => { MeshExtension.SaveMesh(writer, workPath, mesh); });
                OverrideSerializeType(typeof(RevAudioClip), (writer, revAudioClip) => { RevExtension.SaveRevAudioClip(writer, workPath, revAudioClip); });

                List<GameObject> children;
                WriteGameObjectHead(w, o, out children);

                WriteGameObjectStructureChunk(w, o, children, 0, children.Count);

                WriteComponentDataChunk(w, o, children, 0, children.Count);

                StopSave(w, workPath, dataPath, path);


                return true;
                
            }

            public static bool StartLoad(string path, out Reader r, out string workPath, out string dataPath, out float mb) {
                workPath = "";
                dataPath = "";
                r = null;
                mb = 0;
                try {
                    if (HBS.Serializer.GameObjects.Unzip(path, out workPath, out dataPath)) {
                        if (File.Exists(dataPath)) {
                            r = new Reader(dataPath);
                            mb = (float)r.stream.Length / 1000000f;
                            return true;
                        }
                    }
                } catch (Exception e) {
                    Debug.LogError(e);
                }
                return false;
            }
            public static bool StartSave(out Writer w, out string workPath, out string dataPath) {
                workPath = "";
                dataPath = "";
                w = null;
                try {
                    workPath = CreateCacheFolder();

                    dataPath = workPath + "/data.txt";

                    w = new Writer();

                    return true;
                } catch (Exception e) {
                    Debug.LogError(e);
                    return false;
                }
            }

            public static void StopLoad(Reader r, string workPath) {
                r.Close();
                DeleteCacheFolder(workPath);
            }
            public static bool StopSave(Writer w, string workPath, string dataPath, string path) {
                try {
                    w.Save(dataPath);

                    w.Close();

                    Zip(workPath, path);

                    DeleteCacheFolder(workPath);

                    return true;
                } catch (Exception e) {
                    Debug.LogError(e);
                    return false;
                }
            }

            public static void ReadGameObjectHead(Reader r, out int prefix, out int gameObjectCount, out GameObject[] objs) {

                prefix = (int)r.Read();
                gameObjectCount = (int)r.Read();
                objs = new GameObject[gameObjectCount];

            }
            public static void WriteGameObjectHead(Writer w, GameObject o, out List<GameObject> children) {

                children = GetChildGameObjects(o);
                children.Insert(0, o);

                w.Write(prefix);
                w.Write(children.Count);
            }

            public static void WriteGameObjectStructureChunk(Writer w, GameObject root, List<GameObject> children, int fromIndex, int length) {

                currentRoot = root;//set current root ( UnserializePath uses this global var ) 

                for (var i = fromIndex; i < fromIndex + length; i++) {
                    var g = children[i];

                    if (g != currentRoot) {
                        SerializePath(w, g.transform.parent);
                    }
                    var components = GetComponents(g);
                    w.Write(components.Count);
                    foreach (var c in components) {
                        w.Write(c.GetType().FullName);
                    }

                }
            }
            public static void WriteComponentDataChunk(Writer w, GameObject root, List<GameObject> children, int fromIndex, int length) {

                currentRoot = root;//set current root ( UnserializePath uses this global var )                             

                if (prefix > 0) {
                    for (var i = fromIndex; i < fromIndex + length; i++) {
                        var g = children[i];

                        Serialize(w, g);
                        var components = GetComponents(g);
                        w.Write(components.Count);
                        foreach (var c in components) {
                            w.Write(c.GetType().FullName);
                            var w2 = new Writer();
                            Serialize(w2, c);
                            w.Write(w2.stream.ToArray());
                            w2.Close();
                        }
                    }
                } else {
                    for (var i = fromIndex; i < fromIndex + length; i++) {
                        var g = children[i];

                        Serialize(w, g);
                        var components = GetComponents(g);
                        w.Write(components.Count);
                        foreach (var c in components) {
                            w.Write(c.GetType().FullName);
                            Serialize(w, c);
                        }
                    }
                }
            }

            public static void ReadGameObjectStructureChunk(int prefix, Reader r, GameObject root, out GameObject outRoot, GameObject[] objs, int fromIndex, int length) {

                outRoot = root;

                currentRoot = root;//set current root ( UnserializePath uses this global var ) 

                for (var i = fromIndex; i < fromIndex + length; i++) {
                    objs[i] = new GameObject("Child" + i.ToString());
                    if (i == 0 && root == null) {
                        root = objs[i];
                        currentRoot = root; //set current root ( UnserializePath uses this global var )
                        outRoot = root;
                        objs[i].SetActive(false);
                        objs[i].transform.parent = root.transform;
                    } else {
                        var parentFromPath = UnserializePath(r);
                        if (parentFromPath != null) {
                            objs[i].transform.SetParent((Transform)parentFromPath);
                        } else {
                            Debug.LogError("coudnt find path for " + objs[i].ToString());
                            objs[i].transform.parent = currentRoot.transform;
                        }
                    }
                    try {
                        var componentCount = (int)r.Read();
                        for (var ii = 0; ii < componentCount; ii++) {
                            var typeName = (string)r.Read();
                            var ctype = Type.GetType(typeName);
                            if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine"); }
                            if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine.UI"); }
                            if (ctype == null) { ctype = Type.GetType(typeName + ",HBNetworking"); }
                            if (ctype != typeof(Transform)) {
                                objs[i].AddComponent(ctype);
                            }
                        }
                    } catch (System.Exception e) {
                        LogWarning(e.ToString());
                    }
                }
            }
            public static void ReadComponentStructureChunk(int prefix, Reader r, GameObject root, GameObject[] objs, int fromIndex, int length, out int componentCount, out Component[] comps) {

                componentCount = 0;
                comps = null;

                currentRoot = root;//set current root ( UnserializePath uses this global var )

                for (var i = fromIndex; i < fromIndex + length; i++) {
                    Unserialize(r, typeof(GameObject), (object)objs[i]);
                    componentCount = (int)r.Read();
                    comps = (Component[])objs[i].GetComponents<Component>();

                }

            }
            public static void ReadComponentChunk(int prefix, Reader r, GameObject root, int fromIndex, int length, int componentCount, Component[] comps) {

                currentRoot = root;//set current root ( UnserializePath uses this global var )       

                if (prefix > 0) {

                    for (var ii = fromIndex; ii < fromIndex + length; ii++) {
                        var typeName = (string)r.Read();
                        var compData = (byte[])r.Read();
                        try {
                            var r2 = new Reader(compData);
                            var ctype = Type.GetType(typeName);
                            if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine"); }
                            if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine.UI"); }
                            if (ctype == null) { ctype = Type.GetType(typeName + ",HBNetworking"); }
                            var c = comps[ii];//objs[i].GetComponent(ctype);

                            Unserialize(r2, ctype, (object)c);
                            r2.Close();
                        } catch (System.Exception e) {
                            LogWarning(e.ToString());
                        }
                    }

                } else {

                    for (var ii = fromIndex; ii < fromIndex + length; ii++) {
                        var typeName = (string)r.Read();
                        var ctype = Type.GetType(typeName);
                        var c = comps[ii];
                        Unserialize(r, ctype, (object)c);
                    }

                }
            }

            public static bool Unzip(string path, out string workPath, out string dataPath) {
                workPath = "";
                dataPath = "";

                //return if path does not exist
                if (File.Exists(path) == false) { return false; }

                //create cache folder
                workPath = CreateCacheFolder();

                //unzip to
                UnzipFolderTo(path, workPath);

                //check if its a vehicle hbp wrap
                if (File.Exists(workPath + "/exported.hbp")) {
                    var c2 = CreateCacheFolder();
                    UnzipFolderTo(workPath + "/exported.hbp", c2);
                    DeleteCacheFolder(workPath);
                    workPath = c2;
                    dataPath = c2 + "/data.txt";
                } else {
                    dataPath = workPath + "/data.txt";
                }

                if (File.Exists(dataPath) == false) { return false; }

                return true;
            }
            public static bool Zip(string workPath, string path) {
                try {
                    ZipFolderTo(workPath, path);
                } catch (System.Exception e) {
                    Debug.LogWarning(e.ToString());
                    return false;
                }
                return true;
            }

            static List<Component> GetComponents(GameObject o) {
                var ret = new List<Component>();
                //only return components that have binders
                var comps = o.GetComponents<Component>();
                foreach (var c in comps) {
                    if (c == null) { continue; }
                    if (SerializerBinder.bindsSer.ContainsKey(c.GetType())) {
                        ret.Add(c);
                    }
                }
                return ret;
            }
            static List<GameObject> GetChildGameObjects(GameObject o) {
                var ret = new List<GameObject>();
                foreach (Transform t in o.transform) {
                    ret.Add(t.gameObject);
                    ret.AddRange(GetChildGameObjects(t.gameObject));
                }
                return ret;
            }

        }
    }

    public class Reader : IDisposable {
        public Stream stream;
        public BinaryReader reader;

        public Reader(string file) {
            stream = File.OpenRead(file);
            reader = new BinaryReader(stream);
        }

        public Reader(byte[] data) {
            stream = new MemoryStream(data);
            reader = new BinaryReader(stream);
        }

        public void Close() {
            Dispose();
        }

        public bool ReadNull() {
            var read = Read();
            if (read != null && (char)read == '<') { return true; }
            return false;
        }

        public object Read() {
            if (reader == null) { return null; }

            int i = reader.ReadInt32();
            if (i == -1) { return null; }
            if (i == 0) {
                return reader.ReadBoolean();
            } else if (i == 1) {
                return reader.ReadInt16();
            } else if (i == 2) {
                return reader.ReadInt32();
            } else if (i == 3) {
                return reader.ReadInt64();
            } else if (i == 4) {
                return reader.ReadUInt16();
            } else if (i == 5) {
                return reader.ReadUInt32();
            } else if (i == 6) {
                return reader.ReadUInt64();
            } else if (i == 7) {
                return reader.ReadSingle();
            } else if (i == 8) {
                return reader.ReadDouble();
            } else if (i == 9) {
                return reader.ReadString();
            } else if (i == 10) {
                return reader.ReadChar();
            } else if (i == 11) {
                return reader.ReadByte();
            } else if (i == 12) {
                int length = reader.ReadInt32();
                return reader.ReadBytes(length);
            }

            return null;
        }

        ~Reader() {
            Dispose();
        }

        public void Dispose() {
            if (reader != null) { reader.Close(); }
            if (stream != null) { stream.Dispose(); }
            GC.SuppressFinalize(this);
        }
    }

    public class Writer : IDisposable {
        public BinaryWriter writer;
        public MemoryStream stream;

        public Writer() {
            stream = new MemoryStream();
            writer = new BinaryWriter(stream);
        }

        public void Save(string file) {
            using (var f = File.OpenWrite(file)) {
                var array = stream.ToArray();
                var length = array.Length;
                var r = f.BeginWrite(array, 0, length, null, null);
                f.EndWrite(r);
            }
        }

        public void Close() {
            Dispose();
        }

        public bool WriteNull(object o) {
            if (o == null || o.ToString() == "null") { Write('<'); return true; } else { Write('>'); }
            return false;
        }
        public void Write(bool o) {
            writer.Write(0);
            writer.Write(o);
        }
        public void Write(Int16 o) {
            writer.Write(1);
            writer.Write(o);
        }
        public void Write(Int32 o) {
            writer.Write(2);
            writer.Write(o);
        }
        public void Write(Int64 o) {
            writer.Write(3);
            writer.Write(o);
        }
        public void Write(UInt16 o) {
            writer.Write(4);
            writer.Write(o);
        }
        public void Write(UInt32 o) {
            writer.Write(5);
            writer.Write(o);
        }
        public void Write(UInt64 o) {
            writer.Write(6);
            writer.Write(o);
        }
        public void Write(float o) {
            writer.Write(7);
            writer.Write(Mathf.Round((o) * 10000f) / 10000f);
        }
        public void Write(double o) {
            writer.Write(8);
            writer.Write(o);
        }
        public void Write(string o) {
            if (string.IsNullOrEmpty(o)) { writer.Write(-1); return; }
            writer.Write(9);
            writer.Write(o);
        }
        public void Write(char o) {
            writer.Write(10);
            writer.Write(o);
        }
        public void Write(byte o) {
            writer.Write(11);
            writer.Write(o);
        }
        public void Write(byte[] o) {
            writer.Write(12);
            writer.Write(o.Length);
            writer.Write(o);
        }
        
        ~Writer() {
            Dispose();
        }

        public void Dispose() {
            if (writer != null) { writer.Close(); }
            if (stream != null) { stream.Dispose(); }
            GC.SuppressFinalize(this);
        }
    }

}