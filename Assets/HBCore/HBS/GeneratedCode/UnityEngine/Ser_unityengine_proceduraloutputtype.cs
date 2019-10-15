using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_proceduraloutputtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ProceduralOutputType o = (UnityEngine.ProceduralOutputType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ProceduralOutputType)System.Enum.Parse(typeof(UnityEngine.ProceduralOutputType),(string)reader.Read());
        }
    }
}
