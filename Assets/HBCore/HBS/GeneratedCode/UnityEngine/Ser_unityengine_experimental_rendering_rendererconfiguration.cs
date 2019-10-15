using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_experimental_rendering_rendererconfiguration {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Experimental.Rendering.RendererConfiguration o = (UnityEngine.Experimental.Rendering.RendererConfiguration)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Experimental.Rendering.RendererConfiguration)System.Enum.Parse(typeof(UnityEngine.Experimental.Rendering.RendererConfiguration),(string)reader.Read());
        }
    }
}
