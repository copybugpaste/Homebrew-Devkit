using UnityEngine;
using UnityEngine.UI;
using System;
namespace HBS {
    public static class Ser_unityengine_ui_spritestate {
        public static void Ser( HBS.Writer writer , object oo ) {
            if( writer.WriteNull(oo)) { return; }
            HBS.Writer writer_ASXDRGBHU;
            UnityEngine.UI.SpriteState o = (UnityEngine.UI.SpriteState)oo;
            writer.Write(3);

            writer.Write("highlightedSprite");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_sprite.Ser( writer_ASXDRGBHU , o.highlightedSprite); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("pressedSprite");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_sprite.Ser( writer_ASXDRGBHU , o.pressedSprite); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();

            writer.Write("disabledSprite");
            writer_ASXDRGBHU = new HBS.Writer();
            HBS.Ser_unityengine_sprite.Ser( writer_ASXDRGBHU , o.disabledSprite); //property
            writer.Write(writer_ASXDRGBHU.stream.ToArray());
            writer_ASXDRGBHU.Close();
        }
        public static object Res( HBS.Reader reader, object oo = null) {
            if(reader.ReadNull()){ return null; }
            HBS.Reader reader_ASXDRGBHU;
            UnityEngine.UI.SpriteState o = new UnityEngine.UI.SpriteState();
            int count_ASXDRGBHU = (int)reader.Read();
            for (int i_ASXDRGBHU = 0; i_ASXDRGBHU < count_ASXDRGBHU; i_ASXDRGBHU++) {
                string name_ASXDRGBHU = "";
                byte[] data_ASXDRGBHU = null;
                try {
                    name_ASXDRGBHU = (string)reader.Read();
                    data_ASXDRGBHU = (byte[])reader.Read();
                } catch { continue; }

                if (name_ASXDRGBHU == "highlightedSprite") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.highlightedSprite = (UnityEngine.Sprite)HBS.Ser_unityengine_sprite.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "pressedSprite") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.pressedSprite = (UnityEngine.Sprite)HBS.Ser_unityengine_sprite.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }

                if (name_ASXDRGBHU == "disabledSprite") {
                    try {
                        reader_ASXDRGBHU = new HBS.Reader(data_ASXDRGBHU);
                        o.disabledSprite = (UnityEngine.Sprite)HBS.Ser_unityengine_sprite.Res( reader_ASXDRGBHU ); //property
                        reader_ASXDRGBHU.Close();
                    } catch { }
                }
            }
            return (object)o;
        }
    }
}
