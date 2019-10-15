using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_events_unityeventcallstate {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Events.UnityEventCallState o = (UnityEngine.Events.UnityEventCallState)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Events.UnityEventCallState)System.Enum.Parse(typeof(UnityEngine.Events.UnityEventCallState),(string)reader.Read());
        }
    }
}
