using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBSimpleCombustionEngine : Part {
    [HBS.SerializePartVarAttribute]
    public Single I;
    [HBS.SerializePartVarAttribute]
    public Single electricEngineGeneratorWatt;
    [HBS.SerializePartVarAttribute]
    public Single electricEngineWatt;
    [HBS.SerializePartVarAttribute]
    public Single fuelConsumption;
    [HBS.SerializePartVarAttribute]
    public TorqueCurve engineTorque;
    [HBS.SerializePartVarAttribute]
    public HBAudioLoop engineLoop;
    [HBS.SerializePartVarAttribute]
    public Transform[] rotatables;
    [HBS.SerializePartVarAttribute]
    public String startWWiseLoop;
    [HBS.SerializePartVarAttribute]
    public String stopWWiseLoop;
    [HBS.SerializePartVarAttribute]
    public Single wwiseRPM;
    [HBS.SerializePartVarAttribute]
    public AudioClip engineThrottleLoop;
    [HBS.SerializePartVarAttribute]
    public AudioClip engineIdleLoop;
    [HBS.SerializePartVarAttribute]
    public AudioClip igniteEngine;
    [HBS.SerializePartVarAttribute]
    public AudioClip unigniteEngine;
    [HBS.SerializePartVarAttribute]
    public Single flywheelInertia;
    [HBS.SerializePartVarAttribute]
    public Single clutchMaxTorque;
    [HBS.SerializePartVarAttribute]
    public Single revSmoothInternalAudioThrottleSpeedFactor;
    [HBS.SerializePartVarAttribute]
    public Single revSmoothIneralRPMSpeedFactor;
    [HBS.SerializePartVarAttribute]
    public Boolean useWWise;
    [HBS.SerializePartVarAttribute]
    public Boolean useRev;
}
