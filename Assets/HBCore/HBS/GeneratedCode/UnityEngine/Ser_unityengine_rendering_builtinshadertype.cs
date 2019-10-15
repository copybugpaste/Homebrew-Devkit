using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendering_builtinshadertype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Rendering.BuiltinShaderType o = (UnityEngine.Rendering.BuiltinShaderType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Rendering.BuiltinShaderType)System.Enum.Parse(typeof(UnityEngine.Rendering.BuiltinShaderType),(string)reader.Read());
        }
    }
}
