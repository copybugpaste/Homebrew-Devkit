using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_threadpriority {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ThreadPriority o = (UnityEngine.ThreadPriority)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ThreadPriority)System.Enum.Parse(typeof(UnityEngine.ThreadPriority),(string)reader.Read());
        }
    }
}
