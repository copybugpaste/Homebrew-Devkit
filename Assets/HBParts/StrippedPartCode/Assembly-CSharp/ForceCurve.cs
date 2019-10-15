using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
[Serializable]
public class ForceCurve {
    [HBS.SerializePartVarAttribute]
    public AnimationCurve curve;
    [HBS.SerializePartVarAttribute]
    public Single maxSpeed;
    [HBS.SerializePartVarAttribute]
    public Single maxForce;
}
