using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_sendmessageoptions {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.SendMessageOptions o = (UnityEngine.SendMessageOptions)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.SendMessageOptions)System.Enum.Parse(typeof(UnityEngine.SendMessageOptions),(string)reader.Read());
        }
    }
}
