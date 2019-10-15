using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_stereotargeteyemask {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.StereoTargetEyeMask o = (UnityEngine.StereoTargetEyeMask)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.StereoTargetEyeMask)System.Enum.Parse(typeof(UnityEngine.StereoTargetEyeMask),(string)reader.Read());
        }
    }
}
