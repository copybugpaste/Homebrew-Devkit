using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_networkpeertype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.NetworkPeerType o = (UnityEngine.NetworkPeerType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.NetworkPeerType)System.Enum.Parse(typeof(UnityEngine.NetworkPeerType),(string)reader.Read());
        }
    }
}
