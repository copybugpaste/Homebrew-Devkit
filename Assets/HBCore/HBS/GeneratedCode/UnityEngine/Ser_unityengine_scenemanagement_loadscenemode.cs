using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_scenemanagement_loadscenemode {
        public static void Ser( HBS.Writer writer, object oo ) {
            if( writer.WriteNull(oo) ) { return; }
            UnityEngine.SceneManagement.LoadSceneMode o = (UnityEngine.SceneManagement.LoadSceneMode)oo;
            writer.Write(o.ToString());
        }
        public static object Res( HBS.Reader reader, object o = null ) {
            if(reader.ReadNull()){ return null; }
            return (object)(UnityEngine.SceneManagement.LoadSceneMode)System.Enum.Parse(typeof(UnityEngine.SceneManagement.LoadSceneMode),(string)reader.Read());
        }
    }
}
