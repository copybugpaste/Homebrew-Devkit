using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public static class TerrainUtils {

    public static void ImportTerrain(string heightFile, string colorFile, string splatFile, string normalMapFile, string lodMeshFile, Terrain terrain) {
        Raw32ToTerrain(heightFile, terrain);
        ColorToTerrain(colorFile, terrain);
        SplatToTerrain(splatFile, terrain);
        NormalMapToTerrain(normalMapFile, terrain);
        //LODMeshToTerrain(lodMeshFile, terrain);
    }

    public static void ExportTerrain(Terrain terrain, string heightFile, string colorFile, string splatFile, string normalMapFile, string lodMeshFile) {
        TerrainToRaw32(terrain,heightFile);
        TerrainToColor(terrain,colorFile);
        TerrainToSplat(terrain,splatFile);
        TerrainToNormalMap(terrain, normalMapFile);
        TerrainToLODMesh(terrain, lodMeshFile);           
    }

    //public static bool LODMeshToTerrain(string file, Terrain terrain) {
    //    if (terrain == null) { Debug.LogError("TerrainUtils.LODMeshToTerrain terrain is null"); return false; }
    //    if (string.IsNullOrEmpty(file)) { Debug.LogError("TerrainUtils.LODMeshToTerrain filename was null or empty"); return false; }
    //    if (File.Exists(file) == false) { Debug.LogError("TerrainUtils.LODMeshToTerrain file doesnt exist @" + file); return false; }
    //    Mesh m = null;
    //    try {
    //        m = ObjImporter.Import(file);
    //    } catch(Exception e) {
    //        Debug.LogError(e.ToString());
    //    }
    //    if (m == null) { Debug.LogError("TerrainUtils.LODMeshToTerrain failed to load mesh"); }
    //    m.name = Path.GetFileNameWithoutExtension(file);
    //    NormalizeMesh(m, false);
    //    Vector3 terSize = terrain.terrainData.size;
    //    TransformMesh(m, Matrix4x4.TRS(terSize * 0.5f, Quaternion.identity,terSize));
    //    m.RecalculateBounds();
    //    if (terrain.GetComponent<MeshFilter>() == null) { terrain.gameObject.AddComponent<MeshFilter>(); }
    //    if (terrain.GetComponent<MeshRenderer>() == null) { terrain.gameObject.AddComponent<MeshRenderer>(); }
    //    if (terrain.GetComponent<UnityTerrainLOD>() == null) { terrain.gameObject.AddComponent<UnityTerrainLOD>(); }
    //    MeshFilter mf = terrain.GetComponent<MeshFilter>();
    //    mf.sharedMesh = m;
    //    MeshRenderer mr = terrain.GetComponent<MeshRenderer>();
    //    mr.sharedMaterial = terrain.materialTemplate;
    //    UnityTerrainLOD tl = terrain.GetComponent<UnityTerrainLOD>();
    //    tl.terrain = terrain;
    //    tl.renderer = mr;
    //    return true;
    //}

    public static bool TerrainToLODMesh(Terrain terrain, string file) {
        if (terrain == null) { Debug.LogError("TerrainUtils.TerrainToLODMesh terrain is null"); return false; }
        //if (terrain.GetComponent<UnityTerrainLOD>() == null) { Debug.LogError("TerrainUtils.TerrainToLODMesh terrain has no UnityTerrainLOD component"); return false; }
        if (terrain.GetComponent<MeshFilter>() == null) { Debug.LogError("TerrainUtils.TerrainToLODMesh terrain has no MeshFilter component"); return false; }
        if (terrain.GetComponent<MeshFilter>().sharedMesh == null) { Debug.LogError("TerrainUtils.TerrainToLODMesh terrain MeshFilter has no Mesh"); return false; }
        if (string.IsNullOrEmpty(file)) { Debug.LogError("TerrainUtils.TerrainToLODMesh filename was null or empty"); return false; }
        Mesh m = terrain.GetComponent<MeshFilter>().sharedMesh;
        ObjExporter.Export(m, file);
        return true;
    }

    public static bool NormalMapToTerrain(string file, Terrain terrain) {
        if (terrain == null) { Debug.LogError("TerrainUtils.NormalMapToTerrain terrain is null"); return false; }
        if (terrain.terrainData == null) { Debug.LogError("TerrainUtils.NormalMapToTerrain terrain.terrainData is null"); return false; }
        if (string.IsNullOrEmpty(file)) { Debug.LogError("TerrainUtils.NormalMapToTerrain filename was null or empty"); return false; }
        if (File.Exists(file) == false) { Debug.LogError("TerrainUtils.NormalMapToTerrain file doesnt exist @" + file); return false; }
        byte[] data = File.ReadAllBytes(file);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(data);
        tex = Texture2DToNormalMap(tex);
        Material clone = new Material(terrain.materialTemplate);
        terrain.materialTemplate = clone;
        clone.SetTexture("_NormalMap", tex);
        clone.SetFloat("_NormalPower", 0.06f);
        return true;
    }

    public static bool TerrainToNormalMap(Terrain terrain, string file) {
        if (terrain == null) { Debug.LogError("TerrainUtils.TerrainToNormalMap terrain is null"); return false; }
        if (terrain.terrainData == null) { Debug.LogError("TerrainUtils.TerrainToNormalMap terrain.terrainData is null"); return false; }
        if (terrain.materialTemplate == null) { Debug.LogError("TerrainUtils.TerrainToNormalMap terrain.materialTemplate is null"); }
        if (string.IsNullOrEmpty(file)) { Debug.LogError("TerrainUtils.TerrainToNormalMap filename was null or empty"); return false; }
        Texture2D tex = (Texture2D)terrain.materialTemplate.GetTexture("_NormalMap");
        byte[] data = tex.EncodeToPNG();
        File.WriteAllBytes(file, data);
        return true;
    }

    public static bool SplatToTerrain(string file, Terrain terrain) {
        if (terrain == null) { Debug.LogError("TerrainUtils.SplatToTerrain terrain is null"); return false; }
        if (terrain.terrainData == null) { Debug.LogError("TerrainUtils.SplatToTerrain terrain.terrainData is null"); return false; }
        if (string.IsNullOrEmpty(file)) { Debug.LogError("TerrainUtils.SplatToTerrain filename was null or empty"); return false; }
        if (File.Exists(file) == false) { Debug.LogError("TerrainUtils.SplatToTerrain file doesnt exist @" + file); return false; }
        byte[] data = File.ReadAllBytes(file);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(data);
        Material clone = new Material(terrain.materialTemplate);
        terrain.materialTemplate = clone;
        clone.SetTexture("_Splat", tex);
        return true;
    }

    public static bool TerrainToSplat(Terrain terrain, string file) {
        if (terrain == null) { Debug.LogError("TerrainUtils.TerrainToSplat terrain is null"); return false; }
        if (terrain.terrainData == null) { Debug.LogError("TerrainUtils.TerrainToSplat terrain.terrainData is null"); return false; }
        if (terrain.materialTemplate == null) { Debug.LogError("TerrainUtils.TerrainToSplat terrain.materialTemplate is null"); }
        if (string.IsNullOrEmpty(file)) { Debug.LogError("TerrainUtils.TerrainToSplat filename was null or empty"); return false; }
        Texture2D tex = (Texture2D)terrain.materialTemplate.GetTexture("_Splat");
        byte[] data = tex.EncodeToPNG();
        File.WriteAllBytes(file, data);
        return true;
    }

    public static bool ColorToTerrain(string file, Terrain terrain) {
        if (terrain == null) { Debug.LogError("TerrainUtils.ColorToTerrain terrain is null"); return false; }
        if (terrain.terrainData == null) { Debug.LogError("TerrainUtils.ColorToTerrain terrain.terrainData is null"); return false; }
        if (string.IsNullOrEmpty(file)) { Debug.LogError("TerrainUtils.ColorToTerrain filename was null or empty"); return false; }
        if (File.Exists(file) == false) { Debug.LogError("TerrainUtils.ColorToTerrain file doesnt exist @" + file); return false; }
        byte[] data = File.ReadAllBytes(file);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(data);
        Material clone = new Material(terrain.materialTemplate);
        terrain.materialTemplate = clone;
        clone.SetTexture("_ColorMap", tex);
        return true;
    }

    public static bool TerrainToColor(Terrain terrain,string file) {
        if (terrain == null) { Debug.LogError("TerrainUtils.TerrainToColor terrain is null"); return false; }
        if (terrain.terrainData == null) { Debug.LogError("TerrainUtils.TerrainToColor terrain.terrainData is null"); return false; }
        if (terrain.materialTemplate == null) { Debug.LogError("TerrainUtils.TerrainToColor terrain.materialTemplate is null"); }
        if (string.IsNullOrEmpty(file)) { Debug.LogError("TerrainUtils.TerrainToColor filename was null or empty"); return false; }
        Texture2D tex = (Texture2D)terrain.materialTemplate.GetTexture("_ColorMap");
        byte[] data = tex.EncodeToPNG();
        File.WriteAllBytes(file, data);
        return true;
    }

    public static bool Raw32ToTerrain(string file, Terrain terrain) {
        if (terrain == null) { Debug.LogError("TerrainUtils.Raw32ToTerrain terrain is null"); return false; }
        if (terrain.terrainData == null) { Debug.LogError("TerrainUtils.Raw32ToTerrain terrain.terrainData is null"); return false; }
        float[,] height = ImportRaw32(file);
        if (height == null) { return false; }
        if (height.GetLength(0) != height.GetLength(1)) {
            Debug.LogError("TerrainUtils.Raw32ToTerrain height does not match width"+ height.GetLength(0).ToString() + " / "+height.GetLength(1).ToString());
            return false;
        }
        terrain.terrainData.heightmapResolution = height.GetLength(0);
        terrain.terrainData.SetHeights(0, 0, height);
        return true;
    }

    public static bool TerrainToRaw32(Terrain terrain, string file) {
        if (terrain == null) { Debug.LogError("TerrainUtils.TerrainToRaw32 terrain is null"); return false; }
        if (terrain.terrainData == null) { Debug.LogError("TerrainUtils.TerrainToRaw32 terrain.terrainData is null"); return false; }
        float[,] height = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
        ExportRaw32(height, file);
        return true;
    }

    //[SLua.DoNotToLuaAttribute]
    public static float[,] ImportRaw32(string file) {
        if (string.IsNullOrEmpty(file)) { Debug.LogError("TerrainUtils.ImportRaw32 filename was null or empty"); return null; }
        if (File.Exists(file) == false) { Debug.LogError("TerrainUtils.ImportRaw32 file doesnt exist @" + file); return null; }
        byte[] data = File.ReadAllBytes(file);
        if (data.Length % 4 != 0) { Debug.LogError("TerrainUtils.ImportRaw32 byte count not multiple of 4"); return null; }
        int w = (int)Math.Sqrt(data.Length / 4);
        int x = 0;
        int y = 0;
        int ii = 0;
        float[,] ret = new float[w,w];
        for (int i = 0; i < data.Length; i += 4) {
            x = (int)Math.Floor((double)ii / (double)w);
            y = ii % w;
            ret[(w - 1) - x, y] = System.BitConverter.ToSingle(data, i);
            ii++;
        }
        return ret;
    }

    //[SLua.DoNotToLuaAttribute]
    public static bool ExportRaw32(float[,] height , string file) {
        if (string.IsNullOrEmpty(file)) { Debug.LogError("TerrainUtils.ExportRaw32 filename was null or empty"); return false; }
        byte[] data = new byte[height.GetLength(0) * height.GetLength(1) * 4];
        int i = 0;
        for (int y = 0; y < height.GetLength(1); y++) {
           for (int x = 0; x < height.GetLength(0); x++) {
                byte[] package = System.BitConverter.GetBytes(height[x, y]);
                data[i] = package[0];
                data[i+1] = package[1];
                data[i+2] = package[2];
                data[i+3] = package[3];
                i+=4;
            }
        }
        return true;
    }

    //[SLua.DoNotToLuaAttribute]
    public static Texture2D Texture2DToNormalMap(Texture2D source) {
        Texture2D normalTexture = new Texture2D(source.width, source.height, TextureFormat.RGBA32, true);
        normalTexture.filterMode = FilterMode.Trilinear;
        normalTexture.wrapMode = TextureWrapMode.Clamp;
        Color[] pixels = source.GetPixels(0, 0, source.width, source.height);
        float r, g, b, a;
        for (int i = pixels.Length - 1; i >= 0; i--) {
            Color c = pixels[i];
            r = g = b = c.g;
            a = c.r;
            pixels[i] = new Color(r, g, b, a);
        }
        normalTexture.SetPixels(pixels);
        normalTexture.name = "a normal map";
        normalTexture.Apply(true);
        GameObject.Destroy(source);
        return normalTexture;

    }

    //[SLua.DoNotToLuaAttribute]
    public static void NormalizeMesh(Mesh m, bool maintainAspectRatio = true) {
        if (m == null) { return; }
        m.RecalculateBounds();
        Bounds b = m.bounds;
        if (maintainAspectRatio) {
            float max = Mathf.Max(b.size.x, b.size.y);
            b = new Bounds(b.center, new Vector3(max, max, b.size.z));
        }
        Vector3[] verts = m.vertices;
        Matrix4x4 offsetMatrix = Matrix4x4.TRS(b.center, Quaternion.identity, Vector3.one);
        Matrix4x4 scaleMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(1f / b.size.x, 1f / b.size.y, 1f / b.size.z));
        for (int i = 0; i < verts.Length; i++) {
            verts[i] = scaleMatrix.MultiplyPoint(offsetMatrix.inverse.MultiplyPoint(verts[i]));
        }
        m.vertices = verts;
    }

    //[SLua.DoNotToLuaAttribute]
    public static void TransformMesh(Mesh m, Matrix4x4 a) {
        if (m == null) { return; }
        Vector3[] verts = m.vertices;
        for (int i = 0; i < verts.Length; i++) {
            verts[i] = a.MultiplyPoint(verts[i]);
        }
        m.vertices = verts;
    }

    //[SLua.DoNotToLuaAttribute]
    public static void GetTerrainExtremePoint(Terrain terrain, out float min, out float max) {
        min = 0;
        max = 1;
        if (terrain == null) { return; }
        if( terrain.terrainData == null) {return;}
        float[,] height = terrain.terrainData.GetHeights(0,0,terrain.terrainData.heightmapResolution,terrain.terrainData.heightmapResolution);
        for (int x = 0; x < height.GetLength(0); x++) {
            for (int y = 0; y < height.GetLength(1); y++) {
                min = Mathf.Min(min, height[x, y]);
                max = Mathf.Max(max, height[x, y]);
            }
        }
    }
}
