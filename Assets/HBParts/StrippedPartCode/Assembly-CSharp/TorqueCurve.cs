using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
[Serializable]
public class TorqueCurve {
    [HBS.SerializePartVarAttribute]
    public Single idleRPM;
    [HBS.SerializePartVarAttribute]
    public Single torqueAtIdle;
    [HBS.SerializePartVarAttribute]
    public Single heapStartRPM;
    [HBS.SerializePartVarAttribute]
    public Single heapEndRPM;
    [HBS.SerializePartVarAttribute]
    public Single torqueMax;
    [HBS.SerializePartVarAttribute]
    public Single redlineRPM;
    [HBS.SerializePartVarAttribute]
    public Single torqueAtRedline;
    [HBS.SerializePartVarAttribute]
    public Boolean useFlat;
    [HBS.SerializePartVarAttribute]
    public Single flatTorque;
    [HBS.SerializePartVarAttribute]
    public Boolean useLinear;
    [HBS.SerializePartVarAttribute]
    public Single linearMaxRPM;
    [HBS.SerializePartVarAttribute]
    public Single linearTorque;
}
