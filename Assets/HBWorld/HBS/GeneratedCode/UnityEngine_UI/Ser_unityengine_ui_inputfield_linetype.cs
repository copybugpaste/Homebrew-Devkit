using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_inputfield_linetype {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.InputField.LineType o = (UnityEngine.UI.InputField.LineType)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.InputField.LineType)System.Enum.Parse(typeof(UnityEngine.UI.InputField.LineType),(string)reader.Read());
        }
    }
}
