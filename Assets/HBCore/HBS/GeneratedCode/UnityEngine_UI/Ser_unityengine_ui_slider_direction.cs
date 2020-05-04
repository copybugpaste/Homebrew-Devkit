using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_slider_direction {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.Slider.Direction o = (UnityEngine.UI.Slider.Direction)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.Slider.Direction)System.Enum.Parse(typeof(UnityEngine.UI.Slider.Direction),(string)reader.Read());
        }
    }
}
