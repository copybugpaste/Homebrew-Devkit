using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_humanbodybones {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.HumanBodyBones o = (UnityEngine.HumanBodyBones)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.HumanBodyBones)System.Enum.Parse(typeof(UnityEngine.HumanBodyBones),(string)reader.Read());
        }
    }
}
