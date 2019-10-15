using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_querytriggerinteraction {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.QueryTriggerInteraction o = (UnityEngine.QueryTriggerInteraction)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.QueryTriggerInteraction)System.Enum.Parse(typeof(UnityEngine.QueryTriggerInteraction),(string)reader.Read());
        }
    }
}
