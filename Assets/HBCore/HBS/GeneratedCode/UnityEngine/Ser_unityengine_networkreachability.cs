using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_networkreachability {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.NetworkReachability o = (UnityEngine.NetworkReachability)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.NetworkReachability)System.Enum.Parse(typeof(UnityEngine.NetworkReachability),(string)reader.Read());
        }
    }
}
