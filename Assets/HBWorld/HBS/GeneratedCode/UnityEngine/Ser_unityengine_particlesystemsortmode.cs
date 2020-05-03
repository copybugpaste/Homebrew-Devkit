using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemsortmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemSortMode o = (UnityEngine.ParticleSystemSortMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemSortMode)System.Enum.Parse(typeof(UnityEngine.ParticleSystemSortMode),(string)reader.Read());
        }
    }
}
