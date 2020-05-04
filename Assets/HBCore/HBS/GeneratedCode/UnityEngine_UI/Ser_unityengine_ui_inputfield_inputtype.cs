using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_inputfield_inputtype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.InputField.InputType o = (UnityEngine.UI.InputField.InputType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.InputField.InputType)System.Enum.Parse(typeof(UnityEngine.UI.InputField.InputType),(string)reader.Read());
        }
    }
}
