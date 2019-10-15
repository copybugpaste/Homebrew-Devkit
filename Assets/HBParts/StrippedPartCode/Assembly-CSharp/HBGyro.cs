using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBGyro : Part {
    [HBS.SerializePartVarAttribute]
    public Single rotSpeed;
    [HBS.SerializePartVarAttribute]
    public Single angularDrag;
    [HBS.SerializePartVarAttribute]
    public Single watt;
    [HBS.SerializePartVarAttribute]
    public Transform[] rotatables;
    [HBS.SerializePartVarAttribute]
    public Vector3 rotatablesAxis;
}
