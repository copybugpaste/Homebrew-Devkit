using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_collisiondetectionmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.CollisionDetectionMode o = (UnityEngine.CollisionDetectionMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.CollisionDetectionMode)System.Enum.Parse(typeof(UnityEngine.CollisionDetectionMode),(string)reader.Read());
        }
    }
}
