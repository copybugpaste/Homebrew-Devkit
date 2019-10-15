using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
[Serializable]
public class SpringTransform {
    [HBS.SerializePartVarAttribute]
    public GameObject gameObject;
    [HBS.SerializePartVarAttribute]
    public Transform end;
    [HBS.SerializePartVarAttribute]
    public Transform from;
    [HBS.SerializePartVarAttribute]
    public Transform to;
    [HBS.SerializePartVarAttribute]
    public Joint joint;
    [HBS.SerializePartVarAttribute]
    public Boolean isFixedSpring;
}
