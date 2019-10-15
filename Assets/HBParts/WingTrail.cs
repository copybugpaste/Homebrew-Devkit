using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HBS.SerializeAttribute]
public class WingTrail : MonoBehaviour {

    public HBWing wing;
    public GameObject obj;
    public TrailRenderer renderer;
    public AnimationCurve curve;
    public float min = 1000;
    public float max = 10000000;
    public float time = 1f;
    public float effect;
    public Color color;
    public Vector3 offset = Vector3.zero;
    

}
