using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBHotAirBalloon : Part {
    [HBS.SerializePartVarAttribute]
    public Single maxLiftForce;
    [HBS.SerializePartVarAttribute]
    public Transform[] releaseRotators;
    [HBS.SerializePartVarAttribute]
    public Vector3 releaseRotatorsAxis;
    [HBS.SerializePartVarAttribute]
    public Single fuelConsumption;
    [HBS.SerializePartVarAttribute]
    public GameObject burnEffect;
    [HBS.SerializePartVarAttribute]
    public AudioClip burnLoop;
    [HBS.SerializePartVarAttribute]
    public Transform thrustPivot;
}
