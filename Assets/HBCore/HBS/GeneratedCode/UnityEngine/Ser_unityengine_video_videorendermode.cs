using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_video_videorendermode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Video.VideoRenderMode o = (UnityEngine.Video.VideoRenderMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Video.VideoRenderMode)System.Enum.Parse(typeof(UnityEngine.Video.VideoRenderMode),(string)reader.Read());
        }
    }
}
