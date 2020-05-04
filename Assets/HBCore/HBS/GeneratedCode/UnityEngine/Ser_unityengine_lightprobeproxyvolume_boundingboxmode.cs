using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_lightprobeproxyvolume_boundingboxmode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.LightProbeProxyVolume.BoundingBoxMode o = (UnityEngine.LightProbeProxyVolume.BoundingBoxMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.LightProbeProxyVolume.BoundingBoxMode)System.Enum.Parse(typeof(UnityEngine.LightProbeProxyVolume.BoundingBoxMode),(string)reader.Read());
        }
    }
}
