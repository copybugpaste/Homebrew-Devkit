using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_audioreverbpreset {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AudioReverbPreset o = (UnityEngine.AudioReverbPreset)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AudioReverbPreset)System.Enum.Parse(typeof(UnityEngine.AudioReverbPreset),(string)reader.Read());
        }
    }
}
