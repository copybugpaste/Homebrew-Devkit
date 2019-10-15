using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ai_navmeshobstacleshape {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AI.NavMeshObstacleShape o = (UnityEngine.AI.NavMeshObstacleShape)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AI.NavMeshObstacleShape)System.Enum.Parse(typeof(UnityEngine.AI.NavMeshObstacleShape),(string)reader.Read());
        }
    }
}
