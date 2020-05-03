using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_canvas {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.Canvas o = (UnityEngine.Canvas)oo;
            writer.Write(17);

            writer.Write("renderMode");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_rendermode.Ser( writer_ASXDRGBHU , o.renderMode); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("worldCamera");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Serializer.SerializePath(writer_ASXDRGBHU,o.worldCamera); //property component or gameObject
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("scaleFactor");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.scaleFactor); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("referencePixelsPerUnit");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.referencePixelsPerUnit); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("overridePixelPerfect");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.overridePixelPerfect); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("pixelPerfect");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.pixelPerfect); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("planeDistance");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.planeDistance); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("overrideSorting");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.overrideSorting); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("sortingOrder");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.sortingOrder); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("normalizedSortingGridSize");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.normalizedSortingGridSize); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("sortingLayerID");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.sortingLayerID); //property primitive
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("additionalShaderChannels");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_additionalcanvasshaderchannels.Ser( writer_ASXDRGBHU , o.additionalShaderChannels); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("sortingLayerName");
            writer_ASXDRGBHU = new HBS.Writer();
            writer_ASXDRGBHU.Write(o.sortingLayerName); //property primitive
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
            UnityEngine.Canvas o = (UnityEngine.Canvas)oo;
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "renderMode") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.renderMode = (UnityEngine.RenderMode)HBS.Ser_unityengine_rendermode.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "worldCamera") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.worldCamera = (UnityEngine.Camera)HBS.Serializer.UnserializePath(reader_ASXDRGBHU); //property component or gameobject
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "scaleFactor") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.scaleFactor = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "referencePixelsPerUnit") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.referencePixelsPerUnit = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "overridePixelPerfect") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.overridePixelPerfect = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "pixelPerfect") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.pixelPerfect = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "planeDistance") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.planeDistance = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "overrideSorting") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.overrideSorting = (System.Boolean)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "sortingOrder") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.sortingOrder = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "normalizedSortingGridSize") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.normalizedSortingGridSize = (System.Single)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "sortingLayerID") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.sortingLayerID = (System.Int32)reader_ASXDRGBHU.Read(); //property primitive
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "additionalShaderChannels") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.additionalShaderChannels = (UnityEngine.AdditionalCanvasShaderChannels)HBS.Ser_unityengine_additionalcanvasshaderchannels.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "sortingLayerName") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.sortingLayerName = (System.String)reader_ASXDRGBHU.Read(); //property primitive
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
