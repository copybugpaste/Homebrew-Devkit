using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ray {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.Ray o = (UnityEngine.Ray)oo;
            writer.Write(2);

            writer.Write("origin");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector3.Ser( writer_ASXDRGBHU , o.origin); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("direction");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector3.Ser( writer_ASXDRGBHU , o.direction); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.Ray o = new UnityEngine.Ray();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "origin") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.origin = (UnityEngine.Vector3)HBS.Ser_unityengine_vector3.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "direction") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.direction = (UnityEngine.Vector3)HBS.Ser_unityengine_vector3.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
