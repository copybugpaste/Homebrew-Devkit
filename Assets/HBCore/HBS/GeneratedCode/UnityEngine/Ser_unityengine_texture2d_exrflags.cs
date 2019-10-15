using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_texture2d_exrflags {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Texture2D.EXRFlags o = (UnityEngine.Texture2D.EXRFlags)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Texture2D.EXRFlags)System.Enum.Parse(typeof(UnityEngine.Texture2D.EXRFlags),(string)reader.Read());
        }
    }
}
