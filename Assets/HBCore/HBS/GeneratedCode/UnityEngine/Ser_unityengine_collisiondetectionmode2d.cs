using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_collisiondetectionmode2d {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.CollisionDetectionMode2D o = (UnityEngine.CollisionDetectionMode2D)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.CollisionDetectionMode2D)System.Enum.Parse(typeof(UnityEngine.CollisionDetectionMode2D),(string)reader.Read());
        }
    }
}
