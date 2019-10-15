using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_compositecollider2d_generationtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.CompositeCollider2D.GenerationType o = (UnityEngine.CompositeCollider2D.GenerationType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.CompositeCollider2D.GenerationType)System.Enum.Parse(typeof(UnityEngine.CompositeCollider2D.GenerationType),(string)reader.Read());
        }
    }
}
