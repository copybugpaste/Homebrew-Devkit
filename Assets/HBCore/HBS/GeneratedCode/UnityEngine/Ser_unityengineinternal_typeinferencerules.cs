using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengineinternal_typeinferencerules {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngineInternal.TypeInferenceRules o = (UnityEngineInternal.TypeInferenceRules)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngineInternal.TypeInferenceRules)System.Enum.Parse(typeof(UnityEngineInternal.TypeInferenceRules),(string)reader.Read());
        }
    }
}
