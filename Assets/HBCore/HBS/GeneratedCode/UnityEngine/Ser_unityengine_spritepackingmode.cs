using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_spritepackingmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.SpritePackingMode o = (UnityEngine.SpritePackingMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.SpritePackingMode)System.Enum.Parse(typeof(UnityEngine.SpritePackingMode),(string)reader.Read());
        }
    }
}
