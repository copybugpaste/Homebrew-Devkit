using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_navigation {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.UI.Navigation o = (UnityEngine.UI.Navigation)oo;
            writer.Write(5);

            writer.Write("mode");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_ui_navigation_mode.Ser( writer_ASXDRGBHU , o.mode); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("selectOnUp");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.selectOnUp); //property component or gameObject
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("selectOnDown");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.selectOnDown); //property component or gameObject
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("selectOnLeft");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.selectOnLeft); //property component or gameObject
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("selectOnRight");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.selectOnRight); //property component or gameObject
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.UI.Navigation o = new UnityEngine.UI.Navigation();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "mode") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.mode = (UnityEngine.UI.Navigation.Mode)HBS.Ser_unityengine_ui_navigation_mode.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "selectOnUp") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.selectOnUp = (UnityEngine.UI.Selectable)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //property component or gameobject
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "selectOnDown") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.selectOnDown = (UnityEngine.UI.Selectable)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //property component or gameobject
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "selectOnLeft") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.selectOnLeft = (UnityEngine.UI.Selectable)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //property component or gameobject
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "selectOnRight") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.selectOnRight = (UnityEngine.UI.Selectable)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //property component or gameobject
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
