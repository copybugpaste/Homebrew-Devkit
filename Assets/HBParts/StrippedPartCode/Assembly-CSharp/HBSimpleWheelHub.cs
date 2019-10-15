using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBSimpleWheelHub : Part {
    [HBS.SerializePartVarAttribute]
    public Transform wheelPivot;
    [HBS.SerializePartVarAttribute]
    public Transform suspentionBone;
    [HBS.SerializePartVarAttribute]
    public Vector3 suspentionBoneTargetOffset;
    [HBS.SerializePartVarAttribute]
    public Transform steerPivot;
    [HBS.SerializePartVarAttribute]
    public Vector3 steerAxis;
    [HBS.SerializePartVarAttribute]
    public GameObject wheelGameObject;
    [HBS.SerializePartVarAttribute]
    public String preWheelName;
    [HBS.SerializePartVarAttribute]
    public GameObject curArrow;
}
