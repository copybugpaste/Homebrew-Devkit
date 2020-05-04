using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_spritealignment {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.SpriteAlignment o = (UnityEngine.SpriteAlignment)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.SpriteAlignment)System.Enum.Parse(typeof(UnityEngine.SpriteAlignment),(string)reader.Read());
        }
    }
}
