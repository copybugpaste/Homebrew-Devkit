using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBRocketEngine : Part {
    [HBS.SerializePartVarAttribute]
    public Single minPitch;
    [HBS.SerializePartVarAttribute]
    public Single maxPitch;
    [HBS.SerializePartVarAttribute]
    public Single minVolume;
    [HBS.SerializePartVarAttribute]
    public Single maxVolume;
    [HBS.SerializePartVarAttribute]
    public Single maxThrust;
    [HBS.SerializePartVarAttribute]
    public Single consumerRate;
    [HBS.SerializePartVarAttribute]
    public Transform thrustPivot;
    [HBS.SerializePartVarAttribute]
    public Gradient burnColor;
    [HBS.SerializePartVarAttribute]
    public AudioClip rocketLoop;
    [HBS.SerializePartVarAttribute]
    public GameObject curBurnEffect;
}
