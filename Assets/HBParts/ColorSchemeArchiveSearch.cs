using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HBBuilder {
public static class ColorSchemeArchive {
    public static string data = "";
    public static ColorSchemeArea[] colors = new ColorSchemeArea[0];
    public static string[] GetMaterialTypes() {
        if (colors.Length == 0) { LoadColors(); }
        List<string> ret = new List<string>();
        foreach (ColorSchemeArea a in colors) {
            ret.Add(a.name);
        }
        return ret.ToArray();
    }
    public static ColorSchemeColor Find(int materialType, Color col, float smoothness) {
        ColorSchemeColor ret = null; float nearest = 999999f;
        if (colors.Length == 0) { LoadColors(); }

        if (materialType > colors.Length) { materialType = colors.Length - 1; }
        if (materialType < 0) { materialType = 0; }
        ColorSchemeArea a = colors[materialType];
        foreach (ColorSchemeColor c in a.colors) {
            float error = Mathf.Abs(c.color.r - col.r) + Mathf.Abs(c.color.g - col.g) + Mathf.Abs(c.color.b - col.b) + Mathf.Abs(c.smoothness - smoothness);
            if (error < nearest) { nearest = error; ret = c; }
        }
        
        return ret;
    }
    public static ColorSchemeColor Find(string materialType, Color col, float smoothness) {
        ColorSchemeColor ret = null; float nearest = 999999f;
        if (colors.Length == 0) { LoadColors(); }
        foreach (ColorSchemeArea a in colors) {
            if (a.name != materialType) { continue; }
            foreach (ColorSchemeColor c in a.colors) {
                float error = Mathf.Abs(c.color.r - col.r) + Mathf.Abs(c.color.g - col.g) + Mathf.Abs(c.color.b - col.b) + Mathf.Abs(c.smoothness - smoothness);
                if (error < nearest) { nearest = error; ret = c; }
            }
        }
        return ret;
    }
    public static ColorSchemeColor Find(Vector2 uv) {
        ColorSchemeColor ret = null; float nearest = 999999f;
        if (colors.Length == 0) { LoadColors(); }
        foreach (ColorSchemeArea a in colors) {
            foreach (ColorSchemeColor c in a.colors) {
                float error = Mathf.Abs(c.uv.x - uv.x) + Mathf.Abs(c.uv.y - uv.y);
                if (error < nearest) { nearest = error; ret = c; }
            }
        }
        return ret;
    }

    static void LoadColors() {
        data = Resources.Load<TextAsset>("ColorSchemeArchive").text;
        System.IO.StringReader reader = new System.IO.StringReader(data);
        colors = new ColorSchemeArea[int.Parse(reader.ReadLine())];
        for (int i = 0; i < colors.Length; i++) {
            colors[i] = new ColorSchemeArea();
            colors[i].name = reader.ReadLine();
            colors[i].colors = new ColorSchemeColor[int.Parse(reader.ReadLine())];
            for (int o = 0; o < colors[i].colors.Length; o++) {
                colors[i].colors[o] = new ColorSchemeColor();

                colors[i].colors[o].uv.x = float.Parse(reader.ReadLine());
                colors[i].colors[o].uv.y = float.Parse(reader.ReadLine());

                colors[i].colors[o].color.r = float.Parse(reader.ReadLine());
                colors[i].colors[o].color.g = float.Parse(reader.ReadLine());
                colors[i].colors[o].color.b = float.Parse(reader.ReadLine());
                colors[i].colors[o].color.a = float.Parse(reader.ReadLine());

                colors[i].colors[o].smoothness = float.Parse(reader.ReadLine());

                colors[i].colors[o].materialType = colors[i].name;

                colors[i].colors[o].materialTypeIndex = i;
            }
        }
        reader.Close();
    }
}
    
public class ColorSchemeArea {
    public string name;
    public ColorSchemeColor[] colors;
}
    
public class ColorSchemeColor {
    public Vector2 uv;
    public Color color;
    public float smoothness;
    public string materialType;
    public int materialTypeIndex;
}
}