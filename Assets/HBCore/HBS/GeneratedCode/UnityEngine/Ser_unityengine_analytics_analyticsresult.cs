using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_analytics_analyticsresult {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Analytics.AnalyticsResult o = (UnityEngine.Analytics.AnalyticsResult)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Analytics.AnalyticsResult)System.Enum.Parse(typeof(UnityEngine.Analytics.AnalyticsResult),(string)reader.Read());
        }
    }
}
