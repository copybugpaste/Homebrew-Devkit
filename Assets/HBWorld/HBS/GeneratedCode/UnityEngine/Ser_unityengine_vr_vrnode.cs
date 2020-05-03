using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_vr_vrnode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.VR.VRNode o = (UnityEngine.VR.VRNode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.VR.VRNode)System.Enum.Parse(typeof(UnityEngine.VR.VRNode),(string)reader.Read());
        }
    }
}
