using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

#if UNITY_EDITOR
#endif

namespace HBS {

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct)] //wills erialize this class properly
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
        public static MethodInfo serializeMethod;
        public static MethodInfo unserializeMethod;
        public static GameObject currentRoot;
        public static Dictionary<Type, Action<Writer, object>> specialCaseSerializers = new Dictionary<Type, Action<Writer, object>>();
        public static Dictionary<Type, Func<Reader, Type, object, object>> specialCaseUnserializers = new Dictionary<Type, Func<Reader, Type, object, object>>();

        public static void LoadExtensions() {
            specialCaseSerializers.Clear();
            specialCaseUnserializers.Clear();
            specialCaseSerializers.Add(typeof(Mesh), new Action<Writer, object>(MeshExtension.SaveMesh));
            specialCaseUnserializers.Add(typeof(Mesh), new Func<Reader, Type, object, object>(MeshExtension.LoadMesh));
            //specialCaseSerializers.Add(typeof(HBWorld.TerrainTile), new Action<Writer, object>(TerrainTileExtension.SaveTerrainTile));
            //specialCaseUnserializers.Add(typeof(HBWorld.TerrainTile), new Func<Reader, Type, object, object>(TerrainTileExtension.LoadTerrainTile));
        }

        public static void SaveGameObject(string path, GameObject gameObject) {

           
            if (serializeMethod == null || unserializeMethod == null) {
                HookToSerializeMethods();
            }
            if (serializeMethod == null || unserializeMethod == null) { return; }
            
            Writer w = new Writer();
            currentRoot = gameObject;
            List<GameObject> children = GetChildGameObjects(gameObject);
            children.Insert(0, currentRoot);
            w.Write(prefix);
            if( prefix > 0 ) {
                #region save gameobject v1
                w.Write(children.Count);
                foreach (GameObject g in children) {
                    if (g != currentRoot) {
                        SerializePath(w, g.transform.parent);
                    }
                    List<Component> components = GetComponents(g);
                    w.Write(components.Count);
                    foreach (Component c in components) {
                        w.Write(c.GetType().FullName);
                    }
                }

                foreach (GameObject g in children) {
                    Serialize(w, g);
                    List<Component> components = GetComponents(g);
                    w.Write(components.Count);
                    int i = 0;
                    foreach (Component c in components) {
                        w.Write(c.GetType().FullName);
                        Writer w2 = new Writer();
                        Serialize(w2, c);
                        w.Write(w2.stream.ToArray());
                        w2.Close();
                        i++;
                    }
                }
                #endregion
            } else {
                #region save gameobject v0
                w.Write(children.Count);
                foreach (GameObject g in children) {
                    if (g != currentRoot) {
                        SerializePath(w, g.transform.parent);
                    }
                    List<Component> components = GetComponents(g);
                    w.Write(components.Count);
                    foreach (Component c in components) {
                        w.Write(c.GetType().FullName);
                    }
                }

                foreach (GameObject g in children) {
                    Serialize(w, g);
                    List<Component> components = GetComponents(g);
                    w.Write(components.Count);
                    int i = 0;
                    foreach (Component c in components) {
                        w.Write(c.GetType().FullName);
                        Serialize(w, c);
                        i++;
                    }
                }
                
                #endregion
            }


            w.Save(path);
            w.Close();

        }

        public static bool CheckWait(int speed , ref int cc ) {
            cc++;
            return cc % Mathf.Max(1,speed) == 0;
        }

        static void PostProgress(System.Action<float> onProgress, float f) {
            if (onProgress != null) {
                onProgress(f);
            }
        }

        public static void LogWarning(object o) {
            if( debug ) {
                Debug.LogWarning(o);
            }
        }

        public static IEnumerator LoadGameObjectAsync(string path, int speed, System.Action<GameObject> ret , System.Action<float> onProgress) {

            PostProgress(onProgress, 0);

            var cc = 0;

            if (serializeMethod == null || unserializeMethod == null) {
                HookToSerializeMethods();
            }
            if (serializeMethod == null || unserializeMethod == null) { yield break; }
            if (File.Exists(path) == false) { yield break; }

            Reader r = new Reader(path);
            int prefix = (int)r.Read();
            if (prefix > 0) {
                #region load gameobject v1
                int gameObjectCount = (int)r.Read();
                GameObject[] objs = new GameObject[gameObjectCount];
                for (int i = 0; i < gameObjectCount; i++) {

                    PostProgress(onProgress, (float)i/ (float)gameObjectCount * 0.5f);

                    if ( CheckWait(speed*2,ref cc) ) {
                        yield return new WaitForEndOfFrame();
                    }

                    objs[i] = new GameObject("Child" + i.ToString());
                    if (i == 0) {
                        currentRoot = objs[i];
                        objs[i].SetActive(false);
                        objs[i].transform.parent = currentRoot.transform;
                    } else {
                        object parentFromPath = UnserializePath(r);
                        if (parentFromPath != null) {
                            objs[i].transform.SetParent((Transform)parentFromPath);
                        } else {
                            Debug.LogError("coudnt find path for " + objs[i].ToString());
                            objs[i].transform.parent = currentRoot.transform;
                        }
                    }
                    int componentCount = (int)r.Read();
                    for (int ii = 0; ii < componentCount; ii++) {

                        if (CheckWait(speed*2, ref cc)) {
                            yield return new WaitForEndOfFrame();
                        }

                        string typeName = (string)r.Read();
                        Type ctype = Type.GetType(typeName);
                        if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine"); }
                        if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine.UI"); }
                        if (ctype == null) { ctype = Type.GetType(typeName + ",HBNetworking"); }
                        if (ctype != typeof(Transform)) {
                            objs[i].AddComponent(ctype);
                        }
                    }
                }
                
                for (int i = 0; i < gameObjectCount; i++) {

                    PostProgress(onProgress, 0.5f + ((float)i / (float)gameObjectCount * 0.5f));

                    if (CheckWait(speed, ref cc)) {
                        yield return new WaitForEndOfFrame();
                    }
                    int componentCount = 0;
                    Component[] comps = new Component[0];
                    try { 
                        Unserialize(r, typeof(GameObject), (object)objs[i]);
                        componentCount = (int)r.Read();
                        comps = objs[i].GetComponents<Component>();
                    } catch (Exception e) {
                        LogWarning(e.ToString());
                    }
                    for (int ii = 0; ii < componentCount; ii++) {

                        if (CheckWait(speed, ref cc)) {
                            yield return new WaitForEndOfFrame();
                        }

                        string typeName = (string)r.Read();
                        byte[] compData = (byte[])r.Read();
                        try {
                            Reader r2 = new Reader(compData);
                            Type ctype = Type.GetType(typeName);
                            if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine"); }
                            if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine.UI"); }
                            if (ctype == null) { ctype = Type.GetType(typeName + ",HBNetworking"); }
                            Component c = comps[ii];//objs[i].GetComponent(ctype);

                            Unserialize(r2, ctype, (object)c);
                            r2.Close();
                        } catch (System.Exception e) {
                            LogWarning(e.ToString());
                        }
                    }
                }

                #endregion
            } else {
                #region load gameobject v0
                int gameObjectCount = (int)r.Read();
                GameObject[] objs = new GameObject[gameObjectCount];
                for (int i = 0; i < gameObjectCount; i++) {

                    PostProgress(onProgress, (float)i / (float)gameObjectCount * 0.5f);

                    if (CheckWait(speed, ref cc)) {
                        yield return new WaitForEndOfFrame();
                    }

                    objs[i] = new GameObject("Child" + i.ToString());
                    if (i == 0) {
                        currentRoot = objs[i];
                        objs[i].SetActive(false);
                        objs[i].transform.parent = currentRoot.transform;
                    } else {
                        object parentFromPath = UnserializePath(r);
                        if (parentFromPath != null) {
                            objs[i].transform.SetParent((Transform)parentFromPath);
                        } else {
                            Debug.LogError("coudnt find path for " + objs[i].ToString());
                            objs[i].transform.parent = currentRoot.transform;
                        }
                    }
                    int componentCount = (int)r.Read();
                    for (int ii = 0; ii < componentCount; ii++) {

                        if (CheckWait(speed, ref cc)) {
                            yield return new WaitForEndOfFrame();
                        }

                        string typeName = (string)r.Read();
                        Type ctype = Type.GetType(typeName);
                        if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine"); }
                        if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine.UI"); }
                        if (ctype == null) { ctype = Type.GetType(typeName + ",HBNetworking"); }
                        if (ctype != typeof(Transform)) {
                            objs[i].AddComponent(ctype);
                        }
                    }
                }
                for (int i = 0; i < gameObjectCount; i++) {

                    PostProgress(onProgress, 0.5f + ((float)i / (float)gameObjectCount * 0.5f));

                    if (CheckWait(speed, ref cc)) {
                        yield return new WaitForEndOfFrame();
                    }
                    int componentCount = 0;
                    Component[] comps = new Component[0];
                    try {
                        Unserialize(r, typeof(GameObject), (object)objs[i]);
                        componentCount = (int)r.Read();
                        comps = objs[i].GetComponents<Component>();
                    } catch (Exception e) {
                        LogWarning(e.ToString());
                    }
                    for (int ii = 0; ii < componentCount; ii++) {

                        if (CheckWait(speed, ref cc)) {
                            yield return new WaitForEndOfFrame();
                        }
                        
                        try {
                            string typeName = (string)r.Read();
                            Type ctype = Type.GetType(typeName);
                            Component c = comps[ii];
                            Unserialize(r, ctype, (object)c);

                        } catch(Exception e) {
                            LogWarning(e.ToString());
                        }
                    }
                    
                }
                #endregion
            }

            r.Close();

            PostProgress(onProgress, 1);
            ret(currentRoot);

            yield break;

        }

        public static GameObject LoadGameObject(string path) {

            if (serializeMethod == null || unserializeMethod == null) {
                HookToSerializeMethods();
            }
            if (serializeMethod == null || unserializeMethod == null) { return null; }
            if (File.Exists(path) == false) { return null; }
            
            Reader r = new Reader(path);
            try {
                int prefix = (int)r.Read();
                if( prefix > 0 ) {
                    #region load gameobject v1
                    int gameObjectCount = (int)r.Read();
                    GameObject[] objs = new GameObject[gameObjectCount];
                    for (int i = 0; i < gameObjectCount; i++) {
                        objs[i] = new GameObject("Child" + i.ToString());
                        if (i == 0) {
                            currentRoot = objs[i];
                            objs[i].SetActive(false);
                            objs[i].transform.parent = currentRoot.transform;
                        } else {
                            object parentFromPath = UnserializePath(r);
                            if (parentFromPath != null) {
                                objs[i].transform.SetParent((Transform)parentFromPath);
                            } else {
                                Debug.LogError("coudnt find path for " + objs[i].ToString());
                                objs[i].transform.parent = currentRoot.transform;
                            }
                        }
                        try {
                            int componentCount = (int)r.Read();
                            for (int ii = 0; ii < componentCount; ii++) {
                                string typeName = (string)r.Read();
                                Type ctype = Type.GetType(typeName);
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
                    for (int i = 0; i < gameObjectCount; i++) {
                        try {
                            Unserialize(r, typeof(GameObject), (object)objs[i]);
                            int componentCount = (int)r.Read();
                            Component[] comps = objs[i].GetComponents<Component>();
                            for (int ii = 0; ii < componentCount; ii++) {
                                string typeName = (string)r.Read();
                                byte[] compData = (byte[])r.Read();
                                try {
                                    Reader r2 = new Reader(compData);
                                    Type ctype = Type.GetType(typeName);
                                    if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine"); }
                                    if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine.UI"); }
                                    if (ctype == null) { ctype = Type.GetType(typeName + ",HBNetworking"); }
                                    Component c = comps[ii];//objs[i].GetComponent(ctype);
                                    
                                    Unserialize(r2, ctype, (object)c);
                                    r2.Close();
                                } catch(System.Exception e) {
                                    LogWarning(e.ToString());
                                }
                            }
                        } catch (System.Exception e) {
                            LogWarning(e.ToString());
                        }
                    }

                    #endregion
                } else {
                    #region load gameobject v0
                    int gameObjectCount = (int)r.Read();
                    GameObject[] objs = new GameObject[gameObjectCount];
                    for (int i = 0; i < gameObjectCount; i++) {
                        objs[i] = new GameObject("Child" + i.ToString());
                        if (i == 0) {
                            currentRoot = objs[i];
                            objs[i].SetActive(false);
                            objs[i].transform.parent = currentRoot.transform;
                        } else {
                            object parentFromPath = UnserializePath(r);
                            if (parentFromPath != null) {
                                objs[i].transform.SetParent((Transform)parentFromPath);
                            } else {
                                Debug.LogError("coudnt find path for " + objs[i].ToString());
                                objs[i].transform.parent = currentRoot.transform;
                            }
                        }
                        try {
                            int componentCount = (int)r.Read();
                            for (int ii = 0; ii < componentCount; ii++) {
                                string typeName = (string)r.Read();
                                Type ctype = Type.GetType(typeName);
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
                    for (int i = 0; i < gameObjectCount; i++) {
                        try {
                            Unserialize(r, typeof(GameObject), (object)objs[i]);
                            int componentCount = (int)r.Read();
                            Component[] comps = objs[i].GetComponents<Component>();
                            for (int ii = 0; ii < componentCount; ii++) {
                                string typeName = (string)r.Read();
                                Type ctype = Type.GetType(typeName);
                                Component c = comps[ii];
                                Unserialize(r, ctype, (object)c);
                            }
                        } catch (System.Exception e) {
                            LogWarning(e.ToString());
                        }
                    }
                    #endregion
                }
            } catch (System.Exception e) {
                LogWarning(e.ToString());
            } finally {
            r.Close();
            }
            return currentRoot;
        }
        /*  upgraded to mores stable method using prefix change
        public static void SaveGameObject(string path, GameObject gameObject) {

           
            if (serializeMethod == null || unserializeMethod == null) {
                HookToSerializeMethods();
            }
            if (serializeMethod == null || unserializeMethod == null) { return; }
            
            Writer w = new Writer();
            currentRoot = gameObject;
            List<GameObject> children = GetChildGameObjects(gameObject);
            children.Insert(0, currentRoot);
            w.Write(prefix);
            w.Write(children.Count);
            foreach (GameObject g in children) {
                if (g != currentRoot) {
                    SerializePath(w, g.transform.parent);
                }
                List<Component> components = GetComponents(g);
                w.Write(components.Count);
                foreach (Component c in components) {
                    w.Write(c.GetType().FullName);
                }
            }
            
            foreach (GameObject g in children) {
                Serialize(w, g);
                List<Component> components = GetComponents(g);
                w.Write(components.Count);
                int i = 0;
                foreach (Component c in components) {
                    w.Write(c.GetType().FullName);
                    Serialize(w, c);
                    i++;
                }
            }
            
            w.Save(path);
            w.Close();
        }

        public static GameObject LoadGameObject(string path) {

            if (serializeMethod == null || unserializeMethod == null) {
                HookToSerializeMethods();
            }
            if (serializeMethod == null || unserializeMethod == null) { return null; }
            if (File.Exists(path) == false) { return null; }
            
            Reader r = new Reader(path);
            try {
                int prefix = (int)r.Read();
                int gameObjectCount = (int)r.Read();
                GameObject[] objs = new GameObject[gameObjectCount];
                for (int i = 0; i < gameObjectCount; i++) {
                    objs[i] = new GameObject("Child" + i.ToString());
                    if (i == 0) {
                        currentRoot = objs[i];
                        objs[i].SetActive(false);
                        objs[i].transform.parent = currentRoot.transform;
                    } else {
                        object parentFromPath = UnserializePath(r);
                        if (parentFromPath != null) {
                            objs[i].transform.SetParent((Transform)parentFromPath);
                        } else {
                            Debug.LogError("coudnt find path for " + objs[i].ToString());
                            objs[i].transform.parent = currentRoot.transform;
                        }
                    }
                    try {
                        int componentCount = (int)r.Read();
                        for (int ii = 0; ii < componentCount; ii++) {
                            string typeName = (string)r.Read();
                            Type ctype = Type.GetType(typeName);
                            if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine"); }
                            if (ctype == null) { ctype = Type.GetType(typeName + ",UnityEngine.UI"); }
                            if (ctype == null) { ctype = Type.GetType(typeName + ",HBNetworking"); }
                            if (ctype != typeof(Transform)) {
                                objs[i].AddComponent(ctype);
                            }
                        }
                    } catch (System.Exception e) {
                        Debug.LogWarning(e.ToString());
                    }
                }
                for (int i = 0; i < gameObjectCount; i++) {
                    try {
                        Unserialize(r, typeof(GameObject), (object)objs[i]);
                        int componentCount = (int)r.Read();
                        Component[] comps = objs[i].GetComponents<Component>();
                        for (int ii = 0; ii < componentCount; ii++) {
                            string typeName = (string)r.Read();
                            Type ctype = Type.GetType(typeName);
                            Component c = comps[ii];
                            Unserialize(r, ctype, (object)c);
                        }
                    } catch (System.Exception e) {
                        Debug.LogWarning(e.ToString());
                    }
                }
            } catch (System.Exception e) {
                Debug.LogWarning(e.ToString());
            }
            r.Close();
            return currentRoot;
        }*/

        public static void ZipFolderTo(string p, string t) {
            try {
                DirectoryInfo dir = new DirectoryInfo(p);
                FileInfo[] fs = dir.GetFiles();
                string[] files = new string[fs.Length];
                int cc = 0;
                foreach (FileInfo f in fs) {
                    files[cc] = f.FullName;
                    cc++;
                }
                ZipUtil.Zip(t, files);
            } catch (System.Exception e) {
                Debug.LogWarning(e.ToString());
            }
        }

        public static void UnzipFolderTo(string p, string t) {
            try {
                ZipUtil.Unzip(p, t);
            } catch (System.Exception e) {
                Debug.LogWarning(e.ToString());
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

        private static List<Component> GetComponents(GameObject o) {
            List<Component> ret = new List<Component>();
            //only return components that have binders
            Component[] comps = o.GetComponents<Component>();
            foreach (Component c in comps) {
                if (c == null) { continue; }
                if (SerializerBinder.bindsSer.ContainsKey(c.GetType())) {
                    ret.Add(c);
                }
            }
            return ret;
        }

        private static List<GameObject> GetChildGameObjects(GameObject o) {
            List<GameObject> ret = new List<GameObject>();
            foreach (Transform t in o.transform) {
                ret.Add(t.gameObject);
                ret.AddRange(GetChildGameObjects(t.gameObject));
            }
            return ret;
        }
    }

    public class Reader : IDisposable {
        public Stream stream;
        public BinaryReader reader;

        public Reader(string file) {
            stream = File.OpenRead(file);
            //stream = new MemoryStream(File.ReadAllBytes(file));
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
            if(read != null && (char)read == '<') { return true; }
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
            //File.WriteAllBytes(file, stream.ToArray());
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

        /*
        public void Write(object o) {
            if (o == null) {
                writer.Write(-1);
                return;
            }
            Type t = o.GetType();
            if (t == typeof(bool)) {
                writer.Write(0);
                writer.Write((bool)o);
            } else if (t == typeof(Int16)) {
                writer.Write(1);
                writer.Write((Int16)o);
            } else if (t == typeof(Int32)) {
                writer.Write(2);
                writer.Write((Int32)o);
            } else if (t == typeof(Int64)) {
                writer.Write(3);
                writer.Write((Int64)o);
            } else if (t == typeof(UInt16)) {
                writer.Write(4);
                writer.Write((UInt16)o);
            } else if (t == typeof(UInt32)) {
                writer.Write(5);
                writer.Write((UInt32)o);
            } else if (t == typeof(UInt64)) {
                writer.Write(6);
                writer.Write((UInt64)o);
            } else if (t == typeof(float)) {
                writer.Write(7);
                writer.Write(Mathf.Round(((float)o) * 10000f) / 10000f);
            } else if (t == typeof(double)) {
                writer.Write(8);
                writer.Write((double)o);
            } else if (t == typeof(string)) {
                writer.Write(9);
                writer.Write((string)o);
            } else if (t == typeof(char)) {
                writer.Write(10);
                writer.Write((char)o);
            } else if (t == typeof(byte)) {
                writer.Write(11);
                writer.Write((byte)o);
            } else if (t == typeof(byte[])) {
                writer.Write(12);
                writer.Write(((byte[])o).Length);
                writer.Write((byte[])o);
            } else {
                writer.Write(-1);
            }
        }
        */
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