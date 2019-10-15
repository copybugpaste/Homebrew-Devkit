using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBElectricMotor : Part {
    [HBS.SerializePartVarAttribute]
    public Single I;
    [HBS.SerializePartVarAttribute]
    public Single electricEngineTorqueCurveWatt;
    [HBS.SerializePartVarAttribute]
    public TorqueCurve motorTorque;
    [HBS.SerializePartVarAttribute]
    public HBAudioLoop motorLoop;
    [HBS.SerializePartVarAttribute]
    public Transform[] rotatables;
    [HBS.SerializePartVarAttribute]
    public AudioClip engineThrottleLoop;
}
