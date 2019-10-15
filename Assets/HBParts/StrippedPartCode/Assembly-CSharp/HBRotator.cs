using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBRotator : Part {
    [HBS.SerializePartVarAttribute]
    public Transform target;
    [HBS.SerializePartVarAttribute]
    public Vector3 targetLocalRotationAxis;
    [HBS.SerializePartVarAttribute]
    public Quaternion initialRotation;
    [HBS.SerializePartVarAttribute]
    public Boolean useNewRotationMethod;
}
