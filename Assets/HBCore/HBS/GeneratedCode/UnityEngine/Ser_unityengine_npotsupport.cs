using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_npotsupport {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.NPOTSupport o = (UnityEngine.NPOTSupport)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.NPOTSupport)System.Enum.Parse(typeof(UnityEngine.NPOTSupport),(string)reader.Read());
        }
    }
}
