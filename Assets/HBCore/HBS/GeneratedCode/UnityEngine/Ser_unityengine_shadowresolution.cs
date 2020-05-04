using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_shadowresolution {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ShadowResolution o = (UnityEngine.ShadowResolution)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ShadowResolution)System.Enum.Parse(typeof(UnityEngine.ShadowResolution),(string)reader.Read());
        }
    }
}
