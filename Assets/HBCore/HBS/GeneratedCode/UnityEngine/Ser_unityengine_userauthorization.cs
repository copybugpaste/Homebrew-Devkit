using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_userauthorization {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.UserAuthorization o = (UnityEngine.UserAuthorization)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.UserAuthorization)System.Enum.Parse(typeof(UnityEngine.UserAuthorization),(string)reader.Read());
        }
    }
}
