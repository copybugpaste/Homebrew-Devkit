using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_events_persistentlistenermode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Events.PersistentListenerMode o = (UnityEngine.Events.PersistentListenerMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Events.PersistentListenerMode)System.Enum.Parse(typeof(UnityEngine.Events.PersistentListenerMode),(string)reader.Read());
        }
    }
}
