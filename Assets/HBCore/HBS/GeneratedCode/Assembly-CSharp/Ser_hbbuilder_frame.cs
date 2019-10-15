using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_hbbuilder_frame {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            HBBuilder.Frame o = (HBBuilder.Frame)oo;
            writer.Write(9);

            writer.Write("verts");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.verts) == false ) {
                writer_ASXDRGBHU.Write(o.verts.Length);
                for( int i = 0; i < o.verts.Length; i++ ) {
                    HBS.Ser_unityengine_vector3.Ser( writer_ASXDRGBHU , o.verts[i]); //field
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("lines");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.lines) == false ) {
                writer_ASXDRGBHU.Write(o.lines.Length);
                for( int i = 0; i < o.lines.Length; i++ ) {
                    writer_ASXDRGBHU.Write(o.lines[i]); //field primitive
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("handles");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.handles) == false ) {
                writer_ASXDRGBHU.Write(o.handles.Length);
                for( int i = 0; i < o.handles.Length; i++ ) {
                    HBS.Ser_hbbuilder_curvehandle.Ser( writer_ASXDRGBHU , o.handles[i]); //field
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("linesData");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.linesData) == false ) {
                writer_ASXDRGBHU.Write(o.linesData.Length);
                for( int i = 0; i < o.linesData.Length; i++ ) {
                    HBS.Ser_hbbuilder_linedata.Ser( writer_ASXDRGBHU , o.linesData[i]); //field
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("useGUILayout");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.useGUILayout); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("enabled");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.enabled); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("tag");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.tag); //property primitive
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
            HBBuilder.Frame o = (HBBuilder.Frame)oo;
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "verts") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        UnityEngine.Vector3[] verts_arr = new UnityEngine.Vector3[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < verts_arr.Length; i++ ) {
                                verts_arr[i] = (UnityEngine.Vector3)HBS.Ser_unityengine_vector3.Res( reader_ASXDRGBHU ); //field
                            }
                            o.verts = verts_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "lines") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        System.Int32[] lines_arr = new System.Int32[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < lines_arr.Length; i++ ) {
                                lines_arr[i] = (System.Int32)reader_ASXDRGBHU.Read(); //field primitive
                            }
                            o.lines = lines_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "handles") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        HBBuilder.CurveHandle[] handles_arr = new HBBuilder.CurveHandle[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < handles_arr.Length; i++ ) {
                                handles_arr[i] = (HBBuilder.CurveHandle)HBS.Ser_hbbuilder_curvehandle.Res( reader_ASXDRGBHU ); //field
                            }
                            o.handles = handles_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "linesData") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        HBBuilder.LineData[] linesData_arr = new HBBuilder.LineData[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < linesData_arr.Length; i++ ) {
                                linesData_arr[i] = (HBBuilder.LineData)HBS.Ser_hbbuilder_linedata.Res( reader_ASXDRGBHU ); //field
                            }
                            o.linesData = linesData_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "useGUILayout") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.useGUILayout = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "enabled") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.enabled = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "tag") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.tag = (System.String)reader_ASXDRGBHU.Read(); //property primitive
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
