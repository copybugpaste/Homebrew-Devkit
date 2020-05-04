using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBGenerator : Part {
    [HBS.SerializePartVarAttribute]
    public Transform[] inputRotatables;
    [HBS.SerializePartVarAttribute]
    public Transform[] outputRotatables;
    [HBS.SerializePartVarAttribute]
    public Vector3 rotatablesAxis;
}
