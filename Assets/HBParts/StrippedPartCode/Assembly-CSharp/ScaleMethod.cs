using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HBS.Serialize]
[System.Serializable]
public class ScaleMethod {

    public GameObject[] discs;
    public float discMassToOneScale = 200f;
    public float discThicknessToOneScale = 0.05f;
    public int maxDiscCount = 10;
    public Vector3 localStackAxis = Vector3.forward;
    
}