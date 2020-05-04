using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_primitivetype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.PrimitiveType o = (UnityEngine.PrimitiveType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.PrimitiveType)System.Enum.Parse(typeof(UnityEngine.PrimitiveType),(string)reader.Read());
        }
    }
}
