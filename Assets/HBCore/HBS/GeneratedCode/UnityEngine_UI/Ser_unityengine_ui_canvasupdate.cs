using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_canvasupdate {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.CanvasUpdate o = (UnityEngine.UI.CanvasUpdate)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.CanvasUpdate)System.Enum.Parse(typeof(UnityEngine.UI.CanvasUpdate),(string)reader.Read());
        }
    }
}
