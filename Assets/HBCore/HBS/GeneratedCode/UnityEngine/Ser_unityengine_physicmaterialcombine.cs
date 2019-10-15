using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_physicmaterialcombine {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.PhysicMaterialCombine o = (UnityEngine.PhysicMaterialCombine)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.PhysicMaterialCombine)System.Enum.Parse(typeof(UnityEngine.PhysicMaterialCombine),(string)reader.Read());
        }
    }
}
