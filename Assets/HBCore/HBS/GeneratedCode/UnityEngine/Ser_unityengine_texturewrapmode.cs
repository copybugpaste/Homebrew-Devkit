using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_texturewrapmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.TextureWrapMode o = (UnityEngine.TextureWrapMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.TextureWrapMode)System.Enum.Parse(typeof(UnityEngine.TextureWrapMode),(string)reader.Read());
        }
    }
}
