using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBBlendShape : Part {
    [HBS.SerializePartVarAttribute]
    public SkinnedMeshRenderer[] renderers;
    [HBS.SerializePartVarAttribute]
    public Boolean useLoop;
    [HBS.SerializePartVarAttribute]
    public Boolean usePingPong;
    [HBS.SerializePartVarAttribute]
    public Boolean useSine;
    [HBS.SerializePartVarAttribute]
    public Boolean useCenteredValue;
    [HBS.SerializePartVarAttribute]
    public Single loopSpeed;
    [HBS.SerializePartVarAttribute]
    public Single weightStrength;
}
