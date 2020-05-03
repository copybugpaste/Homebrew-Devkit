using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using CielaSpike;

namespace HBS {
    public static class RevExtension {
        public static Dictionary<string, RevAudioClip> cacheNoClear = new Dictionary<string, RevAudioClip>();
       
        public static void SaveRevAudioClipAsync(Writer writer,string workPath, object o, ref Dictionary<string, RevAudioClip> asynclist) {

            if (writer.WriteNull(o)) { return; }

            var oo = (RevAudioClip)o;
            var hash = RevAudioClipUtilities.CalcHash(oo);
            writer.Write(hash);
            var path = workPath + "/" + hash + ".hra";

            if (asynclist.ContainsKey(path) == false) {
                asynclist.Add(path, oo);
            }
        }

        public static void SaveRevAudioClip( Writer writer,string workPath, object oo) {

            if (writer.WriteNull(oo)) { return; }

            var o = (RevAudioClip)oo;            
            var hash = RevAudioClipUtilities.CalcHash(o);
            writer.Write(hash);
            var path = workPath + "/" + hash + ".hra";

            if (File.Exists(path) == false) {
                RevAudioClipUtilities.SaveHra(o, path);
            }

        }
        
        public static object LoadRevAudioClipAsync(HBS.Reader reader, string workPath, ref Dictionary<string, RevAudioClip> asynclist) {

            if (reader.ReadNull()) { return null; }

            var hash = (string)reader.Read();

            RevAudioClip o = null; 

            if (FindInCache(hash, out o)) {
                return cacheNoClear[hash];
            }

            o = new RevAudioClip { name = hash + "_async" };
            var p = workPath + "/" + hash + ".hra";

            if (asynclist.ContainsKey(p) == false) {
                asynclist.Add(p, o);
            }

            AddToCache(hash, o);

            return o;

        }
        
        public static object LoadRevAudioClip(string workPath, bool async, HBS.Reader reader, Type t, object oo = null) {

            if (reader.ReadNull()) { return null; }

            var hash = (string)reader.Read();

            RevAudioClip o = null;

            if (FindInCache(hash, out o)) {
                return cacheNoClear[hash];
            }

            var path = workPath + "/" + hash + ".hra";
            
            o = RevAudioClipUtilities.LoadHra(path);
            o.name = hash;

            AddToCache(hash, o);

            return o;

        }

        private static bool FindInCache(string hash, out RevAudioClip o) {
            o = null;
            if (cacheNoClear == null) { return false; }

            if (cacheNoClear.ContainsKey(hash) && cacheNoClear[hash] != null) {
                o = cacheNoClear[hash];
                return true;
            }

            return false;
        }

        private static void AddToCache(string hash, RevAudioClip o) {

            if (cacheNoClear == null) { cacheNoClear = new Dictionary<string, RevAudioClip>(); }

            if (cacheNoClear.ContainsKey(hash)) {
                cacheNoClear[hash] = o;
            } else {
                cacheNoClear.Add(hash, o);
            }

            if (cacheNoClear.Count > 10000) {
                cacheNoClear.Clear();
            }

        }
    }
}