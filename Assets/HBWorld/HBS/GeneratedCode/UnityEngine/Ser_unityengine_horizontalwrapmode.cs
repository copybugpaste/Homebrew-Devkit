using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_horizontalwrapmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.HorizontalWrapMode o = (UnityEngine.HorizontalWrapMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.HorizontalWrapMode)System.Enum.Parse(typeof(UnityEngine.HorizontalWrapMode),(string)reader.Read());
        }
    }
}
