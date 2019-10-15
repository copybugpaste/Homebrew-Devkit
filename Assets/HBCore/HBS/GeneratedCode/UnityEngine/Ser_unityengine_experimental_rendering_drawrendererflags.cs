using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_experimental_rendering_drawrendererflags {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Experimental.Rendering.DrawRendererFlags o = (UnityEngine.Experimental.Rendering.DrawRendererFlags)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Experimental.Rendering.DrawRendererFlags)System.Enum.Parse(typeof(UnityEngine.Experimental.Rendering.DrawRendererFlags),(string)reader.Read());
        }
    }
}
