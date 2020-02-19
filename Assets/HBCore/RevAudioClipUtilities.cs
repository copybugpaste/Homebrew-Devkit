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
        if( clip.clip != null ) {
            var samples = new float[clip.clip.samples * clip.clip.channels];
            clip.clip.GetData(samples, 0);
            for ( var i = 0; i < 120; i+=4) {
                var x = Mathf.FloorToInt(((float)i / 120f) * (float)samples.Length);
                var sample = BitConverter.GetBytes(samples[x]);
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
                if( reader.ReadBoolean() == true) {
                    clip.name = reader.ReadString();
                    var count = reader.ReadInt32();
                    var samples = new float[count];
                    for (var i = 0; i < count; i++) {
                        samples[i] = reader.ReadSingle();
                    }
                    var newClip = new AudioClip() { name = clip.name };
                    newClip.SetData(samples, 0);
                    clip.clip = newClip;
                }
            }
        }
        clip.SetReady();
    }
    public static IEnumerator LoadH3dOntoMeshAsync(string path, RevAudioClip clip) {
        yield return Ninja.JumpBack;

        if (string.IsNullOrEmpty(path)) { yield break; }
        if (System.IO.File.Exists(path) == false) { yield break; }
        
        using (var fileReader = File.Open(path, FileMode.Open)) {
            using (var reader = new BinaryReader(fileReader)) {
                if (reader.ReadBoolean() == true) {
                    clip.name = reader.ReadString();
                    var count = reader.ReadInt32();
                    var samples = new float[count];
                    for (var i = 0; i < count; i++) {
                        samples[i] = reader.ReadSingle();
                    }
                    clip.clip = new AudioClip() { name = clip.name };
                    clip.clip.SetData(samples, 0);
                }
            }
        }
        clip.SetReady();

    }
    public static void SaveHra(RevAudioClip clip, string path) {
        if (clip == null) { return; }
        using (var filestream = File.Open(path, FileMode.Create)) {
            using (var writer = new BinaryWriter(filestream)) {
                writer.Write(clip.clip != null);
                if( clip.clip != null ) {
                    writer.Write(clip.name);
                    var samples = new float[clip.clip.samples * clip.clip.channels];
                    clip.clip.GetData(samples, 0);
                    writer.Write(samples.Length);
                    foreach( var s in samples ) {
                        writer.Write(s);
                    }
                }
            }
        }
    }
}
