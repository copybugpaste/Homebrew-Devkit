using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendering_renderbufferloadaction {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Rendering.RenderBufferLoadAction o = (UnityEngine.Rendering.RenderBufferLoadAction)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Rendering.RenderBufferLoadAction)System.Enum.Parse(typeof(UnityEngine.Rendering.RenderBufferLoadAction),(string)reader.Read());
        }
    }
}
