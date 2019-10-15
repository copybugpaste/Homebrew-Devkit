using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_customrendertextureupdatezonespace {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.CustomRenderTextureUpdateZoneSpace o = (UnityEngine.CustomRenderTextureUpdateZoneSpace)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.CustomRenderTextureUpdateZoneSpace)System.Enum.Parse(typeof(UnityEngine.CustomRenderTextureUpdateZoneSpace),(string)reader.Read());
        }
    }
}
