using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_stacktracelogtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.StackTraceLogType o = (UnityEngine.StackTraceLogType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.StackTraceLogType)System.Enum.Parse(typeof(UnityEngine.StackTraceLogType),(string)reader.Read());
        }
    }
}
