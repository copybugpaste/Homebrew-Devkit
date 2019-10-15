using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemtrailtexturemode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemTrailTextureMode o = (UnityEngine.ParticleSystemTrailTextureMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemTrailTextureMode)System.Enum.Parse(typeof(UnityEngine.ParticleSystemTrailTextureMode),(string)reader.Read());
        }
    }
}
