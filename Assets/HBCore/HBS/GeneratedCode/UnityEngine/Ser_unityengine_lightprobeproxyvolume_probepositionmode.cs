using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_lightprobeproxyvolume_probepositionmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.LightProbeProxyVolume.ProbePositionMode o = (UnityEngine.LightProbeProxyVolume.ProbePositionMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.LightProbeProxyVolume.ProbePositionMode)System.Enum.Parse(typeof(UnityEngine.LightProbeProxyVolume.ProbePositionMode),(string)reader.Read());
        }
    }
}
