using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBSimpleHelicopterPropellorHub : Part {
    [HBS.SerializePartVarAttribute]
    public Transform propellorPivot;
    [HBS.SerializePartVarAttribute]
    public Single I;
    [HBS.SerializePartVarAttribute]
    public GameObject propellorGameObject;
    [HBS.SerializePartVarAttribute]
    public String prePropellorName;
}
