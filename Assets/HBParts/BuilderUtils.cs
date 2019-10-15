using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HBBuilder {

    [HBS.SerializeAttribute]
    public struct CurveHandle {
        public Vector3 direction;
        public int vertIndex1;
        public int vertIndex2;
    }

    [System.Serializable]
    public class ColorSwatch {
        public int method; //0 apply color based on uv islands, 1 apply color only for colored meshislands based on uv islands, 2 apply color based on mesh islands 
        public ColorBand[] colors;
        public string[] GetMaterialTypes() {
            List<string> ret = new List<string>();
            foreach (ColorSchemeArea a in ColorSchemeArchive.colors) {
                ret.Add(a.name);
            }
            return ret.ToArray();
        }
        public ColorSwatch(int method = 0) {
            this.method = method;
        }
        public void Add(float percent, int materialIndex, Color color, float smoothness, bool isAccentColor = false) {
            ColorBand n = new ColorBand();
            n.percent = percent;
            n.isAccentColor = isAccentColor;
            n.uvColor = new UVColor();
            n.uvColor.color = color;
            n.uvColor.smoothness = smoothness;
            n.uvColor.materialIndex = materialIndex;
            if (colors == null) { colors = new ColorBand[0]; n.isAccentColor = true; }
            Array.Resize(ref colors, colors.Length + 1);
            colors[colors.Length - 1] = n;
        }
        public void Add(float percent, string materialType, Color color, float smoothness, bool isAccentColor = false) {
            ColorBand n = new ColorBand();
            n.percent = percent;
            n.isAccentColor = isAccentColor;
            n.uvColor = new UVColor();
            n.uvColor.color = color;
            n.uvColor.smoothness = smoothness;
            n.uvColor.materialType = materialType;
            if (colors == null) { colors = new ColorBand[0]; n.isAccentColor = true; }
            Array.Resize(ref colors, colors.Length + 1);
            colors[colors.Length - 1] = n;
        }
        public void Remove(int index) {
            if (colors == null) { return; }
            if (colors.Length == 0) { return; }
            ColorBand[] nColors = new ColorBand[colors.Length - 1];
            int cc = 0;
            for (int i = 0; i < colors.Length; i++) {
                if (i != index) {
                    nColors[cc] = colors[i];
                    cc++;
                }
            }
            colors = nColors;
        }
        public void Set(int index, float percent, int materialIndex, Color color, float smoothness, bool isAccentColor = false) {
            if (colors == null) { return; }
            if (colors.Length == 0) { return; }
            if (index < 0 || index >= colors.Length) { return; }
            colors[index].percent = percent;
            colors[index].isAccentColor = isAccentColor;
            colors[index].uvColor.color = color;
            colors[index].uvColor.smoothness = smoothness;
            colors[index].uvColor.materialIndex = materialIndex;
        }
        public void Set(int index, float percent, string materialType, Color color, float smoothness, bool isAccentColor = false) {
            if (colors == null) { return; }
            if (colors.Length == 0) { return; }
            if (index < 0 || index >= colors.Length) { return; }
            colors[index].percent = percent;
            colors[index].isAccentColor = isAccentColor;
            colors[index].uvColor.color = color;
            colors[index].uvColor.smoothness = smoothness;
            colors[index].uvColor.materialType = materialType;
        }
        public ColorBand GetAccentColor() {
            ColorBand ret = colors[0];
            foreach (ColorBand c in colors) {
                if (c.isAccentColor) {
                    return c;
                }
            }
            return ret;
        }
        public ColorBand GetColor(float relativeSurfaceArea) {
            ColorBand[] sortedcolors = new ColorBand[colors.Length];
            Array.Copy(colors, sortedcolors, colors.Length); ;
            Array.Sort(sortedcolors, delegate (ColorBand a, ColorBand b) { return a.percent.CompareTo(b.percent); });

            float highestPercent = 0f;
            for (int i = 0; i < colors.Length; i++) { if (highestPercent < colors[i].percent) { highestPercent = colors[i].percent; } }

            float from = 0;
            for (int i = 0; i < colors.Length; i++) {
                float to = sortedcolors[i].percent * (1f / highestPercent);
                if (relativeSurfaceArea >= from && relativeSurfaceArea <= to) {
                    return sortedcolors[i];
                }
            }
            return sortedcolors[0];
        }
    }

    [System.Serializable]
    public struct ColorBand {
        public bool isAccentColor;
        public float percent;
        public UVColor uvColor;
    }

    [System.Serializable]
    public struct UVColor {
        public Color color;
        public float smoothness;
        public string materialType;
        public int materialIndex;
        public Vector2 uv {
            get {
                if (ColorSchemeArchive.Find(materialType, color, smoothness) != null) { return ColorSchemeArchive.Find(materialType, color, smoothness).uv; }
                return ColorSchemeArchive.Find(materialIndex, color, smoothness).uv;
            }
        }
    }


    public struct MeshIsland {
        public int[] tris;
        public float relativeSurfaceArea;
        public static bool operator ==(MeshIsland c1, MeshIsland c2) {
            return c1.Equals(c2);
        }

        public static bool operator !=(MeshIsland c1, MeshIsland c2) {
            return !c1.Equals(c2);
        }
        public override bool Equals(object obj) {
            if (obj == null) { return false; }
            return CompareTo((MeshIsland)obj) == 0 ? true : false;
        }
        public int CompareTo(MeshIsland other) {
            if (other.relativeSurfaceArea != relativeSurfaceArea) { return -1; }
            if (other.tris == null && tris != null) { return -1; }
            if (other.tris != null && tris == null) { return -1; }
            if (other.tris == null && tris == null) { return 0; }
            if (other.tris.Length != tris.Length) { return -1; }

            for (int i = 0; i < tris.Length; i++) {
                if (tris[i] != other.tris[i]) { return -1; }
            }
            return 0;
        }
    }
}