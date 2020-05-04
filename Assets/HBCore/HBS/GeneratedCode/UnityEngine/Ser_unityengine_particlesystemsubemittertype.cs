using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemsubemittertype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemSubEmitterType o = (UnityEngine.ParticleSystemSubEmitterType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemSubEmitterType)System.Enum.Parse(typeof(UnityEngine.ParticleSystemSubEmitterType),(string)reader.Read());
        }
    }
}
