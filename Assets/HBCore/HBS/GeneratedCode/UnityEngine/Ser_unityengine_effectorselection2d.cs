using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_effectorselection2d {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.EffectorSelection2D o = (UnityEngine.EffectorSelection2D)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.EffectorSelection2D)System.Enum.Parse(typeof(UnityEngine.EffectorSelection2D),(string)reader.Read());
        }
    }
}
