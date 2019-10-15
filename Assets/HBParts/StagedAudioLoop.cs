using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[HBS.SerializeAttribute]
public class StagedAudioLoop : MonoBehaviour {

    public UnityEngine.Audio.AudioMixerGroup mixer;
    public float volume = 1f;
    public float pitch = 1f;
    public Stage[] stages;
    public bool useAudioSourceParented = false;


    [HBS.SerializeAttribute]
    [System.Serializable]
    public class Stage {

        public AudioClip clip;
        public float bleed = 0.1f;
        public float fromVolume = 1f;
        public float toVolume = 1f;
        public float fromPitch = 1f;
        public float toPitch = 1f;
        public float toFactor = 1f;

    }
}
