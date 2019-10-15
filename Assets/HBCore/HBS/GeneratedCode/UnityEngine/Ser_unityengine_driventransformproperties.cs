using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_driventransformproperties {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.DrivenTransformProperties o = (UnityEngine.DrivenTransformProperties)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.DrivenTransformProperties)System.Enum.Parse(typeof(UnityEngine.DrivenTransformProperties),(string)reader.Read());
        }
    }
}
