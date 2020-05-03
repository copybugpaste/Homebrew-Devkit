using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_customrendertextureinitializationsource {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.CustomRenderTextureInitializationSource o = (UnityEngine.CustomRenderTextureInitializationSource)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.CustomRenderTextureInitializationSource)System.Enum.Parse(typeof(UnityEngine.CustomRenderTextureInitializationSource),(string)reader.Read());
        }
    }
}
