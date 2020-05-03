using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_clusterinputtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ClusterInputType o = (UnityEngine.ClusterInputType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ClusterInputType)System.Enum.Parse(typeof(UnityEngine.ClusterInputType),(string)reader.Read());
        }
    }
}
