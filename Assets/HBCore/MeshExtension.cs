using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using CielaSpike;

namespace HBS {
    public static class MeshExtension {

        public static Dictionary<string, Mesh> cacheNoClear = new Dictionary<string, Mesh>();

        public static void SaveMeshAsync(Writer writer, string workPath, object o, ref Dictionary<string, Mesh> asynclist) {
            if (writer.WriteNull(o)) { return; }

            var oo = (Mesh)o;
            var hash = MeshUtilities.CalcHash(oo);
            writer.Write(hash);
            var path = workPath + "/" + hash + ".h3d";

            if (asynclist.ContainsKey(path) == false) {
                asynclist.Add(path, oo);
            }

        }

        public static void SaveMesh(Writer writer, string workPath, object o) {
            if (writer.WriteNull(o)) { return; }

            var oo = (Mesh)o;
            var hash = MeshUtilities.CalcHash(oo);
            writer.Write(hash);
            var path = workPath + "/" + hash + ".h3d";

            if (File.Exists(path) == false) {
                MeshUtilities.SaveH3d(oo, path);
            }

        }

        public static object LoadMeshAsync(Reader reader, string workPath, ref Dictionary<string, Mesh> asynclist) {

            if (reader.ReadNull()) { return null; }

            var hash = (string)reader.Read();

            Mesh o = null; 
            if (FindInCache(hash, out o)) {
                return cacheNoClear[hash];
            }

            o = new Mesh { name = hash };
            var p = workPath + "/" + hash + ".h3d";
            
            if (asynclist.ContainsKey(p) == false) {
                asynclist.Add(p, o);
            }

            AddToCache(hash, o);

            return o;
        }

        public static object LoadMesh(string workPath, Reader reader, Type t, object oo = null) {

            if (reader.ReadNull()) { return null; }
            var hash = (string)reader.Read();

            Mesh o = null;

            if (FindInCache(hash, out o)) {
                return o;
            }

            var path = workPath + "/" + hash + ".h3d";
            
            o = MeshUtilities.LoadH3d(path);
            o.name = hash;

            AddToCache(hash, o);
            
            return o;

        }

        private static bool FindInCache(string hash , out Mesh o ) {
            o = null;
            if( cacheNoClear == null ) { return false; }

            if (cacheNoClear.ContainsKey(hash) && cacheNoClear[hash] != null) {
                o = cacheNoClear[hash];
                return true;
            }

            return false;
        }

        private static void AddToCache(string hash, Mesh o ) {

            if(cacheNoClear == null ) { cacheNoClear = new Dictionary<string, Mesh>(); }

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