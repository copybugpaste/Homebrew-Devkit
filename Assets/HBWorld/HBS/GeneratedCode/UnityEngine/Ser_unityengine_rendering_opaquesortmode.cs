using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendering_opaquesortmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Rendering.OpaqueSortMode o = (UnityEngine.Rendering.OpaqueSortMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Rendering.OpaqueSortMode)System.Enum.Parse(typeof(UnityEngine.Rendering.OpaqueSortMode),(string)reader.Read());
        }
    }
}
