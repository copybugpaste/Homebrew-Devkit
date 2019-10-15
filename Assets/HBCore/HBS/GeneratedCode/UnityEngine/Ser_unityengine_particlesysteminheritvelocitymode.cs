using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesysteminheritvelocitymode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemInheritVelocityMode o = (UnityEngine.ParticleSystemInheritVelocityMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemInheritVelocityMode)System.Enum.Parse(typeof(UnityEngine.ParticleSystemInheritVelocityMode),(string)reader.Read());
        }
    }
}
