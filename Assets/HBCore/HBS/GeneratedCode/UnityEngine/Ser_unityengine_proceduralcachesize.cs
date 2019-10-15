using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_proceduralcachesize {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ProceduralCacheSize o = (UnityEngine.ProceduralCacheSize)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ProceduralCacheSize)System.Enum.Parse(typeof(UnityEngine.ProceduralCacheSize),(string)reader.Read());
        }
    }
}
