using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_motionvectorgenerationmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.MotionVectorGenerationMode o = (UnityEngine.MotionVectorGenerationMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.MotionVectorGenerationMode)System.Enum.Parse(typeof(UnityEngine.MotionVectorGenerationMode),(string)reader.Read());
        }
    }
}
