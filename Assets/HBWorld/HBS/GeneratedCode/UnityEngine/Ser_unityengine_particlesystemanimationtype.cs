using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemanimationtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemAnimationType o = (UnityEngine.ParticleSystemAnimationType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemAnimationType)System.Enum.Parse(typeof(UnityEngine.ParticleSystemAnimationType),(string)reader.Read());
        }
    }
}
