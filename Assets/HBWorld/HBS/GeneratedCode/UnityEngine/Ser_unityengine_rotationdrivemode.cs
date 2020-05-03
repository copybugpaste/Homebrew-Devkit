using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_rotationdrivemode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.RotationDriveMode o = (UnityEngine.RotationDriveMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.RotationDriveMode)System.Enum.Parse(typeof(UnityEngine.RotationDriveMode),(string)reader.Read());
        }
    }
}
