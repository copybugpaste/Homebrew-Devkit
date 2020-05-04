using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBWeight : Part {
    [HBS.SerializePartVarAttribute]
    public Boolean useScaleMethod;
    [HBS.SerializePartVarAttribute]
    public ScaleMethod scaleMethod;
}
