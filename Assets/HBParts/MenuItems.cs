#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System;

namespace HBWorld {
    public static class MenuItems {

        static GameObject[] GetRootsFromSelection() {
            List<GameObject> selection = new List<GameObject>();
            foreach (GameObject s in Selection.gameObjects) {
                selection.Add(s);
            }
            List<GameObject> final = new List<GameObject>();
            foreach (GameObject s in selection) {
                Transform p = s.transform.parent;
                bool parentfound = false;
                while (p != null) {
                    if (selection.Contains(p.gameObject)) {
                        parentfound = true;
                        break;
                    }
                    p = p.parent;
                }
                if (parentfound == false) {
                    final.Add(s);
                }
            }
            return final.ToArray();
        }

        [MenuItem("Homebrew/Asset/Import/HBP")]
        public static void ImportGameObject() {
            string path = UnityEditor.EditorUtility.OpenFilePanel("open part", Application.streamingAssetsPath + "/Assets/GameObjects/", "hbp");
            if (path == "") { return; }
            GameObject o = HBS.AssetManager.GameSpecifics.Instantiate(path);
            o.transform.position = Vector3.zero;
            o.transform.rotation = Quaternion.identity;

        }
        [MenuItem("Homebrew/Asset/Export Selected/Part")]
        public static void ExportGameObject() {
            if (UnityEditor.Selection.gameObjects.Length == 0) { Debug.LogError("Nothing selected"); return; }
            var part = UnityEditor.Selection.gameObjects[0].GetComponentInChildren<PartContainer>();
            if (part == null) { Debug.LogError("no PartContainerin selection"); return; }
            string path = UnityEditor.EditorUtility.SaveFilePanel("save part", Application.streamingAssetsPath + "/Assets/GameObjects/", "untitled", "hbp");
            if (path == "") { return; }
            HBS.AssetManager.GameSpecifics.Save(path, "Part", UnityEditor.Selection.activeGameObject);

        }
        [MenuItem("Homebrew/Asset/Export Selected/EngineAudio")]
        public static void ExportRev() {
            if (UnityEditor.Selection.gameObjects.Length == 0) { Debug.LogError("Nothing selected"); return; }
            var engineAudioClip = UnityEditor.Selection.gameObjects[0].GetComponentInChildren<EngineAudioClip>();
            if (engineAudioClip == null) { Debug.LogError("no engine audio clip in selection"); return; }
            if(EditorApplication.isPlaying == false) { Debug.LogError("must export while in play mode"); return; }
            engineAudioClip.BakeAudioClips();
            var assetPath = UnityEditor.EditorUtility.SaveFilePanel("save engine audio", Application.streamingAssetsPath + "/Assets/GameObjects/", "untitled", "hbp");
            if (assetPath == "") { return; }
            HBS.AssetManager.GameSpecifics.Save(assetPath, "EngineAudio", UnityEditor.Selection.activeGameObject);
        }
        [MenuItem("Homebrew/Asset/Export Selected/World")]
        public static void ExportWorldAsset() {
            if (UnityEditor.Selection.gameObjects.Length == 0) { return; }
            var assetPath = UnityEditor.EditorUtility.SaveFilePanel("save world asset", Application.streamingAssetsPath + "/Assets/GameObjects/", "untitled", "hbp");
            if (assetPath == "") { return; }
            HBS.AssetManager.GameSpecifics.Save(assetPath, "WorldAsset", UnityEditor.Selection.activeGameObject);

            var name = System.IO.Path.GetFileNameWithoutExtension(assetPath);
            var position = UnityEditor.Selection.activeGameObject.transform.position;
            var eulerAngles = UnityEditor.Selection.activeGameObject.transform.eulerAngles;
            var scale = UnityEditor.Selection.activeGameObject.transform.localScale;
            var x = (double)position.x;
            var y = (double)position.y;
            var z = (double)position.z;
            var rx = eulerAngles.x;
            var ry = eulerAngles.y;
            var rz = eulerAngles.z;
            var sx = scale.x;
            var sy = scale.y;
            var sz = scale.z;
            var size = GetGameObjectBounds(UnityEditor.Selection.activeGameObject).size;
            var objectSize = Mathf.Max(size.x, size.y, size.z);

            var range = (double)GetLOD2Range(objectSize * 0.5f) + sectorSize * 0.5d;
            var id = GetNewID();//create new pin id

            //update meta file next to asset
            var metaPath = GetMetaPath(assetPath);

            CreatMetaFile(name, id, x, y, z, rx, ry, rz, sx, sy, sz, objectSize, range, metaPath, "pinned from devkit");

        }

