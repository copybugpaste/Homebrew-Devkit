using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendering_copytexturesupport {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Rendering.CopyTextureSupport o = (UnityEngine.Rendering.CopyTextureSupport)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Rendering.CopyTextureSupport)System.Enum.Parse(typeof(UnityEngine.Rendering.CopyTextureSupport),(string)reader.Read());
        }
    }
}
