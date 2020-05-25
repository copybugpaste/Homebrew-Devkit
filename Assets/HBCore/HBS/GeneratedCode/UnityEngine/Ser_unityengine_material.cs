using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_material {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo)) { return; }
            UnityEngine.Material o = (UnityEngine.Material)oo;
            writer.Write(o.name);
        }
        public static object Res( HBS.Reader reader, object o = null) {
            if(reader.ReadNull()){ return null; }
            var name = (string)reader.Read();
            var m = (Material)Resources.Load<UnityEngine.Material>(name);
            if( m == null ) {
                m = Resources.Load<Material>("devkitDefaultMaterial");
                var clone = GameObject.Instantiate(m);
                clone.name = name;
                return (object)clone;
            }
            return (object)m;
        }
    }
}
