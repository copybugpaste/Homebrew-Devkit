using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_terrain_materialtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Terrain.MaterialType o = (UnityEngine.Terrain.MaterialType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Terrain.MaterialType)System.Enum.Parse(typeof(UnityEngine.Terrain.MaterialType),(string)reader.Read());
        }
    }
}
