using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemshapemultimodevalue {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemShapeMultiModeValue o = (UnityEngine.ParticleSystemShapeMultiModeValue)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemShapeMultiModeValue)System.Enum.Parse(typeof(UnityEngine.ParticleSystemShapeMultiModeValue),(string)reader.Read());
        }
    }
}
