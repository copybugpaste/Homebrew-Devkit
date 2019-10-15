using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_forcemode2d {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ForceMode2D o = (UnityEngine.ForceMode2D)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ForceMode2D)System.Enum.Parse(typeof(UnityEngine.ForceMode2D),(string)reader.Read());
        }
    }
}
