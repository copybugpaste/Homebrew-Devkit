using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_audiospeakermode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AudioSpeakerMode o = (UnityEngine.AudioSpeakerMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AudioSpeakerMode)System.Enum.Parse(typeof(UnityEngine.AudioSpeakerMode),(string)reader.Read());
        }
    }
}
