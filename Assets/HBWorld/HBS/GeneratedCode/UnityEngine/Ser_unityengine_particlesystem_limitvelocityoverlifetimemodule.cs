using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_particlesystem_limitvelocityoverlifetimemodule {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule o = (UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule)oo;
            writer.Write(12);

            writer.Write("enabled");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.enabled); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("limitX");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_particlesystem_minmaxcurve.Ser( writer_ASXDRGBHU , o.limitX); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("limitXMultiplier");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.limitXMultiplier); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("limitY");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_particlesystem_minmaxcurve.Ser( writer_ASXDRGBHU , o.limitY); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("limitYMultiplier");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.limitYMultiplier); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("limitZ");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_particlesystem_minmaxcurve.Ser( writer_ASXDRGBHU , o.limitZ); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("limitZMultiplier");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.limitZMultiplier); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("limit");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_particlesystem_minmaxcurve.Ser( writer_ASXDRGBHU , o.limit); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("limitMultiplier");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.limitMultiplier); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("dampen");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.dampen); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("separateAxes");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.separateAxes); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("space");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_particlesystemsimulationspace.Ser( writer_ASXDRGBHU , o.space); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule o = new UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "enabled") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.enabled = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "limitX") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.limitX = (UnityEngine.ParticleSystem.MinMaxCurve)HBS.Ser_unityengine_particlesystem_minmaxcurve.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "limitXMultiplier") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.limitXMultiplier = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "limitY") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.limitY = (UnityEngine.ParticleSystem.MinMaxCurve)HBS.Ser_unityengine_particlesystem_minmaxcurve.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "limitYMultiplier") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.limitYMultiplier = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "limitZ") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.limitZ = (UnityEngine.ParticleSystem.MinMaxCurve)HBS.Ser_unityengine_particlesystem_minmaxcurve.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "limitZMultiplier") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.limitZMultiplier = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "limit") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.limit = (UnityEngine.ParticleSystem.MinMaxCurve)HBS.Ser_unityengine_particlesystem_minmaxcurve.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "limitMultiplier") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.limitMultiplier = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "dampen") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.dampen = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "separateAxes") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.separateAxes = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "space") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.space = (UnityEngine.ParticleSystemSimulationSpace)HBS.Ser_unityengine_particlesystemsimulationspace.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
