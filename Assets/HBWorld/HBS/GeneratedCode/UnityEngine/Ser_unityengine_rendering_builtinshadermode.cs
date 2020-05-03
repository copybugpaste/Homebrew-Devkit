using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rendering_builtinshadermode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Rendering.BuiltinShaderMode o = (UnityEngine.Rendering.BuiltinShaderMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Rendering.BuiltinShaderMode)System.Enum.Parse(typeof(UnityEngine.Rendering.BuiltinShaderMode),(string)reader.Read());
        }
    }
}
