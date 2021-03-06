using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemcollisiontype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemCollisionType o = (UnityEngine.ParticleSystemCollisionType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemCollisionType)System.Enum.Parse(typeof(UnityEngine.ParticleSystemCollisionType),(string)reader.Read());
        }
    }
}
