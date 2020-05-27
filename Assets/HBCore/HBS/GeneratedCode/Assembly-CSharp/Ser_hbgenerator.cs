using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_hbgenerator {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            HBGenerator o = (HBGenerator)oo;
            writer.Write(7);

            writer.Write("PartProperties");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.PropertiesToString());
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("inputRotatables");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.inputRotatables) == false ) {
                writer_ASXDRGBHU.Write(o.inputRotatables.Length);
                for( int i = 0; i < o.inputRotatables.Length; i++ ) {
                    HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.inputRotatables[i]); //field component or gameObject
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("outputRotatables");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.outputRotatables) == false ) {
                writer_ASXDRGBHU.Write(o.outputRotatables.Length);
                for( int i = 0; i < o.outputRotatables.Length; i++ ) {
                    HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.outputRotatables[i]); //field component or gameObject
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("rotatablesAxis");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector3.Ser( writer_ASXDRGBHU , o.rotatablesAxis); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("forNewBuilder");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.forNewBuilder); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("kismetPosition");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.kismetPosition); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("kismetData");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.kismetData); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            HBGenerator o = (HBGenerator)oo;
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "PartProperties") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.PropertiesFromString((string)reader_ASXDRGBHU.Read());
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
                if (name_ASXDRGBHU == "PartPropertiesBytes") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.BytesToProperties(reader_ASXDRGBHU);
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "inputRotatables") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        UnityEngine.Transform[] inputRotatables_arr = new UnityEngine.Transform[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < inputRotatables_arr.Length; i++ ) {
                                inputRotatables_arr[i] = (UnityEngine.Transform)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //field component or gameobject
                            }
                            o.inputRotatables = inputRotatables_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "outputRotatables") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        UnityEngine.Transform[] outputRotatables_arr = new UnityEngine.Transform[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < outputRotatables_arr.Length; i++ ) {
                                outputRotatables_arr[i] = (UnityEngine.Transform)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //field component or gameobject
                            }
                            o.outputRotatables = outputRotatables_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "rotatablesAxis") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.rotatablesAxis = (UnityEngine.Vector3)HBS.Ser_unityengine_vector3.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "forNewBuilder") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.forNewBuilder = (System.Boolean)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "kismetPosition") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.kismetPosition = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "kismetData") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.kismetData = (System.String)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}