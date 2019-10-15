using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_configurablejointmotion {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ConfigurableJointMotion o = (UnityEngine.ConfigurableJointMotion)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ConfigurableJointMotion)System.Enum.Parse(typeof(UnityEngine.ConfigurableJointMotion),(string)reader.Read());
        }
    }
}
