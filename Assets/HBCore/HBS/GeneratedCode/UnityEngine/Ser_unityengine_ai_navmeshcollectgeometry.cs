using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ai_navmeshcollectgeometry {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AI.NavMeshCollectGeometry o = (UnityEngine.AI.NavMeshCollectGeometry)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AI.NavMeshCollectGeometry)System.Enum.Parse(typeof(UnityEngine.AI.NavMeshCollectGeometry),(string)reader.Read());
        }
    }
}
