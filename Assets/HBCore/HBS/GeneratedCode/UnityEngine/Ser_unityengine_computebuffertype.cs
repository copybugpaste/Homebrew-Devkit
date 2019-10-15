using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_computebuffertype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ComputeBufferType o = (UnityEngine.ComputeBufferType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ComputeBufferType)System.Enum.Parse(typeof(UnityEngine.ComputeBufferType),(string)reader.Read());
        }
    }
}
