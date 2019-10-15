using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBSolidRocketMount : Part {
    [HBS.SerializePartVarAttribute]
    public AnimationCurve forceCurve;
    [HBS.SerializePartVarAttribute]
    public AnimationCurve volumeCurve;
    [HBS.SerializePartVarAttribute]
    public Single volumeMultplier;
    [HBS.SerializePartVarAttribute]
    public Gradient effectColor;
    [HBS.SerializePartVarAttribute]
    public AudioClip detachSound;
    [HBS.SerializePartVarAttribute]
    public AudioClip burnLoop;
    [HBS.SerializePartVarAttribute]
    public Transform rocketPivot;
    [HBS.SerializePartVarAttribute]
    public Single totalForceAtDefaultSize;
    [HBS.SerializePartVarAttribute]
    public Single totalBurnTimeAtDefaultSize;
    [HBS.SerializePartVarAttribute]
    public Single watt;
    [HBS.SerializePartVarAttribute]
    public String preRocketName;
    [HBS.SerializePartVarAttribute]
    public GameObject rocketGameObject;
}
