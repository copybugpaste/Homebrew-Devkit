using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_defaultcontrols_resources {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.UI.DefaultControls.Resources o = (UnityEngine.UI.DefaultControls.Resources)oo;
            writer.Write(7);

            writer.Write("standard");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_sprite.Ser( writer_ASXDRGBHU , o.standard); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("background");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_sprite.Ser( writer_ASXDRGBHU , o.background); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("inputField");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_sprite.Ser( writer_ASXDRGBHU , o.inputField); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("knob");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_sprite.Ser( writer_ASXDRGBHU , o.knob); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("checkmark");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_sprite.Ser( writer_ASXDRGBHU , o.checkmark); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("dropdown");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_sprite.Ser( writer_ASXDRGBHU , o.dropdown); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("mask");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_sprite.Ser( writer_ASXDRGBHU , o.mask); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.UI.DefaultControls.Resources o = new UnityEngine.UI.DefaultControls.Resources();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "standard") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.standard = (UnityEngine.Sprite)HBS.Ser_unityengine_sprite.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "background") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.background = (UnityEngine.Sprite)HBS.Ser_unityengine_sprite.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "inputField") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.inputField = (UnityEngine.Sprite)HBS.Ser_unityengine_sprite.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "knob") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.knob = (UnityEngine.Sprite)HBS.Ser_unityengine_sprite.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "checkmark") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.checkmark = (UnityEngine.Sprite)HBS.Ser_unityengine_sprite.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "dropdown") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.dropdown = (UnityEngine.Sprite)HBS.Ser_unityengine_sprite.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "mask") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.mask = (UnityEngine.Sprite)HBS.Ser_unityengine_sprite.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
