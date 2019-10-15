using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_experimental_rendering_visiblelightflags {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Experimental.Rendering.VisibleLightFlags o = (UnityEngine.Experimental.Rendering.VisibleLightFlags)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Experimental.Rendering.VisibleLightFlags)System.Enum.Parse(typeof(UnityEngine.Experimental.Rendering.VisibleLightFlags),(string)reader.Read());
        }
    }
}
