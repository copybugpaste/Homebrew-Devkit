using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ai_navmeshtriangulation {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.AI.NavMeshTriangulation o = (UnityEngine.AI.NavMeshTriangulation)oo;
            writer.Write(3);

            writer.Write("vertices");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.vertices) == false ) {
                writer_ASXDRGBHU.Write(o.vertices.Length);
                for( int i = 0; i < o.vertices.Length; i++ ) {
                    HBS.Ser_unityengine_vector3.Ser( writer_ASXDRGBHU , o.vertices[i]); //field
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("indices");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.indices) == false ) {
                writer_ASXDRGBHU.Write(o.indices.Length);
                for( int i = 0; i < o.indices.Length; i++ ) {
                    writer_ASXDRGBHU.Write(o.indices[i]); //field primitive
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("areas");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.areas) == false ) {
                writer_ASXDRGBHU.Write(o.areas.Length);
                for( int i = 0; i < o.areas.Length; i++ ) {
                    writer_ASXDRGBHU.Write(o.areas[i]); //field primitive
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.AI.NavMeshTriangulation o = new UnityEngine.AI.NavMeshTriangulation();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "vertices") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        UnityEngine.Vector3[] vertices_arr = new UnityEngine.Vector3[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < vertices_arr.Length; i++ ) {
                                vertices_arr[i] = (UnityEngine.Vector3)HBS.Ser_unityengine_vector3.Res( reader_ASXDRGBHU ); //field
                            }
                            o.vertices = vertices_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "indices") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        System.Int32[] indices_arr = new System.Int32[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < indices_arr.Length; i++ ) {
                                indices_arr[i] = (System.Int32)reader_ASXDRGBHU.Read(); //field primitive
                            }
                            o.indices = indices_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "areas") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        System.Int32[] areas_arr = new System.Int32[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < areas_arr.Length; i++ ) {
                                areas_arr[i] = (System.Int32)reader_ASXDRGBHU.Read(); //field primitive
                            }
                            o.areas = areas_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
