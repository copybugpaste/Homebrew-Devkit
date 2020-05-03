using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendering_uvchannelflags {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Rendering.UVChannelFlags o = (UnityEngine.Rendering.UVChannelFlags)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Rendering.UVChannelFlags)System.Enum.Parse(typeof(UnityEngine.Rendering.UVChannelFlags),(string)reader.Read());
        }
    }
}
