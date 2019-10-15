using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rigidbodyinterpolation2d {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RigidbodyInterpolation2D o = (UnityEngine.RigidbodyInterpolation2D)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RigidbodyInterpolation2D)System.Enum.Parse(typeof(UnityEngine.RigidbodyInterpolation2D),(string)reader.Read());
        }
    }
}
