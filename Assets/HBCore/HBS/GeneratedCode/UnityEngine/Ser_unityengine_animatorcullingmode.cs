using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_animatorcullingmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AnimatorCullingMode o = (UnityEngine.AnimatorCullingMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AnimatorCullingMode)System.Enum.Parse(typeof(UnityEngine.AnimatorCullingMode),(string)reader.Read());
        }
    }
}
