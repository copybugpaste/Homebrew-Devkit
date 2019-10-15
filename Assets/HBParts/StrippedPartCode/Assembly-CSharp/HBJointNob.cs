using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBJointNob : Part {
    [HBS.SerializePartVarAttribute]
    public Boolean isNew;
    [HBS.SerializePartVarAttribute]
    public AudioClip pistonSound;
    [HBS.SerializePartVarAttribute]
    public Single minVolume;
    [HBS.SerializePartVarAttribute]
    public Single maxVolume;
    [HBS.SerializePartVarAttribute]
    public Single minPitch;
    [HBS.SerializePartVarAttribute]
    public Single maxPitch;
    [HBS.SerializePartVarAttribute]
    public Single maxAudioMovement;
    [HBS.SerializePartVarAttribute]
    public Single audioFac;
    [HBS.SerializePartVarAttribute]
    public Transform jointPivot;
    [HBS.SerializePartVarAttribute]
    public SpringTransform[] currentSprings;
}
