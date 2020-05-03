using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendering_reflectioncubemapcompression {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Rendering.ReflectionCubemapCompression o = (UnityEngine.Rendering.ReflectionCubemapCompression)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Rendering.ReflectionCubemapCompression)System.Enum.Parse(typeof(UnityEngine.Rendering.ReflectionCubemapCompression),(string)reader.Read());
        }
    }
}
