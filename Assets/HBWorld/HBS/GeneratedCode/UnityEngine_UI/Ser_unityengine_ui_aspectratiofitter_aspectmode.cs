using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_aspectratiofitter_aspectmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.AspectRatioFitter.AspectMode o = (UnityEngine.UI.AspectRatioFitter.AspectMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.AspectRatioFitter.AspectMode)System.Enum.Parse(typeof(UnityEngine.UI.AspectRatioFitter.AspectMode),(string)reader.Read());
        }
    }
}
