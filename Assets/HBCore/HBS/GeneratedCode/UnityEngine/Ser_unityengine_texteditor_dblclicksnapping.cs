using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_texteditor_dblclicksnapping {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.TextEditor.DblClickSnapping o = (UnityEngine.TextEditor.DblClickSnapping)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.TextEditor.DblClickSnapping)System.Enum.Parse(typeof(UnityEngine.TextEditor.DblClickSnapping),(string)reader.Read());
        }
    }
}
