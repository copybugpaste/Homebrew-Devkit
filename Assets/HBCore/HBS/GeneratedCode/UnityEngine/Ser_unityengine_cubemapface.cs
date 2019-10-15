using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_cubemapface {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.CubemapFace o = (UnityEngine.CubemapFace)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.CubemapFace)System.Enum.Parse(typeof(UnityEngine.CubemapFace),(string)reader.Read());
        }
    }
}
