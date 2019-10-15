using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_animationplaymode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AnimationPlayMode o = (UnityEngine.AnimationPlayMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AnimationPlayMode)System.Enum.Parse(typeof(UnityEngine.AnimationPlayMode),(string)reader.Read());
        }
    }
}
