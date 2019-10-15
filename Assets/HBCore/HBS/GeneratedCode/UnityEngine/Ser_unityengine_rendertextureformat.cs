using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendertextureformat {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RenderTextureFormat o = (UnityEngine.RenderTextureFormat)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RenderTextureFormat)System.Enum.Parse(typeof(UnityEngine.RenderTextureFormat),(string)reader.Read());
        }
    }
}
