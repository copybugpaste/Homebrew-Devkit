using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HBS.Serialize]
[System.Serializable]
public class RevAudioClip {

    public AudioClip clip;

    [System.NonSerialized]
    public float[] samples;

    public string name;
    public float length;
    public int channels;
    public int sampleCount;
    
    public bool isReady {
        get {
            return _isReady;
        }
    }
    private bool _isReady = false;
    public System.Action onReady;

    public void SetReady() {
        
        _isReady = true;
        if( onReady != null ) { onReady(); }
    }

    public void BakeAudioClip() {

        if (clip == null) {
            Debug.LogError("RevAudioClip: clip is null, can't bake it, possibly its already baked!");
            return;
        }
        if (clip.length * 0.5f > 15f) {
            Debug.LogError("RevAudioClip: clip: " + clip.name + " is longer then 15 secs, can't bake it");
            return;
        }

        samples = new float[clip.samples * clip.channels];
        clip.GetData(samples, 0);
        sampleCount = samples.Length;
        channels = clip.channels;
        length = clip.length;
        name = clip.name;
        SetReady();

    }

}
