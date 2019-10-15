using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_lightprobeproxyvolume_resolutionmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.LightProbeProxyVolume.ResolutionMode o = (UnityEngine.LightProbeProxyVolume.ResolutionMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.LightProbeProxyVolume.ResolutionMode)System.Enum.Parse(typeof(UnityEngine.LightProbeProxyVolume.ResolutionMode),(string)reader.Read());
        }
    }
}
