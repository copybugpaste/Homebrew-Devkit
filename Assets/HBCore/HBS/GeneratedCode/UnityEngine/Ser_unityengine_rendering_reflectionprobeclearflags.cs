using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendering_reflectionprobeclearflags {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Rendering.ReflectionProbeClearFlags o = (UnityEngine.Rendering.ReflectionProbeClearFlags)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Rendering.ReflectionProbeClearFlags)System.Enum.Parse(typeof(UnityEngine.Rendering.ReflectionProbeClearFlags),(string)reader.Read());
        }
    }
}
