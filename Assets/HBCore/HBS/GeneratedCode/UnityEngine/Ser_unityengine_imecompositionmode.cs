using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_imecompositionmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.IMECompositionMode o = (UnityEngine.IMECompositionMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.IMECompositionMode)System.Enum.Parse(typeof(UnityEngine.IMECompositionMode),(string)reader.Read());
        }
    }
}
