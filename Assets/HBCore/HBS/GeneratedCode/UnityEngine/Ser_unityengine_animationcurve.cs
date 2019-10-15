using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_animationcurve {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.AnimationCurve o = (UnityEngine.AnimationCurve)oo;
            writer.Write(3);

            writer.Write("keys");
            writer_ASXDRGBHU = new HBS.Writer();
            if( writer_ASXDRGBHU.WriteNull(o.keys) == false ) {
                writer_ASXDRGBHU.Write(o.keys.Length);
                for( int i = 0; i < o.keys.Length; i++ ) {
                    HBS.Ser_unityengine_keyframe.Ser( writer_ASXDRGBHU , o.keys[i]); //property
                }
            }
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("preWrapMode");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_wrapmode.Ser( writer_ASXDRGBHU , o.preWrapMode); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("postWrapMode");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_wrapmode.Ser( writer_ASXDRGBHU , o.postWrapMode); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.AnimationCurve o = new UnityEngine.AnimationCurve();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "keys") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        if( reader_ASXDRGBHU.ReadNull() == false ) {
                            UnityEngine.Keyframe[] keys_arr = new UnityEngine.Keyframe[(int)reader_ASXDRGBHU.Read()];
                            for( int i = 0; i < keys_arr.Length; i++ ) {
                                keys_arr[i] = (UnityEngine.Keyframe)HBS.Ser_unityengine_keyframe.Res( reader_ASXDRGBHU ); //property
                            }
                            o.keys = keys_arr;
                        }
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "preWrapMode") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.preWrapMode = (UnityEngine.WrapMode)HBS.Ser_unityengine_wrapmode.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "postWrapMode") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.postWrapMode = (UnityEngine.WrapMode)HBS.Ser_unityengine_wrapmode.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
