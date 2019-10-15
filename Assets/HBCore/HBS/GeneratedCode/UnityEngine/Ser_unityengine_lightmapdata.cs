using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_lightmapdata {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.LightmapData o = (UnityEngine.LightmapData)oo;
            writer.Write(3);

            writer.Write("lightmapColor");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_texture2d.Ser( writer_ASXDRGBHU , o.lightmapColor); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("lightmapDir");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_texture2d.Ser( writer_ASXDRGBHU , o.lightmapDir); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("shadowMask");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_texture2d.Ser( writer_ASXDRGBHU , o.shadowMask); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.LightmapData o = new UnityEngine.LightmapData();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "lightmapColor") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.lightmapColor = (UnityEngine.Texture2D)HBS.Ser_unityengine_texture2d.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "lightmapDir") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.lightmapDir = (UnityEngine.Texture2D)HBS.Ser_unityengine_texture2d.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "shadowMask") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.shadowMask = (UnityEngine.Texture2D)HBS.Ser_unityengine_texture2d.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
