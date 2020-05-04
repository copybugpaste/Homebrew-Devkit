using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_connectiontesterstatus {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ConnectionTesterStatus o = (UnityEngine.ConnectionTesterStatus)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ConnectionTesterStatus)System.Enum.Parse(typeof(UnityEngine.ConnectionTesterStatus),(string)reader.Read());
        }
    }
}
