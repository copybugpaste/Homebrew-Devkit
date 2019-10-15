using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBHinge : Part {
    [HBS.SerializePartVarAttribute]
    public Vector3 targetLocalRotationAxis;
    [HBS.SerializePartVarAttribute]
    public Transform pivot;
    [HBS.SerializePartVarAttribute]
    public HingeJoint joint;
    [HBS.SerializePartVarAttribute]
    public GameObject jointTarget;
    [HBS.SerializePartVarAttribute]
    public GameObject rotationGizmo;
    [HBS.SerializePartVarAttribute]
    public GameObject limitMinGizmo;
    [HBS.SerializePartVarAttribute]
    public GameObject limitMaxGizmo;
}
