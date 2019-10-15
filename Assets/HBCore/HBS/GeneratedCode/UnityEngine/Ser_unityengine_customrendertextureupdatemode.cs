using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_customrendertextureupdatemode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.CustomRenderTextureUpdateMode o = (UnityEngine.CustomRenderTextureUpdateMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.CustomRenderTextureUpdateMode)System.Enum.Parse(typeof(UnityEngine.CustomRenderTextureUpdateMode),(string)reader.Read());
        }
    }
}
