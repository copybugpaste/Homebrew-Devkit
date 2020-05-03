using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_networkstatesynchronization {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.NetworkStateSynchronization o = (UnityEngine.NetworkStateSynchronization)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.NetworkStateSynchronization)System.Enum.Parse(typeof(UnityEngine.NetworkStateSynchronization),(string)reader.Read());
        }
    }
}
