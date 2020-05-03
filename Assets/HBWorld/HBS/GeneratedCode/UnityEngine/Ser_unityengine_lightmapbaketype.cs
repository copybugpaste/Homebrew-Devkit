using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_lightmapbaketype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.LightmapBakeType o = (UnityEngine.LightmapBakeType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.LightmapBakeType)System.Enum.Parse(typeof(UnityEngine.LightmapBakeType),(string)reader.Read());
        }
    }
}
