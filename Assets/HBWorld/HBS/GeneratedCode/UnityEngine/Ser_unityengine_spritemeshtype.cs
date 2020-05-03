using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_spritemeshtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.SpriteMeshType o = (UnityEngine.SpriteMeshType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.SpriteMeshType)System.Enum.Parse(typeof(UnityEngine.SpriteMeshType),(string)reader.Read());
        }
    }
}
