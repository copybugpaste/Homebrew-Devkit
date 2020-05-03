using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_recttransform_axis {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RectTransform.Axis o = (UnityEngine.RectTransform.Axis)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RectTransform.Axis)System.Enum.Parse(typeof(UnityEngine.RectTransform.Axis),(string)reader.Read());
        }
    }
}
