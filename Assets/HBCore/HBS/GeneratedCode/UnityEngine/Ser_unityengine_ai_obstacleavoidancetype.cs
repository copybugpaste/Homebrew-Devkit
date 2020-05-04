using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ai_obstacleavoidancetype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AI.ObstacleAvoidanceType o = (UnityEngine.AI.ObstacleAvoidanceType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AI.ObstacleAvoidanceType)System.Enum.Parse(typeof(UnityEngine.AI.ObstacleAvoidanceType),(string)reader.Read());
        }
    }
}
