using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBButton : Part {
    [HBS.SerializePartVarAttribute]
    public Transform[] moveables;
    [HBS.SerializePartVarAttribute]
    public Boolean constantlyUpdateOutputs;
}
