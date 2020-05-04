using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_additionalcanvasshaderchannels {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AdditionalCanvasShaderChannels o = (UnityEngine.AdditionalCanvasShaderChannels)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AdditionalCanvasShaderChannels)System.Enum.Parse(typeof(UnityEngine.AdditionalCanvasShaderChannels),(string)reader.Read());
        }
    }
}
