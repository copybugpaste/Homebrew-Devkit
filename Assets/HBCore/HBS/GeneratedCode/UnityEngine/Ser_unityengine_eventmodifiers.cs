using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_eventmodifiers {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.EventModifiers o = (UnityEngine.EventModifiers)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.EventModifiers)System.Enum.Parse(typeof(UnityEngine.EventModifiers),(string)reader.Read());
        }
    }
}
