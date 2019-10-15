using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendertexturereadwrite {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RenderTextureReadWrite o = (UnityEngine.RenderTextureReadWrite)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RenderTextureReadWrite)System.Enum.Parse(typeof(UnityEngine.RenderTextureReadWrite),(string)reader.Read());
        }
    }
}
