using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystemtriggereventtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ParticleSystemTriggerEventType o = (UnityEngine.ParticleSystemTriggerEventType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ParticleSystemTriggerEventType)System.Enum.Parse(typeof(UnityEngine.ParticleSystemTriggerEventType),(string)reader.Read());
        }
    }
}
