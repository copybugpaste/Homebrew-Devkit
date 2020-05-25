/* Copyright (C) CopyBugPaste - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[HBS.Serialize]
public class EngineAudioClip : MonoBehaviour {

    public static readonly int engineSampleRate = 44100;

    [System.NonSerialized]
    public bool ready = false;

    [Header("Animated Values")]
    [Range(0, 1)]
    public float throttle = 0f;
    [Range(0, 1)]
    public float shift = 0f;
    [Range(0, 1)]
    public float accel = 0f;
    [Range(0, 1)]
    public float turbo = 0f;
    [Range(0, 1)]
    public float turboBlowoffValve = 0f;
    [Range(0, 1)]
    public float weight = 1f;

    [Header("Ignition")]
    public bool useIgnition = true;
    public AudioEntry igniteAudio;
    public AudioEntry unIgniteAudio;
    public float igniteFadeDelay = 0.5f;
    public float igniteFadeSpeed = 5f;


    [Header("Gears")]
    public bool useGearShiftSound = true;
    public float shiftGearThrottleDelay = 0.05f;
    public AudioEntry gearShiftAudio;

    [Header("Turbo")]
    public bool useTurboSound = true;
    public float additionalTurboPitch = 0.2f;
    public AudioEntry turboAudio;
    public AudioEntry turboBlowoffValveAudio;

    [Header("Internal Turbo Simulation")]
    public bool useInternalTurboSimulation = true;
    public TurboSim turboSim;

    [Header("Exhaust pops")]
    public bool useExhaustPops = true;
    public AudioEntry[] exhaustPops;

    [Header("Internal Exhaust Pop Simulation")]
    public bool useInternalExhaustPopSimulation = true;
    public ExhaustPopSim exhaustPopSim;

    [Header("Rev")]
    public AudioEntry[] entries;

    [Header("Audio Filters")]
    public Filter parametricEqualizerA;
    public Filter parametricEqualizerB;

    [Header("References")]
    public AudioSource source;
    
    [Header("Visual Help")]
    public bool showHelpers = true;
    public float helperIdleRPM = 830;
    public float helperRedlineRPM = 8300;

    private AudioEntry activeEntryA = null;
    private AudioEntry activeEntryB = null;

    private double audioStartTime = 0f;

    private int prevExhaustPopIndex = 0;

    private float shiftGearTime = 0f;

    private bool isOn = false;
    private bool isShutDown = true;
    private float isOnTime = 0f;
    private float isOnWeight = 0f;

    private void Start() {
        if (useInternalExhaustPopSimulation) {
            exhaustPopSim.onExhaustPop = ExhaustPop;
        }
    }

    [ContextMenu("BakeAudioClips")]
    public void BakeAudioClips() {
        var aa = GetAllAduioEntries();
        foreach (var a in aa) {
            if (a == null || a.clip == null) { continue; }
            a.BakeAudioClip();
        }
    }
    
    private bool CheckReady() {
        var aa = GetAllAduioEntries();
        foreach (var a in aa) {
            if( a == null || a.clip == null || a.clip.samples == null || a.clip.samples.Length == 0 || a.clip.loading) { return false; }
        }
        return true;
    }

    [ContextMenu("IgniteEngine")]
    public void IgniteEngine() {
        if (isOn == false) {
            isOn = true;
            isShutDown = false;
            igniteAudio.PlayOneShot();
            isOnTime = Time.time;
        }
    }
    [ContextMenu("UnIgniteEngine")]
    public void UnIgniteEngine() {
        if (isOn) {
            isOn = false;
        }
    }

    public void ShiftGear() {
        shiftGearTime = Time.time + shiftGearThrottleDelay;

        if (useGearShiftSound) {
            gearShiftAudio.PlayOneShot();
        }
    }

    public void ExhaustPop() {
        if (useExhaustPops) {
            if (exhaustPops != null) {
                AudioEntry pop = null;
                var tries = 0;
                var ii = 0;
                while (pop == null && tries < 10) {
                    ii = Mathf.FloorToInt(Random.value * exhaustPops.Length);
                    pop = exhaustPops[ii];
                    if (pop.playingOneShot) { pop = null; }
                    if (ii == prevExhaustPopIndex && exhaustPops.Length > 1) { pop = null; }
                    tries++;
                }
                if (pop != null) {
                    pop.PlayOneShot();
                    prevExhaustPopIndex = ii;
                }
            }
        }
    }

    private void Update() {

        if (!ready) {
            ready = CheckReady();
            if (ready) {
                audioStartTime = AudioSettings.dspTime + 1.5f;
            }
            return;
        }

        var _accel = Mathf.Clamp01(accel);
        var _throttle = Mathf.Clamp01(throttle);
        var _shift = Mathf.Clamp01(shift);

        _accel = Time.time < shiftGearTime ? 0 : _accel;
        _throttle = Time.time < shiftGearTime ? 0 : _throttle;

        parametricEqualizerA.shift = _accel;
        parametricEqualizerB.shift = _accel;

        if (useIgnition) {
            if (isOn ) {
                if( Time.time > isOnTime + igniteFadeDelay ) {
                    isOnWeight = Mathf.MoveTowards(isOnWeight, 1, igniteFadeSpeed * Time.deltaTime);
                }
            } else {
                if(isShutDown == false && _shift < entries[0].endShift) {
                    isShutDown = true;
                    unIgniteAudio.PlayOneShot();
                }
                isOnWeight = Mathf.MoveTowards(isOnWeight, 0, igniteFadeSpeed * Time.deltaTime);
            }
        }

        if (useTurboSound && useInternalTurboSimulation) {
            turboSim.throttle = _throttle;
            turboSim.Update();
            turbo = turboSim.smoothTurboShift;
            turboBlowoffValve = turboSim.smoothTurboBlowoffValveShift;
        }

        if (useExhaustPops && useInternalExhaustPopSimulation) {
            exhaustPopSim.shift = _shift;
            exhaustPopSim.throttle = _throttle;
            exhaustPopSim.Update();
        }

        
    }

    private void OnAudioFilterRead(float[] s_d, int channels) {

        if (!ready) { return; }

        var _shift = Mathf.Clamp01(shift);
        var _turbo = Mathf.Clamp01(turbo);
        var _turboBlowoffValve = Mathf.Clamp01(turboBlowoffValve);

        //overall fade
        var overallFadeSquared = Mathf.Clamp01((float)(AudioSettings.dspTime - audioStartTime) * 2f);

        //exhaust pops        
        if (exhaustPops != null) {
            for (var i = 0; i < exhaustPops.Length; i++) {
                exhaustPops[i].HandleOneShotOnAudioThread();
            }
        }

        //turbo
        if (useTurboSound) {
            var fA = Mathf.InverseLerp(turboAudio.startShift, turboAudio.endShift, _turbo);
            turboAudio.pitch = Mathf.Sqrt(Mathf.Lerp(turboAudio.startPitch, turboAudio.endPitch, fA)) + Mathf.Lerp(0, additionalTurboPitch, _shift);
            turboAudio.weight = Mathf.Sqrt(fA);

            var fB = Mathf.InverseLerp(turboBlowoffValveAudio.startShift, turboBlowoffValveAudio.endShift, _turboBlowoffValve);
            turboBlowoffValveAudio.pitch = Mathf.Sqrt(Mathf.Lerp(turboBlowoffValveAudio.startPitch, turboBlowoffValveAudio.endPitch, fB));
            turboBlowoffValveAudio.weight = Mathf.Sqrt(fB);
        }

        //gear
        if( useGearShiftSound ) {
            gearShiftAudio.HandleOneShotOnAudioThread();

            if (gearShiftAudio.playingOneShot) {
                var fA = Mathf.InverseLerp(gearShiftAudio.startShift, gearShiftAudio.endShift, _shift);
                gearShiftAudio.weight = Mathf.Sqrt(Mathf.Lerp(0, 1, fA));
            }
        }

        //ignition
        if (useIgnition) {
            igniteAudio.HandleOneShotOnAudioThread();
            unIgniteAudio.HandleOneShotOnAudioThread();
        }

        //rev
        activeEntryA = null;
        activeEntryB = null;
        
        var activeEntryAIsIdle = false;
        var activeEntryBIsIdle = false;

        if (entries != null) {
            
            for (var i = 0; i < entries.Length; i++) {
                var a = entries[i];
                if (_shift >= a.startShift && _shift <= a.endShift) {
                    if (activeEntryA == null) {
                        activeEntryA = a;
                        if( useIgnition && i == 0 ) { activeEntryAIsIdle = true; }
                        continue;
                    }
                    if (activeEntryB == null) {
                        activeEntryB = a;
                        if (useIgnition && i == 0) { activeEntryBIsIdle = true; }
                        break;
                    }
                }
            }

            if (activeEntryA != null) {

                if (activeEntryB == null) {
                    //no fade

                    var fA = Mathf.InverseLerp(activeEntryA.startShift, activeEntryA.endShift, _shift);
                    activeEntryA.pitch = Mathf.Lerp(activeEntryA.startPitch, activeEntryA.endPitch, fA);

                    activeEntryA.weight = 1f;
                    
                    if( activeEntryAIsIdle ) {
                        activeEntryA.weight *= Mathf.Sqrt(isOnWeight);
                    }
                } else {
                    //cross fade

                    if (activeEntryA.endShift < activeEntryB.endShift) {
                        activeEntryA.weight = Mathf.Sqrt(1f - Mathf.InverseLerp(activeEntryB.startShift, activeEntryA.endShift, _shift));
                        activeEntryB.weight = Mathf.Sqrt(Mathf.InverseLerp(activeEntryB.startShift, activeEntryA.endShift, _shift));
                    } else {
                        activeEntryA.weight = Mathf.Sqrt(Mathf.InverseLerp(activeEntryA.startShift, activeEntryB.endShift, _shift));
                        activeEntryB.weight = Mathf.Sqrt(1f - Mathf.InverseLerp(activeEntryA.startShift, activeEntryB.endShift, _shift));
                    }

                    if (activeEntryAIsIdle) {
                        activeEntryA.weight *= Mathf.Sqrt(isOnWeight);
                    }
                    if (activeEntryBIsIdle) {
                        activeEntryB.weight *= Mathf.Sqrt(isOnWeight);
                    }

                    var fA = Mathf.InverseLerp(activeEntryA.startShift, activeEntryA.endShift, _shift);
                    activeEntryA.pitch = Mathf.Lerp(activeEntryA.startPitch, activeEntryA.endPitch, fA);

                    var fB = Mathf.InverseLerp(activeEntryB.startShift, activeEntryB.endShift, _shift);
                    activeEntryB.pitch = Mathf.Lerp(activeEntryB.startPitch, activeEntryB.endPitch, fB);
                }
            }
        }

        for (var s_i = 0; s_i < s_d.Length; s_i += channels) {

            //rev
            if (activeEntryA != null) {
                if (activeEntryB == null) {
                    //no fade

                    s_d[s_i] = activeEntryA.GetSample(0);

                    if (channels == 2) {
                        s_d[s_i + 1] = activeEntryA.GetSample(1);
                    }

                    activeEntryA.position = (activeEntryA.position + activeEntryA.pitch) % 10000000d;

                } else {
                    //cross fade

                    s_d[s_i] = activeEntryA.GetSample(0) +
                               activeEntryB.GetSample(0);

                    if (channels == 2) {
                        s_d[s_i + 1] = activeEntryA.GetSample(1) +
                                       activeEntryB.GetSample(1);
                    }

                    activeEntryA.position = (activeEntryA.position + activeEntryA.pitch) % 10000000d;
                    activeEntryB.position = (activeEntryB.position + activeEntryB.pitch) % 10000000d;
                }
            }

            //gear
            if( useGearShiftSound ) {
                if (gearShiftAudio.playingOneShot) {
                    //gear thud
                    s_d[s_i] += gearShiftAudio.GetSample(0);

                    if (channels == 2) {
                        s_d[s_i + 1] += gearShiftAudio.GetSample(1);
                    }

                    gearShiftAudio.position = (gearShiftAudio.position + 1d) % 10000000d;
                }
            }
            

            //ignition
            if( useIgnition ) {
                if( igniteAudio.playingOneShot ) {
                    s_d[s_i] += igniteAudio.GetSample(0);

                    if (channels == 2) {
                        s_d[s_i + 1] += igniteAudio.GetSample(1);
                    }
                    igniteAudio.position = (igniteAudio.position + 1d) % 10000000d;
                }
                if (unIgniteAudio.playingOneShot) {
                    s_d[s_i] += unIgniteAudio.GetSample(0);

                    if (channels == 2) {
                        s_d[s_i + 1] += unIgniteAudio.GetSample(1);
                    }
                    unIgniteAudio.position = (unIgniteAudio.position + 1d) % 10000000d;
                }
            }

            //filter
            if (!parametricEqualizerA.bypass) {
                s_d[s_i] = parametricEqualizerA.Transform(s_d[s_i]);
            }
            if (!parametricEqualizerB.bypass) {
                s_d[s_i] = parametricEqualizerB.Transform(s_d[s_i]);
            }

            if (channels == 2) {
                if (!parametricEqualizerA.bypass) {
                    s_d[s_i + 1] = parametricEqualizerA.Transform(s_d[s_i + 1]);
                }
                if (!parametricEqualizerB.bypass) {
                    s_d[s_i + 1] = parametricEqualizerB.Transform(s_d[s_i + 1]);
                }
            }

            //turbo
            if (useTurboSound) {
                //turbo
                s_d[s_i] += turboAudio.GetSample(0);

                if (channels == 2) {
                    s_d[s_i + 1] += turboAudio.GetSample(1);
                }

                turboAudio.position = (turboAudio.position + turboAudio.pitch) % 10000000d;

                //turbo blow off valve
                s_d[s_i] += turboBlowoffValveAudio.GetSample(0);

                if (channels == 2) {
                    s_d[s_i + 1] += turboBlowoffValveAudio.GetSample(1);
                }

                turboBlowoffValveAudio.position = (turboBlowoffValveAudio.position + turboBlowoffValveAudio.pitch) % 10000000d;
            }

            //exhaust pops
            if (exhaustPops != null) {
                for (var i = 0; i < exhaustPops.Length; i++) {
                    if (exhaustPops[i].playingOneShot) {
                        s_d[s_i] += exhaustPops[i].GetSample(0);

                        if (channels == 2) {
                            s_d[s_i + 1] += exhaustPops[i].GetSample(1);
                        }

                        exhaustPops[i].position = (exhaustPops[i].position + 1d) % 10000000d;
                    }
                }
            }

            //fade in 
            s_d[s_i] *= overallFadeSquared;

            if (channels == 2) {
                s_d[s_i + 1] *= overallFadeSquared;
            }

            //final weight
            s_d[s_i] *= Mathf.Sqrt(Mathf.Clamp01(weight));

            if (channels == 2) {
                s_d[s_i + 1] *= Mathf.Sqrt(Mathf.Clamp01(weight));
            }

        }
    }

    private List<AudioEntry> GetAllAduioEntries() {
        var ret = new List<AudioEntry>();

        if (entries != null) {
            for (var i = 0; i < entries.Length; i++) {
                ret.Add(entries[i]);
            }
        }

        if (exhaustPops != null) {
            for (var i = 0; i < exhaustPops.Length; i++) {
                ret.Add(exhaustPops[i]);
            }
        }

        if (useIgnition) {
            ret.Add(igniteAudio);
            ret.Add(unIgniteAudio);
        }

        if (useGearShiftSound) {
            ret.Add(gearShiftAudio);
        }

        if (useTurboSound) {
            ret.Add(turboAudio);
            ret.Add(turboBlowoffValveAudio);
        }

        return ret;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        if (!showHelpers) { return; }
        if (entries == null) { return; }
        Gizmos.matrix = transform.localToWorldMatrix;

        var colors = new Color[] { new Color(1, 0.5f, 0, 1f), new Color(1, 0.5f, 0, 0.8f), new Color(1, 0.5f, 0, 0.4f), new Color(1, 0.5f, 0, 0.2f), new Color(1, 0.5f, 0, 0.1f) };
        var right = Vector3.right;
        var inc = 3f;
        var a = 0f;
        var ta = 0f;
        var radius = 1.4f;
        Vector3 prePoint;

        for (var i = 0; i < entries.Length; i++) {

            var e = entries[i];

            radius += 0.2f;

            a = -45f + (e.startShift * 270f);
            ta = -45f + (e.endShift * 270f);
            prePoint = Quaternion.Euler(0, 0, a) * right * radius;

            Handles.Label(transform.position + (transform.rotation * Quaternion.Euler(0, 0, a) * right * radius), Mathf.Lerp(helperIdleRPM, helperRedlineRPM, e.startShift).ToString() + " RPM");
            Handles.Label(transform.position + (transform.rotation * Quaternion.Euler(0, 0, ta) * right * radius), Mathf.Lerp(helperIdleRPM, helperRedlineRPM, e.endShift).ToString() + " RPM");

            Gizmos.color = colors[i % colors.Length];

            while (a < ta) {
                a += inc;
                if (a > ta) { a = ta; }
                var point = Quaternion.Euler(0, 0, a) * right * radius;
                Gizmos.DrawLine(prePoint, point);
                prePoint = point;
            }
        }

    }
#endif

    [System.Serializable]
    [HBS.Serialize]
    public class ExhaustPopSim {

        [Header("Animated Values")]
        [HideInInspector]
        [System.NonSerialized]
        public float throttle = 0f;
        [HideInInspector]
        [System.NonSerialized]
        public float shift = 0f;

        [Header("Settings")]
        public float exhaustPopMinThrottle = 0.5f;
        public float exhaustPopMinShiftDecel = 0.5f;
        public float minExhaustPopDelay = 1f;
        public float chanseFactor = 0.5f;

        [Header("Calculated Values")]
        public float popChanse = 0f;
        [System.NonSerialized]
        public System.Action onExhaustPop;

        private float dt;
        private float preShift = 0f;
        private float lastExhaustPopTime = 0f;
        public void Update() {



            dt = Time.smoothDeltaTime;

            var _throttle = Mathf.Clamp01(throttle);
            var _shift = Mathf.Clamp01(shift);

            var decel = -(_shift - preShift) / dt;
            preShift = _shift;

            var throttleFac = 1f - Mathf.InverseLerp(0, exhaustPopMinThrottle, _throttle);
            var shiftFac = Mathf.Max(0, decel - exhaustPopMinShiftDecel); //Mathf.InverseLerp(0, exhaustPopMinShiftDecel, decel);
            popChanse = Mathf.Pow(throttleFac * shiftFac, 2) * chanseFactor;

            if (Random.value < popChanse) {
                if (Time.time < lastExhaustPopTime + minExhaustPopDelay) { return; }
                lastExhaustPopTime = Time.time;
                if (onExhaustPop != null) {
                    onExhaustPop();
                }
            }
        }
    }

    [System.Serializable]
    [HBS.Serialize]
    public class TurboSim {

        [Header("Animated Values")]
        [HideInInspector]
        [System.NonSerialized]
        public float throttle = 0f;

        [Header("Calculated Values")]
        [System.NonSerialized]
        public float smoothTurboShift = 0f;
        [System.NonSerialized]
        public float smoothTurboBlowoffValveShift = 0f;

        [Header("Settings")]
        public float turboAccelShift = 1f;
        public float turboDecelShift = 2f;
        public float turboBlowoffValveExeedingShift = 0.01f;
        public float turboSmoothFactor = 0.25f;
        public float turboBlowoffValveSmoothFactor = 0.15f;

        private float targetTurboShift = 0f;
        private float turboShift = 0f;
        private float blowoffValveShift = 0f;
        private float dt;

        public void Update() {
            dt = Time.smoothDeltaTime;
            targetTurboShift = Mathf.Clamp01(throttle);

            var accelOrDecelSpeed = turboAccelShift;
            if (targetTurboShift < turboShift) {
                accelOrDecelSpeed = turboDecelShift;
            }
            turboShift = Mathf.MoveTowards(turboShift, targetTurboShift, accelOrDecelSpeed * dt);

            if (turboShift > targetTurboShift + turboBlowoffValveExeedingShift) {
                blowoffValveShift = 1f;
            } else {
                blowoffValveShift = 0f;
                smoothTurboBlowoffValveShift = Mathf.Lerp(smoothTurboBlowoffValveShift, blowoffValveShift, 0.7f);
            }

            smoothTurboShift = Mathf.Lerp(smoothTurboShift, turboShift, turboSmoothFactor);
            smoothTurboBlowoffValveShift = Mathf.Lerp(smoothTurboBlowoffValveShift, blowoffValveShift, turboBlowoffValveSmoothFactor);
        }
    }

    [System.Serializable]
    [HBS.Serialize]
    public class AudioEntry {

        public RevAudioClip clip;

        [Range(0, 1)]
        public float volume = 1f;
        [Header("Shift location")]
        [Range(0, 1)]
        public float startShift = 0f;
        [Range(0, 1)]
        public float endShift = 1f;
        [Header("Pitch")]
        [Range(0.2f, 4)]
        public float startPitch = 1f;
        [Range(0.2f, 4)]
        public float endPitch = 1f;
        
        [System.NonSerialized]
        public float weight = 0f;
        [System.NonSerialized]
        public double pitch = 0f;
        [System.NonSerialized]
        public double position = 0f;
        [System.NonSerialized]
        public double oneShotTime = 0d;
        [System.NonSerialized]
        public bool playingOneShot = false;

        public void BakeAudioClip() {

            clip.BakeAudioClip();

        }
        
        public float GetSample(int channel) {
            if (channel > clip.channels - 1) { channel = clip.channels - 1; }
            if (clip.samples == null) {
                return 0f;
            }
            return clip.samples[(int)(System.Math.Floor(position * clip.channels) + channel) % (int)clip.sampleCount] * weight * Mathf.Sqrt(Mathf.Clamp01(volume));
        }

        public void PlayOneShot() {
            oneShotTime = AudioSettings.dspTime + (clip.length * 0.5d);
        }
        public void HandleOneShotOnAudioThread() {
            if (AudioSettings.dspTime < oneShotTime) {
                if (!playingOneShot) {
                    playingOneShot = true;
                    position = 0;
                    weight = 1;
                }
            }
            if (playingOneShot && AudioSettings.dspTime >= oneShotTime) {
                playingOneShot = false;
            }
        }
    }

    [System.Serializable]
    [HBS.Serialize]
    public class Filter {

        public Filter() {
            SetPeakingEq(centerFrequencyA, Mathf.Max(0, octaveRangeA), Mathf.Clamp(dBGainA, 0.05f, 3f));
        }

        public bool bypass = false;

        [Header("Left Shift")]
        public float centerFrequencyA = 8000;
        public float octaveRangeA = 1f;
        public float dBGainA = 1f;

        [Header("Right Shift")]
        public float centerFrequencyB = 8000;
        public float octaveRangeB = 1f;
        public float dBGainB = 1f;

        public float shift {
            get {
                return _shift;
            }
            set {
                _shift = Mathf.Clamp01(value);

                SetPeakingEq(
                Mathf.Lerp(centerFrequencyA, centerFrequencyB, _shift),
                Mathf.Max(0.01f, Mathf.Lerp(octaveRangeA, octaveRangeB, _shift)),
                Mathf.Clamp(Mathf.Lerp(dBGainA, dBGainB, _shift), 0.05f, 3f)
                );
            }
        }

        private float _shift = 0f;

        // state
        private float x1;
        private float x2;
        private float y1;
        private float y2;

        // coefficients
        private double a0;
        private double a1;
        private double a2;
        private double a3;
        private double a4;

        public float Transform(float inSample) {
            // compute result

            var result = a0 * inSample + a1 * x1 + a2 * x2 - a3 * y1 - a4 * y2;

            // shift x1 to x2, sample to x1 
            x2 = x1;
            x1 = inSample;

            // shift y1 to y2, result to y1 
            y2 = y1;
            y1 = (float)result;

            return y1;
        }

        public void SetPeakingEq(float centreFrequency, float q, float dbGain) {
            // H(s) = (s^2 + s*(A/Q) + 1) / (s^2 + s/(A*Q) + 1)
            var w0 = 2 * Mathf.PI * centreFrequency / EngineAudioClip.engineSampleRate;
            var cosw0 = Mathf.Cos(w0);
            var sinw0 = Mathf.Sin(w0);
            var alpha = sinw0 / (2 * q);
            var a = dbGain;// Mathf.Pow(10, dbGain / 40);     // TODO: should we square root this value?

            var b0 = 1 + (alpha * a);
            var b1 = -2 * cosw0;
            var b2 = 1 - (alpha * a);
            var aa0 = 1 + (alpha / a);
            var aa1 = -2 * cosw0;
            var aa2 = 1 - (alpha / a);
            SetCoefficients(aa0, aa1, aa2, b0, b1, b2);
        }

        private void SetCoefficients(double aa0, double aa1, double aa2, double b0, double b1, double b2) {
            a0 = b0 / aa0;
            a1 = b1 / aa0;
            a2 = b2 / aa0;
            a3 = aa1 / aa0;
            a4 = aa2 / aa0;
        }
    }

}

