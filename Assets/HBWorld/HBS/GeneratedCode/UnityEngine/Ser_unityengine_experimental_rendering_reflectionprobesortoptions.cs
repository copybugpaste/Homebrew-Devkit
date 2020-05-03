using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_experimental_rendering_reflectionprobesortoptions {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Experimental.Rendering.ReflectionProbeSortOptions o = (UnityEngine.Experimental.Rendering.ReflectionProbeSortOptions)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Experimental.Rendering.ReflectionProbeSortOptions)System.Enum.Parse(typeof(UnityEngine.Experimental.Rendering.ReflectionProbeSortOptions),(string)reader.Read());
        }
    }
}
