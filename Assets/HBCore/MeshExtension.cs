using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using CielaSpike;

namespace HBS {
    public static class MeshExtension {
        public static Dictionary<string, Mesh> cacheNoClear = new Dictionary<string, Mesh>();
        public static string savePath;
        public static bool async = false;
        public static Dictionary<string, Mesh> asyncTodo = new Dictionary<string, Mesh>();
        
        public static void SaveMesh(HBS.Writer writer , object oo) {
            if( writer.WriteNull(oo)) { return; }
            Mesh o = (Mesh)oo;
            var path = "";

            if (async) {
                path = savePath + "/" + o.name + ".h3d";

                writer.Write(o.name);
                if (asyncTodo.ContainsKey(path) == false) {
                    asyncTodo.Add(path, (Mesh)o);
                }
                return;
            }

            string hash = MeshUtilities.CalcHash(o);
            writer.Write(hash);
            path = savePath + "/" + hash + ".h3d";
            
            if (File.Exists(path) == false) { //dont resave thesame mesh
                MeshUtilities.SaveH3d(o, path);
            }
            
        }
        
        public static object LoadMesh(HBS.Reader reader, Type t, object oo = null) {
            //read serializer
            if (reader.ReadNull()) { return null; }
            string hash = (string)reader.Read();
            
            if (cacheNoClear.ContainsKey(hash) && cacheNoClear[hash] != null) {//dont load same mesh twice
                return cacheNoClear[hash];
            }
            //load ur custum mesh file
            string path = savePath + "/" + hash + ".h3d";
            //byte[] data = File.ReadAllBytes(path);
            Mesh o = null;
            if (async) {
                //if we wana load async then add path and new empty mesh to async todo
                o = new Mesh();
                o.name = hash + "_async";
                asyncTodo.Add(path, o);
            } else {
                //no async , jsut load the mesh
                o = MeshUtilities.LoadH3d(path);
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