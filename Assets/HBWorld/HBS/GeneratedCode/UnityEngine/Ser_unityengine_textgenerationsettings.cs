using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_textgenerationsettings {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.TextGenerationSettings o = (UnityEngine.TextGenerationSettings)oo;
            writer.Write(18);

            writer.Write("font");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_font.Ser( writer_ASXDRGBHU , o.font); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("color");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_color.Ser( writer_ASXDRGBHU , o.color); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("fontSize");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.fontSize); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("lineSpacing");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.lineSpacing); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("richText");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.richText); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("scaleFactor");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.scaleFactor); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("fontStyle");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_fontstyle.Ser( writer_ASXDRGBHU , o.fontStyle); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("textAnchor");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_textanchor.Ser( writer_ASXDRGBHU , o.textAnchor); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("alignByGeometry");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.alignByGeometry); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("resizeTextForBestFit");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.resizeTextForBestFit); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("resizeTextMinSize");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.resizeTextMinSize); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("resizeTextMaxSize");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.resizeTextMaxSize); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("updateBounds");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.updateBounds); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("verticalOverflow");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_verticalwrapmode.Ser( writer_ASXDRGBHU , o.verticalOverflow); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("horizontalOverflow");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_horizontalwrapmode.Ser( writer_ASXDRGBHU , o.horizontalOverflow); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("generationExtents");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.generationExtents); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("pivot");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.pivot); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("generateOutOfBounds");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.generateOutOfBounds); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.TextGenerationSettings o = new UnityEngine.TextGenerationSettings();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "font") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.font = (UnityEngine.Font)HBS.Ser_unityengine_font.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "color") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.color = (UnityEngine.Color)HBS.Ser_unityengine_color.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "fontSize") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.fontSize = (System.Int32)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "lineSpacing") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.lineSpacing = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "richText") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.richText = (System.Boolean)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "scaleFactor") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.scaleFactor = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "fontStyle") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.fontStyle = (UnityEngine.FontStyle)HBS.Ser_unityengine_fontstyle.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "textAnchor") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.textAnchor = (UnityEngine.TextAnchor)HBS.Ser_unityengine_textanchor.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "alignByGeometry") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.alignByGeometry = (System.Boolean)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "resizeTextForBestFit") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.resizeTextForBestFit = (System.Boolean)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "resizeTextMinSize") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.resizeTextMinSize = (System.Int32)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "resizeTextMaxSize") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.resizeTextMaxSize = (System.Int32)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "updateBounds") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.updateBounds = (System.Boolean)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "verticalOverflow") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.verticalOverflow = (UnityEngine.VerticalWrapMode)HBS.Ser_unityengine_verticalwrapmode.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "horizontalOverflow") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.horizontalOverflow = (UnityEngine.HorizontalWrapMode)HBS.Ser_unityengine_horizontalwrapmode.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "generationExtents") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.generationExtents = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "pivot") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.pivot = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "generateOutOfBounds") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.generateOutOfBounds = (System.Boolean)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
