using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_scrollbar_direction {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.Scrollbar.Direction o = (UnityEngine.UI.Scrollbar.Direction)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.Scrollbar.Direction)System.Enum.Parse(typeof(UnityEngine.UI.Scrollbar.Direction),(string)reader.Read());
        }
    }
}
