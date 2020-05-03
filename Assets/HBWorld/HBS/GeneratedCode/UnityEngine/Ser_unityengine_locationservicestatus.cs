using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_locationservicestatus {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.LocationServiceStatus o = (UnityEngine.LocationServiceStatus)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.LocationServiceStatus)System.Enum.Parse(typeof(UnityEngine.LocationServiceStatus),(string)reader.Read());
        }
    }
}
