using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_proceduralprocessorusage {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ProceduralProcessorUsage o = (UnityEngine.ProceduralProcessorUsage)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ProceduralProcessorUsage)System.Enum.Parse(typeof(UnityEngine.ProceduralProcessorUsage),(string)reader.Read());
        }
    }
}
