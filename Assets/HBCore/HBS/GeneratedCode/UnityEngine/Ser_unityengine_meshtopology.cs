using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_meshtopology {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.MeshTopology o = (UnityEngine.MeshTopology)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.MeshTopology)System.Enum.Parse(typeof(UnityEngine.MeshTopology),(string)reader.Read());
        }
    }
}
