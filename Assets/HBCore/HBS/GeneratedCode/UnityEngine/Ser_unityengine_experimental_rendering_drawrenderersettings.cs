using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_experimental_rendering_drawrenderersettings {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.Experimental.Rendering.DrawRendererSettings o = (UnityEngine.Experimental.Rendering.DrawRendererSettings)oo;
            writer.Write(4);

            writer.Write("sorting");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_experimental_rendering_drawrenderersortsettings.Ser( writer_ASXDRGBHU , o.sorting); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("inputFilter");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_experimental_rendering_inputfilter.Ser( writer_ASXDRGBHU , o.inputFilter); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("rendererConfiguration");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_experimental_rendering_rendererconfiguration.Ser( writer_ASXDRGBHU , o.rendererConfiguration); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("flags");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_experimental_rendering_drawrendererflags.Ser( writer_ASXDRGBHU , o.flags); //field
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.Experimental.Rendering.DrawRendererSettings o = new UnityEngine.Experimental.Rendering.DrawRendererSettings();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "sorting") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.sorting = (UnityEngine.Experimental.Rendering.DrawRendererSortSettings)HBS.Ser_unityengine_experimental_rendering_drawrenderersortsettings.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "inputFilter") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.inputFilter = (UnityEngine.Experimental.Rendering.InputFilter)HBS.Ser_unityengine_experimental_rendering_inputfilter.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "rendererConfiguration") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.rendererConfiguration = (UnityEngine.Experimental.Rendering.RendererConfiguration)HBS.Ser_unityengine_experimental_rendering_rendererconfiguration.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "flags") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.flags = (UnityEngine.Experimental.Rendering.DrawRendererFlags)HBS.Ser_unityengine_experimental_rendering_drawrendererflags.Res( reader_ASXDRGBHU ); //field
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
