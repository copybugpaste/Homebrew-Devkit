using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_gridlayoutgroup_axis {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.GridLayoutGroup.Axis o = (UnityEngine.UI.GridLayoutGroup.Axis)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.GridLayoutGroup.Axis)System.Enum.Parse(typeof(UnityEngine.UI.GridLayoutGroup.Axis),(string)reader.Read());
        }
    }
}
