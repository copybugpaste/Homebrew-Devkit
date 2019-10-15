using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_spritedrawmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.SpriteDrawMode o = (UnityEngine.SpriteDrawMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.SpriteDrawMode)System.Enum.Parse(typeof(UnityEngine.SpriteDrawMode),(string)reader.Read());
        }
    }
}
