using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_animationblendmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AnimationBlendMode o = (UnityEngine.AnimationBlendMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AnimationBlendMode)System.Enum.Parse(typeof(UnityEngine.AnimationBlendMode),(string)reader.Read());
        }
    }
}
