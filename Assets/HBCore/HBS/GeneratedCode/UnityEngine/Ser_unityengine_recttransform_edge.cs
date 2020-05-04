using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_recttransform_edge {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RectTransform.Edge o = (UnityEngine.RectTransform.Edge)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RectTransform.Edge)System.Enum.Parse(typeof(UnityEngine.RectTransform.Edge),(string)reader.Read());
        }
    }
}
