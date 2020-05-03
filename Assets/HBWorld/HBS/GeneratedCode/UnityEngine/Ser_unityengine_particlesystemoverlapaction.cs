using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemoverlapaction {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemOverlapAction o = (UnityEngine.ParticleSystemOverlapAction)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemOverlapAction)System.Enum.Parse(typeof(UnityEngine.ParticleSystemOverlapAction),(string)reader.Read());
        }
    }
}
