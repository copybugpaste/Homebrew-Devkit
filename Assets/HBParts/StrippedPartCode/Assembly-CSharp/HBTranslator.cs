using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBTranslator : Part {
    [HBS.SerializePartVarAttribute]
    public Transform[] movables;
    [HBS.SerializePartVarAttribute]
    public Vector3 localDirection;
}
