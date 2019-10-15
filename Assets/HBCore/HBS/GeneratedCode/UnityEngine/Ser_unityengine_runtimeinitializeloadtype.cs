using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_runtimeinitializeloadtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RuntimeInitializeLoadType o = (UnityEngine.RuntimeInitializeLoadType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RuntimeInitializeLoadType)System.Enum.Parse(typeof(UnityEngine.RuntimeInitializeLoadType),(string)reader.Read());
        }
    }
}
