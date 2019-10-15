using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBHemiRotator : Part {
    [HBS.SerializePartVarAttribute]
    public Transform target;
    [HBS.SerializePartVarAttribute]
    public Vector3 targetLocalRotationAxis;
    [HBS.SerializePartVarAttribute]
    public Vector3 targetLocalRotationAxis2;
}
