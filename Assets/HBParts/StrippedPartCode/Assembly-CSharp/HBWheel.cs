using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBWheel : Part {
    [HBS.SerializePartVarAttribute]
    public Single radius;
    [HBS.SerializePartVarAttribute]
    public Single width;
    [HBS.SerializePartVarAttribute]
    public Single mass;
    [HBS.SerializePartVarAttribute]
    public Single spring;
    [HBS.SerializePartVarAttribute]
    public Single damp;
    [HBS.SerializePartVarAttribute]
    public Single springLength;
    [HBS.SerializePartVarAttribute]
    public LayerMask hitMask;
    [HBS.SerializePartVarAttribute]
    public Transform visualWheel;
    [HBS.SerializePartVarAttribute]
    public Single sidewaysFrictionFactor;
    [HBS.SerializePartVarAttribute]
    public Single forwardFrictionFactor;
    [HBS.SerializePartVarAttribute]
    public AnimationCurve rollingResistanceCurve;
    [HBS.SerializePartVarAttribute]
    public AnimationCurve sidewaysSlipCurve;
    [HBS.SerializePartVarAttribute]
    public AnimationCurve sidewaysSlipSkidCurve;
    [HBS.SerializePartVarAttribute]
    public AnimationCurve forwardSlipCurve;
    [HBS.SerializePartVarAttribute]
    public Single massMultiplier;
    [HBS.SerializePartVarAttribute]
    public Single radiusMultiplier;
    [HBS.SerializePartVarAttribute]
    public Single widthMultiplier;
}
