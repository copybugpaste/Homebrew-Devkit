using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_windows_speech_confidencelevel {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Windows.Speech.ConfidenceLevel o = (UnityEngine.Windows.Speech.ConfidenceLevel)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Windows.Speech.ConfidenceLevel)System.Enum.Parse(typeof(UnityEngine.Windows.Speech.ConfidenceLevel),(string)reader.Read());
        }
    }
}
