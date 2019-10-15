using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBSteerWheelHub : Part {
    [HBS.SerializePartVarAttribute]
    public Transform steerWheelPivot;
    [HBS.SerializePartVarAttribute]
    public Vector3 steerWheelAxis;
    [HBS.SerializePartVarAttribute]
    public String preSteerWheelName;
    [HBS.SerializePartVarAttribute]
    public GameObject steerWheelGameObject;
    [HBS.SerializePartVarAttribute]
    public GameObject leftHandGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject rightHandGoal;
}
