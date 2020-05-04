using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_image_fillmethod {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.Image.FillMethod o = (UnityEngine.UI.Image.FillMethod)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.Image.FillMethod)System.Enum.Parse(typeof(UnityEngine.UI.Image.FillMethod),(string)reader.Read());
        }
    }
}
