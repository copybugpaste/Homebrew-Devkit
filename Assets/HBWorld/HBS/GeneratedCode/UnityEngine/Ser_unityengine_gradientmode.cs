using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_gradientmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.GradientMode o = (UnityEngine.GradientMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.GradientMode)System.Enum.Parse(typeof(UnityEngine.GradientMode),(string)reader.Read());
        }
    }
}
