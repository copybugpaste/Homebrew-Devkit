using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_gradient {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.Gradient o = (UnityEngine.Gradient)oo;
            writer.Write(3);

            writer.Write("colorKeys");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.colorKeys) == false ) {
                writer_ASXDRGBHU.Write(o.colorKeys.Length);
                for( int i = 0; i < o.colorKeys.Length; i++ ) {
                    HBS.Ser_unityengine_gradientcolorkey.Ser( writer_ASXDRGBHU , o.colorKeys[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("alphaKeys");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.alphaKeys) == false ) {
                writer_ASXDRGBHU.Write(o.alphaKeys.Length);
                for( int i = 0; i < o.alphaKeys.Length; i++ ) {
                    HBS.Ser_unityengine_gradientalphakey.Ser( writer_ASXDRGBHU , o.alphaKeys[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("mode");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_gradientmode.Ser( writer_ASXDRGBHU , o.mode); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.Gradient o = new UnityEngine.Gradient();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "colorKeys") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.GradientColorKey[] colorKeys_arr = new UnityEngine.GradientColorKey[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < colorKeys_arr.Length; i++ ) {
                                colorKeys_arr[i] = (UnityEngine.GradientColorKey)HBS.Ser_unityengine_gradientcolorkey.Res( reader_ASXDRGBHU ); //property
                            }
                            o.colorKeys = colorKeys_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "alphaKeys") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.GradientAlphaKey[] alphaKeys_arr = new UnityEngine.GradientAlphaKey[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < alphaKeys_arr.Length; i++ ) {
                                alphaKeys_arr[i] = (UnityEngine.GradientAlphaKey)HBS.Ser_unityengine_gradientalphakey.Res( reader_ASXDRGBHU ); //property
                            }
                            o.alphaKeys = alphaKeys_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "mode") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.mode = (UnityEngine.GradientMode)HBS.Ser_unityengine_gradientmode.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
