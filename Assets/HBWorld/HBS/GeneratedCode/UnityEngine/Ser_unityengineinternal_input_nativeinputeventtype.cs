using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengineinternal_input_nativeinputeventtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngineInternal.Input.NativeInputEventType o = (UnityEngineInternal.Input.NativeInputEventType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngineInternal.Input.NativeInputEventType)System.Enum.Parse(typeof(UnityEngineInternal.Input.NativeInputEventType),(string)reader.Read());
        }
    }
}
