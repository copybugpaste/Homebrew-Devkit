using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemsimulationspace {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemSimulationSpace o = (UnityEngine.ParticleSystemSimulationSpace)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemSimulationSpace)System.Enum.Parse(typeof(UnityEngine.ParticleSystemSimulationSpace),(string)reader.Read());
        }
    }
}
