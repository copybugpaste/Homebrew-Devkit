using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBFuelTank : Part {
    [HBS.SerializePartVarAttribute]
    public Single combustionFactor;
    [HBS.SerializePartVarAttribute]
    public Single burnRate;
    [HBS.SerializePartVarAttribute]
    public Single weightPerLiter;
    [HBS.SerializePartVarAttribute]
    public Bounds fuelBounds;
}
