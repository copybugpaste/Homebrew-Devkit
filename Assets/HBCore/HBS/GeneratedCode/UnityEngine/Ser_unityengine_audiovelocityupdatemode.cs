using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_audiovelocityupdatemode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.AudioVelocityUpdateMode o = (UnityEngine.AudioVelocityUpdateMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.AudioVelocityUpdateMode)System.Enum.Parse(typeof(UnityEngine.AudioVelocityUpdateMode),(string)reader.Read());
        }
    }
}
