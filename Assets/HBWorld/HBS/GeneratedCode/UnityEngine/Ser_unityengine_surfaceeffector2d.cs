using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_surfaceeffector2d {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.SurfaceEffector2D o = (UnityEngine.SurfaceEffector2D)oo;
            writer.Write(12);

            writer.Write("speed");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.speed); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("speedVariation");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.speedVariation); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("forceScale");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.forceScale); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("useContactForce");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.useContactForce); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("useFriction");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.useFriction); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("useBounce");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.useBounce); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("useColliderMask");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.useColliderMask); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("colliderMask");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.colliderMask); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("enabled");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.enabled); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("tag");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.tag); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("name");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.name); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("hideFlags");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_hideflags.Ser( writer_ASXDRGBHU , o.hideFlags); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.SurfaceEffector2D o = (UnityEngine.SurfaceEffector2D)oo;
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "speed") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.speed = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "speedVariation") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.speedVariation = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "forceScale") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.forceScale = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "useContactForce") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.useContactForce = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "useFriction") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.useFriction = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "useBounce") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.useBounce = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "useColliderMask") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.useColliderMask = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "colliderMask") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.colliderMask = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "enabled") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.enabled = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "tag") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.tag = (System.String)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "name") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.name = (System.String)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "hideFlags") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.hideFlags = (UnityEngine.HideFlags)HBS.Ser_unityengine_hideflags.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
