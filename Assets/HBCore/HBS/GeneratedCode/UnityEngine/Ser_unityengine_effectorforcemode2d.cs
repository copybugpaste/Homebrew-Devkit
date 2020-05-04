using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_effectorforcemode2d {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.EffectorForceMode2D o = (UnityEngine.EffectorForceMode2D)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.EffectorForceMode2D)System.Enum.Parse(typeof(UnityEngine.EffectorForceMode2D),(string)reader.Read());
        }
    }
}
