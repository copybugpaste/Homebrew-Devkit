using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBGunMount : Part {
    [HBS.SerializePartVarAttribute]
    public Transform target1;
    [HBS.SerializePartVarAttribute]
    public Boolean smooth;
    [HBS.SerializePartVarAttribute]
    public Single rotationSpeed;
}
