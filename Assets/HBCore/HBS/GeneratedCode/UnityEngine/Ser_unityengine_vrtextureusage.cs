using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_vrtextureusage {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.VRTextureUsage o = (UnityEngine.VRTextureUsage)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.VRTextureUsage)System.Enum.Parse(typeof(UnityEngine.VRTextureUsage),(string)reader.Read());
        }
    }
}
