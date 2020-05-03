using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_animatorrecordermode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AnimatorRecorderMode o = (UnityEngine.AnimatorRecorderMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AnimatorRecorderMode)System.Enum.Parse(typeof(UnityEngine.AnimatorRecorderMode),(string)reader.Read());
        }
    }
}
