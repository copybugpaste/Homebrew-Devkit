using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_linealignment {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.LineAlignment o = (UnityEngine.LineAlignment)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.LineAlignment)System.Enum.Parse(typeof(UnityEngine.LineAlignment),(string)reader.Read());
        }
    }
}
