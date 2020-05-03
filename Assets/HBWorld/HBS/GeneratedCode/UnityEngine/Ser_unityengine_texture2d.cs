using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_texture2d {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo)) { return; }
            UnityEngine.Texture2D o = (UnityEngine.Texture2D)oo;
            writer.Write(o.name);
        }
        public static object Res( HBS.Reader reader, object o = null) {
            if(reader.ReadNull()){ return null; }
            return (object)Resources.Load<UnityEngine.Texture2D>((string)reader.Read());
        }
    }
}
