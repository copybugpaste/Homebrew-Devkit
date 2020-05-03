using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendering_defaultreflectionmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Rendering.DefaultReflectionMode o = (UnityEngine.Rendering.DefaultReflectionMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Rendering.DefaultReflectionMode)System.Enum.Parse(typeof(UnityEngine.Rendering.DefaultReflectionMode),(string)reader.Read());
        }
    }
}
