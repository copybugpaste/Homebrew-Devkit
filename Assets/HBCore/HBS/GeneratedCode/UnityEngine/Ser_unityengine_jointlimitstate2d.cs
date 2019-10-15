using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_jointlimitstate2d {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.JointLimitState2D o = (UnityEngine.JointLimitState2D)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.JointLimitState2D)System.Enum.Parse(typeof(UnityEngine.JointLimitState2D),(string)reader.Read());
        }
    }
}
