using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemrenderspace {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemRenderSpace o = (UnityEngine.ParticleSystemRenderSpace)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemRenderSpace)System.Enum.Parse(typeof(UnityEngine.ParticleSystemRenderSpace),(string)reader.Read());
        }
    }
}
