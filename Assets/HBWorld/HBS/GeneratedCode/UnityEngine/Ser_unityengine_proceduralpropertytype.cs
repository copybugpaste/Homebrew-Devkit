using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_proceduralpropertytype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.ProceduralPropertyType o = (UnityEngine.ProceduralPropertyType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.ProceduralPropertyType)System.Enum.Parse(typeof(UnityEngine.ProceduralPropertyType),(string)reader.Read());
        }
    }
}
