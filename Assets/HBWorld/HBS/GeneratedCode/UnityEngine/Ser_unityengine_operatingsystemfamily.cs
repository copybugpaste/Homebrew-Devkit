using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_operatingsystemfamily {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.OperatingSystemFamily o = (UnityEngine.OperatingSystemFamily)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.OperatingSystemFamily)System.Enum.Parse(typeof(UnityEngine.OperatingSystemFamily),(string)reader.Read());
        }
    }
}
