using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_jetbrains_annotations_implicitusekindflags {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            JetBrains.Annotations.ImplicitUseKindFlags o = (JetBrains.Annotations.ImplicitUseKindFlags)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(JetBrains.Annotations.ImplicitUseKindFlags)System.Enum.Parse(typeof(JetBrains.Annotations.ImplicitUseKindFlags),(string)reader.Read());
        }
    }
}
