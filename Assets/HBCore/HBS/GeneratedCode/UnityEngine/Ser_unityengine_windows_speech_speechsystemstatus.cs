using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_windows_speech_speechsystemstatus {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Windows.Speech.SpeechSystemStatus o = (UnityEngine.Windows.Speech.SpeechSystemStatus)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Windows.Speech.SpeechSystemStatus)System.Enum.Parse(typeof(UnityEngine.Windows.Speech.SpeechSystemStatus),(string)reader.Read());
        }
    }
}
