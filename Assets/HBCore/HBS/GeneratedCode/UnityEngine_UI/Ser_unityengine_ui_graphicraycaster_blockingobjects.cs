using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_graphicraycaster_blockingobjects {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.GraphicRaycaster.BlockingObjects o = (UnityEngine.UI.GraphicRaycaster.BlockingObjects)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.GraphicRaycaster.BlockingObjects)System.Enum.Parse(typeof(UnityEngine.UI.GraphicRaycaster.BlockingObjects),(string)reader.Read());
        }
    }
}
