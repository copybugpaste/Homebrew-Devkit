using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_scalerestriction {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            ScaleRestriction o = (ScaleRestriction)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(ScaleRestriction)System.Enum.Parse(typeof(ScaleRestriction),(string)reader.Read());
        }
    }
}
