using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_shadowquality {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ShadowQuality o = (UnityEngine.ShadowQuality)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ShadowQuality)System.Enum.Parse(typeof(UnityEngine.ShadowQuality),(string)reader.Read());
        }
    }
}
