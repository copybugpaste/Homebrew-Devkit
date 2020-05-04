using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_inputfield_charactervalidation {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UI.InputField.CharacterValidation o = (UnityEngine.UI.InputField.CharacterValidation)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UI.InputField.CharacterValidation)System.Enum.Parse(typeof(UnityEngine.UI.InputField.CharacterValidation),(string)reader.Read());
        }
    }
}
