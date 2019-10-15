using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_experimental_rendering_sortflags {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Experimental.Rendering.SortFlags o = (UnityEngine.Experimental.Rendering.SortFlags)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Experimental.Rendering.SortFlags)System.Enum.Parse(typeof(UnityEngine.Experimental.Rendering.SortFlags),(string)reader.Read());
        }
    }
}
