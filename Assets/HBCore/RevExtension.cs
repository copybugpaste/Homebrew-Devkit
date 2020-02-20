using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using CielaSpike;

namespace HBS {
    public static class RevExtension {
        public static Dictionary<string, RevAudioClip> cacheNoClear = new Dictionary<string, RevAudioClip>();
        public static string savePath;
        public static bool async = false;
        public static Dictionary<string, RevAudioClip> asyncTodo = new Dictionary<string, RevAudioClip>();
        
        public static void SaveRevAudioClip(HBS.Writer writer , object oo) {
            if( writer.WriteNull(oo)) { return; }
            RevAudioClip o = (RevAudioClip)oo;
            var path = "";

            if (async) {
                path = savePath + "/" + o.name + ".h3d";

                writer.Write(o.name);
                if (asyncTodo.ContainsKey(path) == false) {
                    asyncTodo.Add(path, (RevAudioClip)o);
                }
                return;
            }

            var hash = RevAudioClipUtilities.CalcHash(o);
            writer.Write(hash);
            path = savePath + "/" + hash + ".h3d";
            
            if (File.Exists(path) == false) { //dont resave thesame mesh
                RevAudioClipUtilities.SaveHra(o, path);
            }
            
        }
        
        public static object LoadRevAudioClip(HBS.Reader reader, Type t, object oo = null) {
            //read serializer
            if (reader.ReadNull()) { return null; }
            string hash = (string)reader.Read();
            
            if (cacheNoClear.ContainsKey(hash) && cacheNoClear[hash] != null) {//dont load same mesh twice
                return cacheNoClear[hash];
            }
            //load ur custum mesh file
            string path = savePath + "/" + hash + ".h3d";
            //byte[] data = File.ReadAllBytes(path);
            RevAudioClip o = null;
            if (async) {
                //if we wana load async then add path and new empty mesh to async todo
                o = new RevAudioClip();
                o.name = hash + "_async";
                asyncTodo.Add(path, o);
            } else {
                //no async , jsut load the mesh
                o = RevAudioClipUtilities.LoadHra(path);
                o.name = hash;
            }
            //add mesh to cache
            if (cacheNoClear.ContainsKey(hash)) {
                cacheNoClear[hash] = o;
            } else {
                cacheNoClear.Add(hash, o);
            }

            //if cache is growing too big reset it
            if (cacheNoClear.Count > 10000) {
                cacheNoClear.Clear();
            }
            return o;
            
        }

    }
}