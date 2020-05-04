using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_image_originvertical {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.Image.OriginVertical o = (UnityEngine.UI.Image.OriginVertical)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.Image.OriginVertical)System.Enum.Parse(typeof(UnityEngine.UI.Image.OriginVertical),(string)reader.Read());
        }
    }
}
