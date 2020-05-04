using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_spritetilemode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.SpriteTileMode o = (UnityEngine.SpriteTileMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.SpriteTileMode)System.Enum.Parse(typeof(UnityEngine.SpriteTileMode),(string)reader.Read());
        }
    }
}
