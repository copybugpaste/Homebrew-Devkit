using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemcustomdatamode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemCustomDataMode o = (UnityEngine.ParticleSystemCustomDataMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemCustomDataMode)System.Enum.Parse(typeof(UnityEngine.ParticleSystemCustomDataMode),(string)reader.Read());
        }
    }
}
