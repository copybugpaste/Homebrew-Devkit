using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBGasTurbineEngine : Part {
    [HBS.SerializePartVarAttribute]
    public Single I;
    [HBS.SerializePartVarAttribute]
    public Single electricEngineWatt;
    [HBS.SerializePartVarAttribute]
    public Single fuelConsumption;
    [HBS.SerializePartVarAttribute]
    public TorqueCurve motorTorque;
    [HBS.SerializePartVarAttribute]
    public Single engineGenerateWatt;
    [HBS.SerializePartVarAttribute]
    public TorqueCurve engineTorque;
    [HBS.SerializePartVarAttribute]
    public TorqueCurve outputTorque;
    [HBS.SerializePartVarAttribute]
    public HBAudioLoop motorLoop;
    [HBS.SerializePartVarAttribute]
    public HBAudioLoop engineLoop;
    [HBS.SerializePartVarAttribute]
    public Single internalGear;
    [HBS.SerializePartVarAttribute]
    public Light lightEffect;
    [HBS.SerializePartVarAttribute]
    public Transform[] rotatables;
    [HBS.SerializePartVarAttribute]
    public AudioClip engineThrottleLoop;
    [HBS.SerializePartVarAttribute]
    public AudioClip engineIdleLoop;
}
