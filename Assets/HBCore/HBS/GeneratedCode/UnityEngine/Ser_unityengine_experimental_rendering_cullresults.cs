using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_experimental_rendering_cullresults {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.Experimental.Rendering.CullResults o = (UnityEngine.Experimental.Rendering.CullResults)oo;
            writer.Write(2);

            writer.Write("visibleLights");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.visibleLights) == false ) {
                writer_ASXDRGBHU.Write(o.visibleLights.Length);
                for( int i = 0; i < o.visibleLights.Length; i++ ) {
                    HBS.Ser_unityengine_experimental_rendering_visiblelight.Ser( writer_ASXDRGBHU , o.visibleLights[i]); //field
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("visibleReflectionProbes");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.visibleReflectionProbes) == false ) {
                writer_ASXDRGBHU.Write(o.visibleReflectionProbes.Length);
                for( int i = 0; i < o.visibleReflectionProbes.Length; i++ ) {
                    HBS.Ser_unityengine_experimental_rendering_visiblereflectionprobe.Ser( writer_ASXDRGBHU , o.visibleReflectionProbes[i]); //field
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.Experimental.Rendering.CullResults o = new UnityEngine.Experimental.Rendering.CullResults();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "visibleLights") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        UnityEngine.Experimental.Rendering.VisibleLight[] visibleLights_arr = new UnityEngine.Experimental.Rendering.VisibleLight[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < visibleLights_arr.Length; i++ ) {
                                visibleLights_arr[i] = (UnityEngine.Experimental.Rendering.VisibleLight)HBS.Ser_unityengine_experimental_rendering_visiblelight.Res( reader_ASXDRGBHU ); //field
                            }
                            o.visibleLights = visibleLights_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "visibleReflectionProbes") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                    if( reader_ASXDRGBHU.ReadNull() == false ) {
                        UnityEngine.Experimental.Rendering.VisibleReflectionProbe[] visibleReflectionProbes_arr = new UnityEngine.Experimental.Rendering.VisibleReflectionProbe[(int)reader_ASXDRGBHU.Read()];
                        for( int i = 0; i < visibleReflectionProbes_arr.Length; i++ ) {
                                visibleReflectionProbes_arr[i] = (UnityEngine.Experimental.Rendering.VisibleReflectionProbe)HBS.Ser_unityengine_experimental_rendering_visiblereflectionprobe.Res( reader_ASXDRGBHU ); //field
                            }
                            o.visibleReflectionProbes = visibleReflectionProbes_arr;
                         }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
