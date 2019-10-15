using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rigidbodysleepmode2d {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RigidbodySleepMode2D o = (UnityEngine.RigidbodySleepMode2D)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RigidbodySleepMode2D)System.Enum.Parse(typeof(UnityEngine.RigidbodySleepMode2D),(string)reader.Read());
        }
    }
}
