using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBSimpleTransmission : Part {
    [HBS.SerializePartVarAttribute]
    public Single I;
    [HBS.SerializePartVarAttribute]
    public Transform[] inputRotatables;
    [HBS.SerializePartVarAttribute]
    public Transform[] outputRotatables;
    [HBS.SerializePartVarAttribute]
    public Vector3 rotablesAxis;
    [HBS.SerializePartVarAttribute]
    public AudioClip gearSound;
}
