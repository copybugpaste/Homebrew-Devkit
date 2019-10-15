using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_transparencysortmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.TransparencySortMode o = (UnityEngine.TransparencySortMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.TransparencySortMode)System.Enum.Parse(typeof(UnityEngine.TransparencySortMode),(string)reader.Read());
        }
    }
}
