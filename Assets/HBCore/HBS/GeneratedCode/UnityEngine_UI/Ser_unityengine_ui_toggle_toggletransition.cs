using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_toggle_toggletransition {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.Toggle.ToggleTransition o = (UnityEngine.UI.Toggle.ToggleTransition)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.Toggle.ToggleTransition)System.Enum.Parse(typeof(UnityEngine.UI.Toggle.ToggleTransition),(string)reader.Read());
        }
    }
}
