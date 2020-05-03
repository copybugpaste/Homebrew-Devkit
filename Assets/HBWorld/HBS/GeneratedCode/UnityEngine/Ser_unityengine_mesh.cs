using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_mesh {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.Mesh o = (UnityEngine.Mesh)oo;
            writer.Write(16);

            writer.Write("bounds");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_bounds.Ser( writer_ASXDRGBHU , o.bounds); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("subMeshCount");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.subMeshCount); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("boneWeights");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.boneWeights) == false ) {
                writer_ASXDRGBHU.Write(o.boneWeights.Length);
                for( int i = 0; i < o.boneWeights.Length; i++ ) {
                    HBS.Ser_unityengine_boneweight.Ser( writer_ASXDRGBHU , o.boneWeights[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("bindposes");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.bindposes) == false ) {
                writer_ASXDRGBHU.Write(o.bindposes.Length);
                for( int i = 0; i < o.bindposes.Length; i++ ) {
                    HBS.Ser_unityengine_matrix4x4.Ser( writer_ASXDRGBHU , o.bindposes[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("vertices");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.vertices) == false ) {
                writer_ASXDRGBHU.Write(o.vertices.Length);
                for( int i = 0; i < o.vertices.Length; i++ ) {
                    HBS.Ser_unityengine_vector3.Ser( writer_ASXDRGBHU , o.vertices[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("normals");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.normals) == false ) {
                writer_ASXDRGBHU.Write(o.normals.Length);
                for( int i = 0; i < o.normals.Length; i++ ) {
                    HBS.Ser_unityengine_vector3.Ser( writer_ASXDRGBHU , o.normals[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("tangents");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.tangents) == false ) {
                writer_ASXDRGBHU.Write(o.tangents.Length);
                for( int i = 0; i < o.tangents.Length; i++ ) {
                    HBS.Ser_unityengine_vector4.Ser( writer_ASXDRGBHU , o.tangents[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("uv");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.uv) == false ) {
                writer_ASXDRGBHU.Write(o.uv.Length);
                for( int i = 0; i < o.uv.Length; i++ ) {
                    HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.uv[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("uv2");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.uv2) == false ) {
                writer_ASXDRGBHU.Write(o.uv2.Length);
                for( int i = 0; i < o.uv2.Length; i++ ) {
                    HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.uv2[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("uv3");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.uv3) == false ) {
                writer_ASXDRGBHU.Write(o.uv3.Length);
                for( int i = 0; i < o.uv3.Length; i++ ) {
                    HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.uv3[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("uv4");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.uv4) == false ) {
                writer_ASXDRGBHU.Write(o.uv4.Length);
                for( int i = 0; i < o.uv4.Length; i++ ) {
                    HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.uv4[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("colors");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.colors) == false ) {
                writer_ASXDRGBHU.Write(o.colors.Length);
                for( int i = 0; i < o.colors.Length; i++ ) {
                    HBS.Ser_unityengine_color.Ser( writer_ASXDRGBHU , o.colors[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("colors32");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.colors32) == false ) {
                writer_ASXDRGBHU.Write(o.colors32.Length);
                for( int i = 0; i < o.colors32.Length; i++ ) {
                    HBS.Ser_unityengine_color32.Ser( writer_ASXDRGBHU , o.colors32[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("triangles");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.triangles) == false ) {
                writer_ASXDRGBHU.Write(o.triangles.Length);
                for( int i = 0; i < o.triangles.Length; i++ ) {
                    writer_ASXDRGBHU.Write(o.triangles[i]); //property primitive
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("name");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.name); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("hideFlags");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_hideflags.Ser( writer_ASXDRGBHU , o.hideFlags); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.Mesh o = new UnityEngine.Mesh();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "bounds") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.bounds = (UnityEngine.Bounds)HBS.Ser_unityengine_bounds.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "subMeshCount") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.subMeshCount = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "boneWeights") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.BoneWeight[] boneWeights_arr = new UnityEngine.BoneWeight[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < boneWeights_arr.Length; i++ ) {
                                boneWeights_arr[i] = (UnityEngine.BoneWeight)HBS.Ser_unityengine_boneweight.Res( reader_ASXDRGBHU ); //property
                            }
                            o.boneWeights = boneWeights_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "bindposes") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.Matrix4x4[] bindposes_arr = new UnityEngine.Matrix4x4[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < bindposes_arr.Length; i++ ) {
                                bindposes_arr[i] = (UnityEngine.Matrix4x4)HBS.Ser_unityengine_matrix4x4.Res( reader_ASXDRGBHU ); //property
                            }
                            o.bindposes = bindposes_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "vertices") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.Vector3[] vertices_arr = new UnityEngine.Vector3[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < vertices_arr.Length; i++ ) {
                                vertices_arr[i] = (UnityEngine.Vector3)HBS.Ser_unityengine_vector3.Res( reader_ASXDRGBHU ); //property
                            }
                            o.vertices = vertices_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "normals") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.Vector3[] normals_arr = new UnityEngine.Vector3[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < normals_arr.Length; i++ ) {
                                normals_arr[i] = (UnityEngine.Vector3)HBS.Ser_unityengine_vector3.Res( reader_ASXDRGBHU ); //property
                            }
                            o.normals = normals_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "tangents") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.Vector4[] tangents_arr = new UnityEngine.Vector4[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < tangents_arr.Length; i++ ) {
                                tangents_arr[i] = (UnityEngine.Vector4)HBS.Ser_unityengine_vector4.Res( reader_ASXDRGBHU ); //property
                            }
                            o.tangents = tangents_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "uv") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.Vector2[] uv_arr = new UnityEngine.Vector2[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < uv_arr.Length; i++ ) {
                                uv_arr[i] = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //property
                            }
                            o.uv = uv_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "uv2") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.Vector2[] uv2_arr = new UnityEngine.Vector2[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < uv2_arr.Length; i++ ) {
                                uv2_arr[i] = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //property
                            }
                            o.uv2 = uv2_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "uv3") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.Vector2[] uv3_arr = new UnityEngine.Vector2[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < uv3_arr.Length; i++ ) {
                                uv3_arr[i] = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //property
                            }
                            o.uv3 = uv3_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "uv4") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.Vector2[] uv4_arr = new UnityEngine.Vector2[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < uv4_arr.Length; i++ ) {
                                uv4_arr[i] = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //property
                            }
                            o.uv4 = uv4_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "colors") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.Color[] colors_arr = new UnityEngine.Color[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < colors_arr.Length; i++ ) {
                                colors_arr[i] = (UnityEngine.Color)HBS.Ser_unityengine_color.Res( reader_ASXDRGBHU ); //property
                            }
                            o.colors = colors_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "colors32") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.Color32[] colors32_arr = new UnityEngine.Color32[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < colors32_arr.Length; i++ ) {
                                colors32_arr[i] = (UnityEngine.Color32)HBS.Ser_unityengine_color32.Res( reader_ASXDRGBHU ); //property
                            }
                            o.colors32 = colors32_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "triangles") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            System.Int32[] triangles_arr = new System.Int32[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < triangles_arr.Length; i++ ) {
                                triangles_arr[i] = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                            }
                            o.triangles = triangles_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "name") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.name = (System.String)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "hideFlags") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.hideFlags = (UnityEngine.HideFlags)HBS.Ser_unityengine_hideflags.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
