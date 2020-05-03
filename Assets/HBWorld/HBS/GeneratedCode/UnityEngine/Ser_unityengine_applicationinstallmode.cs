using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_applicationinstallmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ApplicationInstallMode o = (UnityEngine.ApplicationInstallMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ApplicationInstallMode)System.Enum.Parse(typeof(UnityEngine.ApplicationInstallMode),(string)reader.Read());
        }
    }
}
