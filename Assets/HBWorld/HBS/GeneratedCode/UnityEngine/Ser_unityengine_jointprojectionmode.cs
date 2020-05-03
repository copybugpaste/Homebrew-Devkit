using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_jointprojectionmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.JointProjectionMode o = (UnityEngine.JointProjectionMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.JointProjectionMode)System.Enum.Parse(typeof(UnityEngine.JointProjectionMode),(string)reader.Read());
        }
    }
}
