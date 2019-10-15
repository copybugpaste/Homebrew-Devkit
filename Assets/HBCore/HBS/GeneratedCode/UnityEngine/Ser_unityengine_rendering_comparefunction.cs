using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendering_comparefunction {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Rendering.CompareFunction o = (UnityEngine.Rendering.CompareFunction)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Rendering.CompareFunction)System.Enum.Parse(typeof(UnityEngine.Rendering.CompareFunction),(string)reader.Read());
        }
    }
}
