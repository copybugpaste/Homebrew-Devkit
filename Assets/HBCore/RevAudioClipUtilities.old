using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using CielaSpike;

public static class RevAudioClipUtilities {
    public static string CalcHash( RevAudioClip clip ) {
        var data = new byte[120];
        if( clip.samples != null ) {
            for ( var i = 0; i < 120; i+=4) {
                var x = Mathf.FloorToInt(((float)i / 120f) * (float)clip.samples.Length);
                var sample = BitConverter.GetBytes(clip.samples[x]);
                data[i+0] = sample[0];
                data[i+1] = sample[1];
                data[i+2] = sample[2];
                data[i+3] = sample[3];
            }
        }
        var md5 = MD5.Create();
        var md = md5.ComputeHash(data);
        var hex = BitConverter.ToString(md);
        return "revaudioclip_"+hex.Replace("-", "");
    }
	public static RevAudioClip LoadHra( string path ) {
        RevAudioClip clip = new RevAudioClip();
        LoadHraOntoRevAudioClip(path, clip);
        return clip;
    }
    public static void LoadHraOntoRevAudioClip(string path, RevAudioClip clip) {
        if (string.IsNullOrEmpty(path)) { return; }
        if (System.IO.File.Exists(path) == false) { return; }
        using (var fileReader = File.Open(path, FileMode.Open)) {
            using (var reader = new BinaryReader(fileReader)) {
                if (reader.ReadBoolean() == true) {
                    clip.length = reader.ReadSingle();
                    clip.channels = reader.ReadInt32();
                    clip.name = reader.ReadString();
                    clip.sampleCount = reader.ReadInt32();
                    clip.samples = new float[reader.ReadInt32()];
                    for (var i = 0; i < clip.samples.Length; i++) {
                        clip.samples[i] = reader.ReadSingle();
                    }
                }
            }
        }
        clip.SetReady();
    }
    public static IEnumerator LoadHraOntoRevAudioClipAsync(string path, RevAudioClip clip) {
        yield return Ninja.JumpBack;

        if (string.IsNullOrEmpty(path)) { yield break; }
        if (System.IO.File.Exists(path) == false) { yield break; }
        
        using (var fileReader = File.Open(path, FileMode.Open)) {
            using (var reader = new BinaryReader(fileReader)) {
                if (reader.ReadBoolean() == true) {
                    clip.length = reader.ReadSingle();
                    clip.channels = reader.ReadInt32();
                    clip.name = reader.ReadString();
                    clip.sampleCount = reader.ReadInt32();
                    clip.samples = new float[reader.ReadInt32()];
                    for (var i = 0; i < clip.samples.Length; i++) {
                        clip.samples[i] = reader.ReadSingle();
                    }
                    
                }
            }
        }
        clip.SetReady();
        
    }
    public static void SaveHra(RevAudioClip clip, string path) {
        if (clip == null) { return; }
        
        using (var filestream = File.Open(path, FileMode.Create)) {
            using (var writer = new BinaryWriter(filestream)) {
                writer.Write(clip.samples != null);
                if (clip.samples == null) { return; }
                if (string.IsNullOrEmpty(clip.name)) { clip.name = "revclip"; }
                writer.Write(clip.length);
                writer.Write(clip.channels);
                writer.Write(clip.name);
                writer.Write(clip.sampleCount);
                writer.Write(clip.samples.Length);
                for (var i = 0; i < clip.samples.Length; i++) {
                    writer.Write(clip.samples[i]);
                }
            }
        }
    }
    public static IEnumerator SaveHraAsync(RevAudioClip clip, System.Action<MemoryStream> onReturn) {
        yield return Ninja.JumpBack;
        if (clip == null) { Debug.Log("tf"); yield break; }
        using (var filestream = new MemoryStream()) {
            using (var writer = new BinaryWriter(filestream)) {
                writer.Write(clip.samples != null);
                if ( clip.samples == null ) { yield break; }

                if ( string.IsNullOrEmpty(clip.name)) { clip.name = "revclip"; }
                writer.Write(clip.length);
                writer.Write(clip.channels);
                writer.Write(clip.name);
                writer.Write(clip.sampleCount);
                writer.Write(clip.samples.Length);
                for ( var i = 0; i < clip.samples.Length; i++ ) {
                    writer.Write(clip.samples[i]);
                }
            }
            onReturn(filestream);
        }

    }
}
