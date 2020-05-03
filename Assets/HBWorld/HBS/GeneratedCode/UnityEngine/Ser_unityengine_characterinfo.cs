using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_characterinfo {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.CharacterInfo o = (UnityEngine.CharacterInfo)oo;
            writer.Write(15);

            writer.Write("index");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.index); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("size");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.size); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("style");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_fontstyle.Ser( writer_ASXDRGBHU , o.style); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("advance");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.advance); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("glyphWidth");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.glyphWidth); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("glyphHeight");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.glyphHeight); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("bearing");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.bearing); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("minY");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.minY); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("maxY");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.maxY); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("minX");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.minX); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("maxX");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.maxX); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("uvBottomLeft");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.uvBottomLeft); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("uvBottomRight");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.uvBottomRight); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("uvTopRight");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.uvTopRight); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("uvTopLeft");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.uvTopLeft); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.CharacterInfo o = new UnityEngine.CharacterInfo();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "index") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.index = (System.Int32)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "size") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.size = (System.Int32)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "style") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.style = (UnityEngine.FontStyle)HBS.Ser_unityengine_fontstyle.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "advance") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.advance = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "glyphWidth") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.glyphWidth = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "glyphHeight") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.glyphHeight = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "bearing") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.bearing = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "minY") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.minY = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "maxY") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.maxY = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "minX") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.minX = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "maxX") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.maxX = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "uvBottomLeft") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.uvBottomLeft = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "uvBottomRight") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.uvBottomRight = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "uvTopRight") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.uvTopRight = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "uvTopLeft") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.uvTopLeft = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
