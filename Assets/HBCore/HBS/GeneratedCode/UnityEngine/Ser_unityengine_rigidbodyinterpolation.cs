using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rigidbodyinterpolation {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RigidbodyInterpolation o = (UnityEngine.RigidbodyInterpolation)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RigidbodyInterpolation)System.Enum.Parse(typeof(UnityEngine.RigidbodyInterpolation),(string)reader.Read());
        }
    }
}
