using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rigidbodyconstraints {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RigidbodyConstraints o = (UnityEngine.RigidbodyConstraints)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RigidbodyConstraints)System.Enum.Parse(typeof(UnityEngine.RigidbodyConstraints),(string)reader.Read());
        }
    }
}
