using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_detailrendermode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.DetailRenderMode o = (UnityEngine.DetailRenderMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.DetailRenderMode)System.Enum.Parse(typeof(UnityEngine.DetailRenderMode),(string)reader.Read());
        }
    }
}
