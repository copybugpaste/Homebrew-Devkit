using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_experimental_director_framedata_evaluationtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Experimental.Director.FrameData.EvaluationType o = (UnityEngine.Experimental.Director.FrameData.EvaluationType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Experimental.Director.FrameData.EvaluationType)System.Enum.Parse(typeof(UnityEngine.Experimental.Director.FrameData.EvaluationType),(string)reader.Read());
        }
    }
}
