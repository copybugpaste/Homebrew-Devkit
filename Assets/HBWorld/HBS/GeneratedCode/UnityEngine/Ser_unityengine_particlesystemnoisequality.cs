using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemnoisequality {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemNoiseQuality o = (UnityEngine.ParticleSystemNoiseQuality)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemNoiseQuality)System.Enum.Parse(typeof(UnityEngine.ParticleSystemNoiseQuality),(string)reader.Read());
        }
    }
}