        public static double sectorSize { get { return 6000d; } }

        static string GetMetaPath(string p) {
            if (string.IsNullOrEmpty(p)) {
                return "";
            }
            return WashPath(Path.GetDirectoryName(p) + "/" + Path.GetFileNameWithoutExtension(p) + ".hbm");
        }

        public static string WashPath(string path) {
            if (string.IsNullOrEmpty(path)) { return ""; }
            return Regex.Replace(path, "[\\\\/][\\\\/]*", "/");
        }

        static void CreatMetaFile(string name, string id, double x, double y, double z, float rx, float ry, float rz, float sx, float sy, float sz, float objectSize, double range, string path, string pinpointAttributes) {
            XElement hbm = new XElement("HBMETA");
            hbm.Add(new XElement("Name", name));
            hbm.Add(new XElement("Type", "WorldAssetBundle"));
            XElement worldTag = new XElement("World");
            worldTag.SetAttributeValue("id", id);
            worldTag.SetAttributeValue("x", x.ToString());
            worldTag.SetAttributeValue("y", y.ToString());
            worldTag.SetAttributeValue("z", z.ToString());

            worldTag.SetAttributeValue("rx", rx.ToString());
            worldTag.SetAttributeValue("ry", ry.ToString());
            worldTag.SetAttributeValue("rz", rz.ToString());

            worldTag.SetAttributeValue("sx", sx.ToString());
            worldTag.SetAttributeValue("sy", sy.ToString());
            worldTag.SetAttributeValue("sz", sz.ToString());

            worldTag.SetAttributeValue("objectSize", objectSize.ToString());

            worldTag.SetAttributeValue("range", range.ToString());
            worldTag.SetAttributeValue("data", pinpointAttributes);
            hbm.Add(worldTag);
            hbm.Save(path);
        }
        static void AddToMetaFile(string name, string id, double x, double y, double z, float rx, float ry, float rz, float sx, float sy, float sz, float objectSize, double range, string path, string pinpointAttributes) {

            XElement hbm = XElement.Load(path);
            if (hbm.Element("Name") == null) {
                hbm.Add(new XElement("Name", name));
            }
            if (hbm.Element("Type") == null) {
                hbm.Add(new XElement("Type", "WorldAssetBundle"));
            }
            XElement worldTag = new XElement("World");
            worldTag.SetAttributeValue("id", id);
            worldTag.SetAttributeValue("x", x.ToString());
            worldTag.SetAttributeValue("y", y.ToString());
            worldTag.SetAttributeValue("z", z.ToString());

            worldTag.SetAttributeValue("rx", rx.ToString());
            worldTag.SetAttributeValue("ry", ry.ToString());
            worldTag.SetAttributeValue("rz", rz.ToString());

            worldTag.SetAttributeValue("sx", sx.ToString());
            worldTag.SetAttributeValue("sy", sy.ToString());
            worldTag.SetAttributeValue("sz", sz.ToString());

            worldTag.SetAttributeValue("objectSize", objectSize.ToString());

            worldTag.SetAttributeValue("range", range.ToString());
            worldTag.SetAttributeValue("data", pinpointAttributes);
            hbm.Add(worldTag);
            hbm.Save(path);
        }

