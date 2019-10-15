using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemmeshshapetype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemMeshShapeType o = (UnityEngine.ParticleSystemMeshShapeType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemMeshShapeType)System.Enum.Parse(typeof(UnityEngine.ParticleSystemMeshShapeType),(string)reader.Read());
        }
    }
}
