using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_collections_allocator {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Collections.Allocator o = (UnityEngine.Collections.Allocator)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Collections.Allocator)System.Enum.Parse(typeof(UnityEngine.Collections.Allocator),(string)reader.Read());
        }
    }
}
