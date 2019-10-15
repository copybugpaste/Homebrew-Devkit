using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_windows_speech_speecherror {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Windows.Speech.SpeechError o = (UnityEngine.Windows.Speech.SpeechError)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Windows.Speech.SpeechError)System.Enum.Parse(typeof(UnityEngine.Windows.Speech.SpeechError),(string)reader.Read());
        }
    }
}
