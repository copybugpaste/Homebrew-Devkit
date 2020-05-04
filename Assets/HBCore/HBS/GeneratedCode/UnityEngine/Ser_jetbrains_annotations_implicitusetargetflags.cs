using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_jetbrains_annotations_implicitusetargetflags {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            JetBrains.Annotations.ImplicitUseTargetFlags o = (JetBrains.Annotations.ImplicitUseTargetFlags)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(JetBrains.Annotations.ImplicitUseTargetFlags)System.Enum.Parse(typeof(JetBrains.Annotations.ImplicitUseTargetFlags),(string)reader.Read());
        }
    }
}
