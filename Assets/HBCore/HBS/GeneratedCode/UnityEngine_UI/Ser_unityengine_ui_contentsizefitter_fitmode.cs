using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_contentsizefitter_fitmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.ContentSizeFitter.FitMode o = (UnityEngine.UI.ContentSizeFitter.FitMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.ContentSizeFitter.FitMode)System.Enum.Parse(typeof(UnityEngine.UI.ContentSizeFitter.FitMode),(string)reader.Read());
        }
    }
}
