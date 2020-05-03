using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_hbhinge {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            HBHinge o = (HBHinge)oo;
            writer.Write(11);

            writer.Write("PartPropertiesBytes");
            writer_ASXDRGBHU = new HBS.Writer();
            o.PropertiesToBytes(writer_ASXDRGBHU); //writer_ASXDRGBHU.Write(o.PropertiesToString());
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("targetLocalRotationAxis");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector3.Ser( writer_ASXDRGBHU , o.targetLocalRotationAxis); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("pivot");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.pivot); //field component or gameObject
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("joint");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.joint); //field component or gameObject
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("jointTarget");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.jointTarget); //field component or gameObject
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("rotationGizmo");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.rotationGizmo); //field component or gameObject
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("limitMinGizmo");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.limitMinGizmo); //field component or gameObject
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("limitMaxGizmo");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.limitMaxGizmo); //field component or gameObject
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
            HBHinge o = (HBHinge)oo;
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

                if (name_ASXDRGBHU == "targetLocalRotationAxis") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.targetLocalRotationAxis = (UnityEngine.Vector3)HBS.Ser_unityengine_vector3.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "pivot") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.pivot = (UnityEngine.Transform)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //field component or gameobject
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "joint") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.joint = (UnityEngine.HingeJoint)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //field component or gameobject
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "jointTarget") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.jointTarget = (UnityEngine.GameObject)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //field component or gameobject
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "rotationGizmo") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.rotationGizmo = (UnityEngine.GameObject)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //field component or gameobject
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "limitMinGizmo") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.limitMinGizmo = (UnityEngine.GameObject)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //field component or gameobject
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "limitMaxGizmo") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.limitMaxGizmo = (UnityEngine.GameObject)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //field component or gameobject
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
