using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_masterserverevent {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.MasterServerEvent o = (UnityEngine.MasterServerEvent)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.MasterServerEvent)System.Enum.Parse(typeof(UnityEngine.MasterServerEvent),(string)reader.Read());
        }
    }
}
