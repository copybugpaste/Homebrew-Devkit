using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_shadervariantcollection_shadervariant {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.ShaderVariantCollection.ShaderVariant o = (UnityEngine.ShaderVariantCollection.ShaderVariant)oo;
            writer.Write(3);

            writer.Write("shader");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_shader.Ser( writer_ASXDRGBHU , o.shader); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("passType");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_rendering_passtype.Ser( writer_ASXDRGBHU , o.passType); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("keywords");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.keywords) == false ) {
                writer_ASXDRGBHU.Write(o.keywords.Length);
                for( int i = 0; i < o.keywords.Length; i++ ) {
                    writer_ASXDRGBHU.Write(o.keywords[i]); //field primitive
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.ShaderVariantCollection.ShaderVariant o = new UnityEngine.ShaderVariantCollection.ShaderVariant();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "shader") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.shader = (UnityEngine.Shader)HBS.Ser_unityengine_shader.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "passType") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.passType = (UnityEngine.Rendering.PassType)HBS.Ser_unityengine_rendering_passtype.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "keywords") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        System.String[] keywords_arr = new System.String[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < keywords_arr.Length; i++ ) {
                                keywords_arr[i] = (System.String)reader_ASXDRGBHU.Read(); //field primitive
                            }
                            o.keywords = keywords_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
