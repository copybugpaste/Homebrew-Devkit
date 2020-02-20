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

        //#region Extensions
        /*public static void SaveMesh(this Mesh o, HBS.Writer writer) {
            if (writer.WriteNull(o)) { return; }
            var temp = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            MeshUtilities.SaveH3d(o, temp);
            string hash = HBU.CalculateMD5(temp);
            writer.Write(hash);
            var path = savePath + "/" + hash + ".h3d";
            if (File.Exists(path)) { File.Delete(temp); return; } //dont resave thesame mesh
            File.Move(temp, savePath + "/" + hash + ".h3d");
        }

        public static Mesh LoadMesh(this Mesh o, HBS.Reader reader) {
            if (reader.ReadNull()) { return null; }
            string hash = (string)reader.Read();

            if (cacheNoClear.ContainsKey(hash) && cacheNoClear[hash] != null) {//dont load same mesh twice
                return cacheNoClear[hash];
            }
            //load ur custum mesh file
            string path = savePath + "/" + hash + ".h3d";
            byte[] data = File.ReadAllBytes(path);
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

        }*/
        //#endregion

        /*public static void SaveMeshOld2(HBS.Writer writer, object oo) {
            //if (writer.WriteNull(o)) { return; }
            //var temp = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            //MeshUtilities.SaveH3d(o, temp);
            //string hash = HBU.CalculateMD5(temp);
            //writer.Write(hash);
            //var path = savePath + "/" + hash + ".h3d";
            //if (File.Exists(path)) { File.Delete(temp); return; } //dont resave thesame mesh
            //File.Move(temp, savePath + "/" + hash + ".h3d");

            //write mesh instance id to serialier 
            if (writer.WriteNull(oo)) { return; }
            var temp = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            var mesh = (Mesh)oo;
            MeshUtilities.SaveH3d(mesh, temp);
            string hash = HBU.CalculateMD5(temp);
            writer.Write(hash);

            //Mesh o = (Mesh)oo;
            //string hash = MeshUtilities.CalcHash(o);
            //writer.Write(hash);

            //write custum mesh file
            string path = savePath + "/" + hash + ".h3d";
            if (File.Exists(path)) { File.Delete(temp); return; } //dont resave thesame mesh
            File.Move(temp, path);
            //MeshUtilities.SaveH3d(o, path);

        }*/

        /*public static void SaveMeshOld(HBS.Writer writer, object oo) {
            //write mesh instance id to serialier 
            if (writer.WriteNull(oo)) { return; }
            Mesh o = (Mesh)oo;
            int instanceID = o.GetInstanceID();
            writer.Write(instanceID);

            //write custum mesh file
            string path = savePath + "/" + instanceID + ".h3d";
            if (File.Exists(path)) { return; } //dont resave thesame mesh
            MeshUtilities.SaveH3d(o, path);

        }
        public static object LoadMeshOld(HBS.Reader reader, Type t, object oo = null) {
            //read serializer
            if (reader.ReadNull()) { return null; }
            int instanceID = (int)reader.Read();

            if (cache.ContainsKey(instanceID)) {//dont load same mesh twice
                return cache[instanceID];
            }
            //load ur custum mesh file
            string path = savePath + "/" + instanceID + ".h3d";
            byte[] data = File.ReadAllBytes(path);
            Mesh o = null;
            if (async) {
                //if we wana load async then add path and new empty mesh to async todo
                o = new Mesh();
                o.name = instanceID.ToString() + "_async";
                asyncTodo.Add(path, o);
            } else {
                //no async , jsut load the mesh
                o = MeshUtilities.LoadH3d(path);
                o.name = instanceID.ToString();
            }
            //add mesh to cache
            cache.Add(instanceID, o);
            return o;
        }*/
    }
}