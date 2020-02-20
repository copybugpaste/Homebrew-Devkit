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

            var o = (RevAudioClip)oo;
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
            
            if (File.Exists(path) == false) {
                RevAudioClipUtilities.SaveHra(o, path);
            }
            
        }
        
        public static object LoadRevAudioClip(HBS.Reader reader, Type t, object oo = null) {
            
            if (reader.ReadNull()) { return null; }
            var hash = (string)reader.Read();
            
            if (cacheNoClear.ContainsKey(hash) && cacheNoClear[hash] != null) {
                return cacheNoClear[hash];
            }

            var path = savePath + "/" + hash + ".h3d";

            RevAudioClip o = null;
            
            if (async) {

                o = new RevAudioClip {
                    name = hash + "_async"
                };
                asyncTodo.Add(path, o);

            } else {

                o = RevAudioClipUtilities.LoadHra(path);
                o.name = hash;

            }

            if (cacheNoClear.ContainsKey(hash)) {
                cacheNoClear[hash] = o;
            } else {
                cacheNoClear.Add(hash, o);
            }


            if (cacheNoClear.Count > 10000) {
                cacheNoClear.Clear();
            }

            return o;
            
        }

    }
}