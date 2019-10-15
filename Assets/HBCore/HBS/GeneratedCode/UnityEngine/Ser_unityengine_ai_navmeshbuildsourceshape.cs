using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ai_navmeshbuildsourceshape {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AI.NavMeshBuildSourceShape o = (UnityEngine.AI.NavMeshBuildSourceShape)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AI.NavMeshBuildSourceShape)System.Enum.Parse(typeof(UnityEngine.AI.NavMeshBuildSourceShape),(string)reader.Read());
        }
    }
}
