using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_audiorolloffmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AudioRolloffMode o = (UnityEngine.AudioRolloffMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AudioRolloffMode)System.Enum.Parse(typeof(UnityEngine.AudioRolloffMode),(string)reader.Read());
        }
    }
}
