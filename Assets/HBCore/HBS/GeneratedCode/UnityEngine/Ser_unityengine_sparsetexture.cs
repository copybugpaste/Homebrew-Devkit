using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_sparsetexture {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo)) { return; }
            UnityEngine.SparseTexture o = (UnityEngine.SparseTexture)oo;
            writer.Write(o.name);
        }
        public static object Res( HBS.Reader reader, object o = null) {
            if(reader.ReadNull()){ return null; }
            return (object)Resources.Load<UnityEngine.SparseTexture>((string)reader.Read());
        }
    }
}
