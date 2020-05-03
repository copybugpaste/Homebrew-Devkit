using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_collisionflags {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.CollisionFlags o = (UnityEngine.CollisionFlags)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.CollisionFlags)System.Enum.Parse(typeof(UnityEngine.CollisionFlags),(string)reader.Read());
        }
    }
}
