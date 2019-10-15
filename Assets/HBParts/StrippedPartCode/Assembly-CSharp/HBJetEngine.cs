using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBJetEngine : Part {
    [HBS.SerializePartVarAttribute]
    public Single minPitch;
    [HBS.SerializePartVarAttribute]
    public Single maxPitch;
    [HBS.SerializePartVarAttribute]
    public Single minVolume;
    [HBS.SerializePartVarAttribute]
    public Single maxVolume;
    [HBS.SerializePartVarAttribute]
    public Single afterburnerVolume;
    [HBS.SerializePartVarAttribute]
    public Single maxThrust;
    [HBS.SerializePartVarAttribute]
    public Single maxSpeed;
    [HBS.SerializePartVarAttribute]
    public Single electricEngineGeneratorWatt;
    [HBS.SerializePartVarAttribute]
    public Single electricEngineWatt;
    [HBS.SerializePartVarAttribute]
    public Single consumerRate;
    [HBS.SerializePartVarAttribute]
    public Single afterburnerExtraFuelConsumerRate;
    [HBS.SerializePartVarAttribute]
    public Transform thrustPivot;
    [HBS.SerializePartVarAttribute]
    public Boolean useAfterburner;
    [HBS.SerializePartVarAttribute]
    public Boolean useVectorTrust;
    [HBS.SerializePartVarAttribute]
    public Vector2 vectorTrustMinMaxPitch;
    [HBS.SerializePartVarAttribute]
    public Vector2 vectorTrustMinMaxYaw;
    [HBS.SerializePartVarAttribute]
    public Transform[] vectorTrustRotatebles;
    [HBS.SerializePartVarAttribute]
    public Single throttleUpTime;
    [HBS.SerializePartVarAttribute]
    public Single throttleDownTime;
    [HBS.SerializePartVarAttribute]
    public Single throttleUpTimeElectric;
    [HBS.SerializePartVarAttribute]
    public Gradient burnColor;
    [HBS.SerializePartVarAttribute]
    public Transform[] rotatables;
    [HBS.SerializePartVarAttribute]
    public Single[] rotatableRatios;
    [HBS.SerializePartVarAttribute]
    public Vector3[] rotatablesAxis;
    [HBS.SerializePartVarAttribute]
    public AudioClip jetEngineLoop;
    [HBS.SerializePartVarAttribute]
    public AudioClip afterburnerLoop;
    [HBS.SerializePartVarAttribute]
    public GameObject curBurnEffect;
}
