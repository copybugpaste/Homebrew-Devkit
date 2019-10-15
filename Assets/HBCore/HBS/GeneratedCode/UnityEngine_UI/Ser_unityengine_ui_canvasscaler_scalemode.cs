using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_canvasscaler_scalemode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.CanvasScaler.ScaleMode o = (UnityEngine.UI.CanvasScaler.ScaleMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.CanvasScaler.ScaleMode)System.Enum.Parse(typeof(UnityEngine.UI.CanvasScaler.ScaleMode),(string)reader.Read());
        }
    }
}
