using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_image_origin360 {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.Image.Origin360 o = (UnityEngine.UI.Image.Origin360)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.Image.Origin360)System.Enum.Parse(typeof(UnityEngine.UI.Image.Origin360),(string)reader.Read());
        }
    }
}
