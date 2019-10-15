using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemcollisionquality {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemCollisionQuality o = (UnityEngine.ParticleSystemCollisionQuality)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemCollisionQuality)System.Enum.Parse(typeof(UnityEngine.ParticleSystemCollisionQuality),(string)reader.Read());
        }
    }
}
