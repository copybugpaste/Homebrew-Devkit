using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBPropellor : Part {
    [HBS.SerializePartVarAttribute]
    public Transform nozzle;
    [HBS.SerializePartVarAttribute]
    public Boolean isSupersonicPropeller;
    [HBS.SerializePartVarAttribute]
    public Int32 bladeCount;
    [HBS.SerializePartVarAttribute]
    public Single bladePitch;
    [HBS.SerializePartVarAttribute]
    public Single bladeChord;
    [HBS.SerializePartVarAttribute]
    public Single bladeRadius;
    [HBS.SerializePartVarAttribute]
    public Single nozzleWeight;
    [HBS.SerializePartVarAttribute]
    public Single bladeScale;
    [HBS.SerializePartVarAttribute]
    public Single nozzleScale;
    [HBS.SerializePartVarAttribute]
    public Single bladeWeight;
}
