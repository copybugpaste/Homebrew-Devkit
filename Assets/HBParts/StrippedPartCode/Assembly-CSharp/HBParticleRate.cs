using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBParticleRate : Part {
    [HBS.SerializePartVarAttribute]
    public Single watt;
    [HBS.SerializePartVarAttribute]
    public Transform particlePivot;
    [HBS.SerializePartVarAttribute]
    public GameObject particleGameObject;
}
