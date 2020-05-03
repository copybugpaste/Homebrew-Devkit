using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_blendweights {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.BlendWeights o = (UnityEngine.BlendWeights)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.BlendWeights)System.Enum.Parse(typeof(UnityEngine.BlendWeights),(string)reader.Read());
        }
    }
}
