using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBWeapon : Part {
    [HBS.SerializePartVarAttribute]
    public Int32 roundType;
    [HBS.SerializePartVarAttribute]
    public Single Cd;
    [HBS.SerializePartVarAttribute]
    public Single caseDiameterMM;
    [HBS.SerializePartVarAttribute]
    public Single totalLengthMM;
    [HBS.SerializePartVarAttribute]
    public Single slugLengthMM;
    [HBS.SerializePartVarAttribute]
    public Boolean isTracer;
    [HBS.SerializePartVarAttribute]
    public Single accuracyCircleMMat100M;
    [HBS.SerializePartVarAttribute]
    public Int32 roundsPerMinute;
    [HBS.SerializePartVarAttribute]
    public Boolean enableAP;
    [HBS.SerializePartVarAttribute]
    public Boolean enableHE;
    [HBS.SerializePartVarAttribute]
    public Boolean enableHEAT;
    [HBS.SerializePartVarAttribute]
    public Boolean enableSABOT;
    [HBS.SerializePartVarAttribute]
    public Single desiredPenetrationMMRHA;
    [HBS.SerializePartVarAttribute]
    public Transform[] rotatables;
    [HBS.SerializePartVarAttribute]
    public Vector3[] rotatableAxis;
    [HBS.SerializePartVarAttribute]
    public Single[] rotateDegreesPerShot;
    [HBS.SerializePartVarAttribute]
    public Transform[] movables;
    [HBS.SerializePartVarAttribute]
    public Vector3[] movablesAxis;
    [HBS.SerializePartVarAttribute]
    public Single[] movablesDistance;
    [HBS.SerializePartVarAttribute]
    public Int32 Watt;
    [HBS.SerializePartVarAttribute]
    public String firePlay;
    [HBS.SerializePartVarAttribute]
    public String fireStart;
    [HBS.SerializePartVarAttribute]
    public String fireStop;
    [HBS.SerializePartVarAttribute]
    public Vector3 shootOffset;
    [HBS.SerializePartVarAttribute]
    public Vector3 shootDirection;
}
