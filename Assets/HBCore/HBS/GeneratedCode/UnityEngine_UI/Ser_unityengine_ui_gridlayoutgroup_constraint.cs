using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_gridlayoutgroup_constraint {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.GridLayoutGroup.Constraint o = (UnityEngine.UI.GridLayoutGroup.Constraint)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.GridLayoutGroup.Constraint)System.Enum.Parse(typeof(UnityEngine.UI.GridLayoutGroup.Constraint),(string)reader.Read());
        }
    }
}
