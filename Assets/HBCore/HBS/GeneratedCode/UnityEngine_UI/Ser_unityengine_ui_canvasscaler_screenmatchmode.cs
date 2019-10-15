using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_canvasscaler_screenmatchmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.CanvasScaler.ScreenMatchMode o = (UnityEngine.UI.CanvasScaler.ScreenMatchMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.CanvasScaler.ScreenMatchMode)System.Enum.Parse(typeof(UnityEngine.UI.CanvasScaler.ScreenMatchMode),(string)reader.Read());
        }
    }
}
