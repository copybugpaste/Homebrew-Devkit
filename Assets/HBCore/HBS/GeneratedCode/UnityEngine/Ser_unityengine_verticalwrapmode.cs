using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_verticalwrapmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.VerticalWrapMode o = (UnityEngine.VerticalWrapMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.VerticalWrapMode)System.Enum.Parse(typeof(UnityEngine.VerticalWrapMode),(string)reader.Read());
        }
    }
}
