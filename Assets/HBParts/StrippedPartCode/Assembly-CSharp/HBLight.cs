using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBLight : Part {
    [HBS.SerializePartVarAttribute]
    public Light myLight;
    [HBS.SerializePartVarAttribute]
    public Single watt;
    [HBS.SerializePartVarAttribute]
    public String hexColor;
    [HBS.SerializePartVarAttribute]
    public Single _r;
    [HBS.SerializePartVarAttribute]
    public Single _g;
    [HBS.SerializePartVarAttribute]
    public Single _b;
}
