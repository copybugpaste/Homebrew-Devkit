using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_video_videoaudiooutputmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Video.VideoAudioOutputMode o = (UnityEngine.Video.VideoAudioOutputMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Video.VideoAudioOutputMode)System.Enum.Parse(typeof(UnityEngine.Video.VideoAudioOutputMode),(string)reader.Read());
        }
    }
}
