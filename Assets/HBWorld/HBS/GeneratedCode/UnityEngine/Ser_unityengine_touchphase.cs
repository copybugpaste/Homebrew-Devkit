using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_touchphase {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.TouchPhase o = (UnityEngine.TouchPhase)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.TouchPhase)System.Enum.Parse(typeof(UnityEngine.TouchPhase),(string)reader.Read());
        }
    }
}
