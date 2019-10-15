using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_selectable_transition {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.Selectable.Transition o = (UnityEngine.UI.Selectable.Transition)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.Selectable.Transition)System.Enum.Parse(typeof(UnityEngine.UI.Selectable.Transition),(string)reader.Read());
        }
    }
}
