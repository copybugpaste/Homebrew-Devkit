using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rigidbodytype2d {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RigidbodyType2D o = (UnityEngine.RigidbodyType2D)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RigidbodyType2D)System.Enum.Parse(typeof(UnityEngine.RigidbodyType2D),(string)reader.Read());
        }
    }
}
