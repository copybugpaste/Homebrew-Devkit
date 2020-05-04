using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_video_videoaspectratio {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Video.VideoAspectRatio o = (UnityEngine.Video.VideoAspectRatio)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Video.VideoAspectRatio)System.Enum.Parse(typeof(UnityEngine.Video.VideoAspectRatio),(string)reader.Read());
        }
    }
}
