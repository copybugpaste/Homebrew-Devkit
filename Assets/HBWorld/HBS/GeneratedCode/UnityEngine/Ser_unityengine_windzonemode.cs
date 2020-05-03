using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_windzonemode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.WindZoneMode o = (UnityEngine.WindZoneMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.WindZoneMode)System.Enum.Parse(typeof(UnityEngine.WindZoneMode),(string)reader.Read());
        }
    }
}