        public static float GetLOD0Range(float range) {
            return Mathf.Min(range * 5f, 5000f);
        }
        public static float GetLOD1Range(float range) {
            return Mathf.Min((range * 5f) * 5f, 5000f); ;
        }
        public static float GetLOD2Range(float range) {
            return Mathf.Min((range * 5f) * 5f * 5f, 10000f);
        }

        public static char[] letters = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private static int seed {
            get {
                return Environment.TickCount * Thread.CurrentThread.ManagedThreadId;
            }
        }
        private static readonly ThreadLocal<System.Random> random = new ThreadLocal<System.Random>(() => new System.Random(seed));
        public static string GetNewID() {
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

        public static Bounds GetGameObjectBounds(GameObject obj) {

            //create a bounds to return 
            Bounds ret = new Bounds(Vector3.zero, Vector3.zero);

            //if obj passed is null return a zero,zero bounds
            if (obj == null) { return ret; }

            //get all mesh filters , mesh filters return a local bounds
            MeshFilter[] allMeshFilters = obj.GetComponentsInChildren<MeshFilter>();
            SkinnedMeshRenderer[] allSkinnedMeshRenderers = obj.GetComponentsInChildren<SkinnedMeshRenderer>();


            Vector3 aa = new Vector3(99999999, 99999999, 99999999);
            Vector3 bb = new Vector3(-99999999, -99999999, -99999999);
            bool used = false;

            //itterate all meshfilters
            foreach (MeshFilter f in allMeshFilters) {

                //if it has no mesh skip it
                if (f.sharedMesh == null) { continue; }

                Vector3[] verts = f.sharedMesh.vertices;
                foreach (Vector3 v in verts) {
                    Vector3 p = obj.transform.InverseTransformPoint(f.transform.TransformPoint(v));
                    aa.x = Mathf.Min(aa.x, p.x);
                    aa.y = Mathf.Min(aa.y, p.y);
                    aa.z = Mathf.Min(aa.z, p.z);
                    bb.x = Mathf.Max(bb.x, p.x);
                    bb.y = Mathf.Max(bb.y, p.y);
                    bb.z = Mathf.Max(bb.z, p.z);
                    used = true;
                }
            }

            foreach (SkinnedMeshRenderer f in allSkinnedMeshRenderers) {

                //if it has no mesh skip it
                if (f.sharedMesh == null) { continue; }

                Mesh m = GetSkinnedMesh(f);

                Vector3[] verts = m.vertices;
                foreach (Vector3 v in verts) {
                    Vector3 p = obj.transform.InverseTransformPoint(f.transform.TransformPoint(v));
                    aa.x = Mathf.Min(aa.x, p.x);
                    aa.y = Mathf.Min(aa.y, p.y);
                    aa.z = Mathf.Min(aa.z, p.z);
                    bb.x = Mathf.Max(bb.x, p.x);
                    bb.y = Mathf.Max(bb.y, p.y);
                    bb.z = Mathf.Max(bb.z, p.z);
                    used = true;
                }

                GameObject.Destroy(m);
            }

            ret = new Bounds((bb + aa) * 0.5f, (bb - aa));

            if (float.IsNaN(ret.size.x) || float.IsNaN(ret.size.y) || float.IsNaN(ret.size.z)) {
                ret.size = Vector3.one * 0.001f;
            }

            if (!used) {
                return new Bounds(Vector3.zero, Vector3.one * 0.0001f);
            }

            return ret;
        }

        public static Mesh GetSkinnedMesh(SkinnedMeshRenderer r) {
            if (r == null || r.sharedMesh == null) { return null; }
            Mesh m = new Mesh();
            r.BakeMesh(m);
            Vector3 scale = r.transform.lossyScale;
            scale.x = 1f / scale.x; scale.y = 1f / scale.y; scale.z = 1f / scale.z;
            Vector3[] verts = m.vertices;
            for (int i = 0; i < m.vertexCount; i++) {
                verts[i] = Vector3.Scale(verts[i], scale);
            }
            m.vertices = verts;
            m.name = r.sharedMesh.name;
            return m;
        }
    }
}


#endif