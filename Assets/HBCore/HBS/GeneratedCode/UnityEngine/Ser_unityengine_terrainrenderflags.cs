using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_terrainrenderflags {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.TerrainRenderFlags o = (UnityEngine.TerrainRenderFlags)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.TerrainRenderFlags)System.Enum.Parse(typeof(UnityEngine.TerrainRenderFlags),(string)reader.Read());
        }
    }
}
