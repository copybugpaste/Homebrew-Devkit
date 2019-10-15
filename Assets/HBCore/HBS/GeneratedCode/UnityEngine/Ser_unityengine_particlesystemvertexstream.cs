using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemvertexstream {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemVertexStream o = (UnityEngine.ParticleSystemVertexStream)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemVertexStream)System.Enum.Parse(typeof(UnityEngine.ParticleSystemVertexStream),(string)reader.Read());
        }
    }
}
