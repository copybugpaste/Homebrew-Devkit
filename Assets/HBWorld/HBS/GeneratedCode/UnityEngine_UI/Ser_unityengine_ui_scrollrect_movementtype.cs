using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_scrollrect_movementtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.ScrollRect.MovementType o = (UnityEngine.UI.ScrollRect.MovementType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.ScrollRect.MovementType)System.Enum.Parse(typeof(UnityEngine.UI.ScrollRect.MovementType),(string)reader.Read());
        }
    }
}
