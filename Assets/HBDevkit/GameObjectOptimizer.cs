using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GameObjectOptimizer {

    [MenuItem("Homebrew/Optimize/Selected GameObject")]
    public static void OptimizeSelectedGameObject() {
        Optimize(false);
    }

    [MenuItem("Homebrew/Optimize/Selected GameObject (Cleanup Parts)")]
    public static void OptimizeSelectedGameObjectFull() {
        Optimize(true);
    }

    public static void Optimize(bool cleanupParts) {

        var s = Selection.activeGameObject;

        if (s == null ) {
            Debug.LogError("Optimize: Selection is null");
            return;
        }

        var g = GameObject.Instantiate(s);
        g.name = s.name + "_Optimized";

        var meshRenderers = g.GetComponentsInChildren<MeshRenderer>();
        var combinedMeshRenderers = new Dictionary<int, List<MeshRenderer>>();

        foreach( var mr in meshRenderers ) {
            if( mr.sharedMaterial != null ) {
                var id = mr.sharedMaterial.GetInstanceID();

                if( combinedMeshRenderers.ContainsKey(id) == false ) {
                    combinedMeshRenderers.Add(id, new List<MeshRenderer>());
                }

                combinedMeshRenderers[id].Add(mr);
            }
        }
        
        foreach( var c in combinedMeshRenderers ) {

            if( c.Value == null || c.Value.Count == 0 || c.Value[0] == null ) { continue; }

            var allMeshFilters = new List<MeshFilter>();
            Material material = null;
            string name = null;
            var optimized = new List<GameObject>();
            var tocombine = new List<List<MeshFilter>> {
                new List<MeshFilter>()
            };
            var vc = 0;

            foreach ( var mr in c.Value ) {
                if( mr == null ) { continue; }
                var mf = mr.GetComponent<MeshFilter>();
                if (mf == null || mf.sharedMesh == null || mf.sharedMesh.vertexCount == 0) { continue; }

                allMeshFilters.Add(mf);
                name = mf.sharedMesh.name + "_optimized";                
                material = mr.sharedMaterial;
                optimized.Add(mr.gameObject);

                vc += mf.sharedMesh.triangles.Length * 3;

                if( vc > 64000 ) {
                    tocombine.Add(new List<MeshFilter>());
                    vc = 0;
                } 
                tocombine[tocombine.Count - 1].Add(mf);
                
            }

            foreach( var b in tocombine ) {
                var combine = new CombineInstance[b.ToArray().Length];

                var i = 0;
                while (i < b.Count) {
                    combine[i].mesh = b[i].sharedMesh;
                    combine[i].transform = b[i].transform.localToWorldMatrix;
                    i++;
                }

                var newG = new GameObject(c.Value[0].gameObject.name + "_optimized");
                newG.transform.SetParent(g.transform);
                newG.transform.localPosition = Vector3.zero;
                newG.transform.localEulerAngles = Vector3.zero;

                var newMF = newG.AddComponent<MeshFilter>();
                newMF.sharedMesh = new Mesh() {
                    name = name,
                };
                newMF.sharedMesh.CombineMeshes(combine);

                var newMC = newG.AddComponent<MeshCollider>();
                newMC.sharedMesh = newMF.sharedMesh;

                var newMR = newG.AddComponent<MeshRenderer>();
                newMR.sharedMaterial = material;
            }
           

            foreach( var o in optimized ) {
                GameObject.DestroyImmediate(o, false);
            }

        }

        var transforms = g.GetComponentsInChildren<Transform>();

        foreach( var t in transforms ) {
            if( t == null ) { continue; }
            if (CheckIfUseless(t.gameObject, cleanupParts)) {
                GameObject.DestroyImmediate(t.gameObject);
            }
        }

        s.SetActive(false);

        Debug.Log("optimized");
        Debug.Log("gameobject count from : " + s.GetComponentsInChildren<Transform>().Length + " to: " + g.GetComponentsInChildren<Transform>().Length);
        Debug.Log("component count from : " + s.GetComponentsInChildren<Component>().Length + " to: " + g.GetComponentsInChildren<Component>().Length);
    }
    
    private static List<System.Type> ignore = new List<System.Type>() {
        typeof(Transform),
        typeof(PartContainer),
        typeof(HBBuilder.BodyContainer),
        typeof(HBBuilder.Assembly),
        typeof(HBBuilder.Frame),
        typeof(HBBuilder.Hull),
        typeof(RefrenceID),
        typeof(ScaleRestrictor),
        typeof(HBLink),
        typeof(CoG),
        typeof(CoF),
        typeof(CoB),
        typeof(CoL),
    };
    private static List<System.Type> ignoreIncludingParts = new List<System.Type>() {
        typeof(Transform),
        typeof(PartContainer),
        typeof(HBBuilder.BodyContainer),
        typeof(HBBuilder.Assembly),
        typeof(HBBuilder.Frame),
        typeof(HBBuilder.Hull),
        typeof(RefrenceID),
        typeof(ScaleRestrictor),
        typeof(HBLink),
        typeof(CoG),
        typeof(CoF),
        typeof(CoB),
        typeof(CoL),
        typeof(Part),
    };

    public static bool CheckIfUseless(GameObject o,bool cleanupParts) {
        if( o == null ) { return true; }
        var comps = o.GetComponentsInChildren<Component>();
        
        var cc = 0;
        foreach( var c in comps ) {
            if(cleanupParts) {
                if (ignoreIncludingParts.Contains(c.GetType()) || ignoreIncludingParts.Contains(c.GetType().BaseType)) { continue; }
            } else {
                if (ignore.Contains(c.GetType()) || ignore.Contains(c.GetType().BaseType)) { continue; }
            }
            cc++;
        }
        return cc == 0;
    }
    
}
