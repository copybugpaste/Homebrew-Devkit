using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
[Serializable]
public class HBAudioLoop {
    [HBS.SerializePartVarAttribute]
    public Single minPitch;
    [HBS.SerializePartVarAttribute]
    public Single maxPitch;
    [HBS.SerializePartVarAttribute]
    public Single minVolume;
    [HBS.SerializePartVarAttribute]
    public Single maxVolume;
}
