using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_capsuledirection2d {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.CapsuleDirection2D o = (UnityEngine.CapsuleDirection2D)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.CapsuleDirection2D)System.Enum.Parse(typeof(UnityEngine.CapsuleDirection2D),(string)reader.Read());
        }
    }
}
