using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengineinternal_input_nativeinputupdatetype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngineInternal.Input.NativeInputUpdateType o = (UnityEngineInternal.Input.NativeInputUpdateType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngineInternal.Input.NativeInputUpdateType)System.Enum.Parse(typeof(UnityEngineInternal.Input.NativeInputUpdateType),(string)reader.Read());
        }
    }
}
