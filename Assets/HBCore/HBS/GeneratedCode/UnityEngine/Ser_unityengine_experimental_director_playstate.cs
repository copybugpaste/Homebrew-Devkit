using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_experimental_director_playstate {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.Experimental.Director.PlayState o = (UnityEngine.Experimental.Director.PlayState)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.Experimental.Director.PlayState)System.Enum.Parse(typeof(UnityEngine.Experimental.Director.PlayState),(string)reader.Read());
        }
    }
}
