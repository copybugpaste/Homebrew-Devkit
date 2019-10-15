using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_networkloglevel {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.NetworkLogLevel o = (UnityEngine.NetworkLogLevel)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.NetworkLogLevel)System.Enum.Parse(typeof(UnityEngine.NetworkLogLevel),(string)reader.Read());
        }
    }
}
