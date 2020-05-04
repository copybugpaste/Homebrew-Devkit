using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_systemlanguage {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.SystemLanguage o = (UnityEngine.SystemLanguage)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.SystemLanguage)System.Enum.Parse(typeof(UnityEngine.SystemLanguage),(string)reader.Read());
        }
    }
}
