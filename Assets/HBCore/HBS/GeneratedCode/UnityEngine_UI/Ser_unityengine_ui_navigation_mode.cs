using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_navigation_mode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.Navigation.Mode o = (UnityEngine.UI.Navigation.Mode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.Navigation.Mode)System.Enum.Parse(typeof(UnityEngine.UI.Navigation.Mode),(string)reader.Read());
        }
    }
}
