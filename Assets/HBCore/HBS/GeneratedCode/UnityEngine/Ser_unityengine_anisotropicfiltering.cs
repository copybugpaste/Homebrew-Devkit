using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_anisotropicfiltering {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AnisotropicFiltering o = (UnityEngine.AnisotropicFiltering)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AnisotropicFiltering)System.Enum.Parse(typeof(UnityEngine.AnisotropicFiltering),(string)reader.Read());
        }
    }
}
