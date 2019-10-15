using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_applicationsandboxtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ApplicationSandboxType o = (UnityEngine.ApplicationSandboxType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ApplicationSandboxType)System.Enum.Parse(typeof(UnityEngine.ApplicationSandboxType),(string)reader.Read());
        }
    }
}
