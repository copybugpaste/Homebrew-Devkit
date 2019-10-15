using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rigidbodyconstraints2d {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RigidbodyConstraints2D o = (UnityEngine.RigidbodyConstraints2D)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RigidbodyConstraints2D)System.Enum.Parse(typeof(UnityEngine.RigidbodyConstraints2D),(string)reader.Read());
        }
    }
}
