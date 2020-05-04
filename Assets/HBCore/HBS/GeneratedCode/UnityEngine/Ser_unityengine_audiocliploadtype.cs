using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_audiocliploadtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AudioClipLoadType o = (UnityEngine.AudioClipLoadType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AudioClipLoadType)System.Enum.Parse(typeof(UnityEngine.AudioClipLoadType),(string)reader.Read());
        }
    }
}
