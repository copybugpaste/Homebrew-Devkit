using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_cameraclearflags {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.CameraClearFlags o = (UnityEngine.CameraClearFlags)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.CameraClearFlags)System.Enum.Parse(typeof(UnityEngine.CameraClearFlags),(string)reader.Read());
        }
    }
}
