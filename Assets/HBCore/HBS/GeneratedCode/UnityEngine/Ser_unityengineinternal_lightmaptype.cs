using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengineinternal_lightmaptype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngineInternal.LightmapType o = (UnityEngineInternal.LightmapType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngineInternal.LightmapType)System.Enum.Parse(typeof(UnityEngineInternal.LightmapType),(string)reader.Read());
        }
    }
}
