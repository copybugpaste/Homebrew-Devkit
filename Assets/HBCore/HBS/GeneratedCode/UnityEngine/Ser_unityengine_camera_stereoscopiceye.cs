using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_camera_stereoscopiceye {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Camera.StereoscopicEye o = (UnityEngine.Camera.StereoscopicEye)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Camera.StereoscopicEye)System.Enum.Parse(typeof(UnityEngine.Camera.StereoscopicEye),(string)reader.Read());
        }
    }
}
