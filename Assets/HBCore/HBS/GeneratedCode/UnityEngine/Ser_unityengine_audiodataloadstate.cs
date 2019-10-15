using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_audiodataloadstate {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AudioDataLoadState o = (UnityEngine.AudioDataLoadState)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AudioDataLoadState)System.Enum.Parse(typeof(UnityEngine.AudioDataLoadState),(string)reader.Read());
        }
    }
}
