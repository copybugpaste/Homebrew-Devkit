using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_scrollrect_scrollbarvisibility {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.ScrollRect.ScrollbarVisibility o = (UnityEngine.UI.ScrollRect.ScrollbarVisibility)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.ScrollRect.ScrollbarVisibility)System.Enum.Parse(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility),(string)reader.Read());
        }
    }
}
