#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
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

        [MenuItem("Homebrew/Asset/Import/Part")]
        public static void ImportGameObject() {
            string path = UnityEditor.EditorUtility.OpenFilePanel("open part", Application.streamingAssetsPath + "/Assets/GameObjects/", "hbp");
            if (path == "") { return; }
            GameObject o = AssetManager.InstantiateAsset(path);
            o.transform.position = Vector3.zero;
            o.transform.rotation = Quaternion.identity;

        }
        [MenuItem("Homebrew/Asset/Export Selected/Part")]
        public static void ExportGameObject() {
            if (UnityEditor.Selection.gameObjects.Length == 0) { return; }
            string path = UnityEditor.EditorUtility.SaveFilePanel("save part", Application.streamingAssetsPath + "/Assets/GameObjects/", "untitled", "hbp");
            if (path == "") { return; }
            AssetManager.SaveAsset(path, "Part", UnityEditor.Selection.activeGameObject);

        }
    }
}

#endif