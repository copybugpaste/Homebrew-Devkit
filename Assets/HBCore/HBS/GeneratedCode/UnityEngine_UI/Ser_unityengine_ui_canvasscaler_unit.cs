using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_canvasscaler_unit {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.CanvasScaler.Unit o = (UnityEngine.UI.CanvasScaler.Unit)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.CanvasScaler.Unit)System.Enum.Parse(typeof(UnityEngine.UI.CanvasScaler.Unit),(string)reader.Read());
        }
    }
}
