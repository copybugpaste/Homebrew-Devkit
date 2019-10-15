using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_depthtexturemode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.DepthTextureMode o = (UnityEngine.DepthTextureMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.DepthTextureMode)System.Enum.Parse(typeof(UnityEngine.DepthTextureMode),(string)reader.Read());
        }
    }
}
