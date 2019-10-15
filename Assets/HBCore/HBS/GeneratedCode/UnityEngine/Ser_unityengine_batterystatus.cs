using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_batterystatus {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.BatteryStatus o = (UnityEngine.BatteryStatus)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.BatteryStatus)System.Enum.Parse(typeof(UnityEngine.BatteryStatus),(string)reader.Read());
        }
    }
}
