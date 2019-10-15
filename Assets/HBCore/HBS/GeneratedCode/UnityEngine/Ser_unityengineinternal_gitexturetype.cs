using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengineinternal_gitexturetype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngineInternal.GITextureType o = (UnityEngineInternal.GITextureType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngineInternal.GITextureType)System.Enum.Parse(typeof(UnityEngineInternal.GITextureType),(string)reader.Read());
        }
    }
}
