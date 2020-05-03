using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_hbwheel {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            HBWheel o = (HBWheel)oo;
            writer.Write(21);

            writer.Write("PartPropertiesBytes");
            writer_ASXDRGBHU = new HBS.Writer();
            o.PropertiesToBytes(writer_ASXDRGBHU); //writer_ASXDRGBHU.Write(o.PropertiesToString());
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("radius");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.radius); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("width");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.width); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("mass");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.mass); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("spring");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.spring); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("damp");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.damp); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("springLength");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.springLength); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("hitMask");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_layermask.Ser( writer_ASXDRGBHU , o.hitMask); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("visualWheel");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.visualWheel); //field component or gameObject
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("sidewaysFrictionFactor");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.sidewaysFrictionFactor); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("forwardFrictionFactor");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.forwardFrictionFactor); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("rollingResistanceCurve");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_animationcurve.Ser( writer_ASXDRGBHU , o.rollingResistanceCurve); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("sidewaysSlipCurve");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_animationcurve.Ser( writer_ASXDRGBHU , o.sidewaysSlipCurve); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("sidewaysSlipSkidCurve");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_animationcurve.Ser( writer_ASXDRGBHU , o.sidewaysSlipSkidCurve); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("forwardSlipCurve");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_animationcurve.Ser( writer_ASXDRGBHU , o.forwardSlipCurve); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("massMultiplier");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.massMultiplier); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("radiusMultiplier");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.radiusMultiplier); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("widthMultiplier");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.widthMultiplier); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("forNewBuilder");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.forNewBuilder); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("kismetPosition");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_vector2.Ser( writer_ASXDRGBHU , o.kismetPosition); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("kismetData");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.kismetData); //field primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            HBWheel o = (HBWheel)oo;
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "PartProperties") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.PropertiesFromString((string)reader_ASXDRGBHU.Read());
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
                if (name_ASXDRGBHU == "PartPropertiesBytes") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.BytesToProperties(reader_ASXDRGBHU);
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "radius") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.radius = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "width") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.width = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "mass") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.mass = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "spring") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.spring = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "damp") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.damp = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "springLength") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.springLength = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "hitMask") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.hitMask = (UnityEngine.LayerMask)HBS.Ser_unityengine_layermask.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "visualWheel") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.visualWheel = (UnityEngine.Transform)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //field component or gameobject
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "sidewaysFrictionFactor") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.sidewaysFrictionFactor = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "forwardFrictionFactor") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.forwardFrictionFactor = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "rollingResistanceCurve") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.rollingResistanceCurve = (UnityEngine.AnimationCurve)HBS.Ser_unityengine_animationcurve.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "sidewaysSlipCurve") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.sidewaysSlipCurve = (UnityEngine.AnimationCurve)HBS.Ser_unityengine_animationcurve.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "sidewaysSlipSkidCurve") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.sidewaysSlipSkidCurve = (UnityEngine.AnimationCurve)HBS.Ser_unityengine_animationcurve.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "forwardSlipCurve") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.forwardSlipCurve = (UnityEngine.AnimationCurve)HBS.Ser_unityengine_animationcurve.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "massMultiplier") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.massMultiplier = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "radiusMultiplier") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.radiusMultiplier = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "widthMultiplier") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.widthMultiplier = (System.Single)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "forNewBuilder") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.forNewBuilder = (System.Boolean)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "kismetPosition") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.kismetPosition = (UnityEngine.Vector2)HBS.Ser_unityengine_vector2.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "kismetData") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.kismetData = (System.String)reader_ASXDRGBHU.Read(); //field primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
