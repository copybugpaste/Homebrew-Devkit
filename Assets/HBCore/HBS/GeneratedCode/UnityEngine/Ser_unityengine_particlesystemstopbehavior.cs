using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemstopbehavior {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemStopBehavior o = (UnityEngine.ParticleSystemStopBehavior)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemStopBehavior)System.Enum.Parse(typeof(UnityEngine.ParticleSystemStopBehavior),(string)reader.Read());
        }
    }
}
