using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBBattery : Part {
    [HBS.SerializePartVarAttribute]
    public Single wattHour;
    [HBS.SerializePartVarAttribute]
    public AnimationCurve voltCurve;
}
