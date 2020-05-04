using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_audiocompressionformat {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AudioCompressionFormat o = (UnityEngine.AudioCompressionFormat)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AudioCompressionFormat)System.Enum.Parse(typeof(UnityEngine.AudioCompressionFormat),(string)reader.Read());
        }
    }
}
