using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HBS;
using CielaSpike;

[SerializeAttribute]
public class HBLensFlare : MonoBehaviour {

    [Header("Light")]
    public Light l;

    [Header("Color")]
    public bool useGlobalColor;
    public Color globalColor;

    [Header("Distance")]
    public bool useDistance;
    public Vector2 range;
    public Vector2 scale;
    public Color colorFrom;
    public Color colorTo;
    [Header("SoftParticle")]
    public bool useSoftParticle;
    public Vector2 softParticleRange;
    public Vector2 softParticle;

    [Header("Angle")]
    public bool useAngle;
    public bool useVertical;
    public bool useDoubleSided;
    public Vector2 angleRange;
    public Vector2 angleScale;
    public Color angleColorFrom;
    public Color angleColorTo;
    [Header("Time")]
    public bool offAtDay = true;
    public Vector2 blinkTime;
    public bool useBlink;

    [Header("Blend: blends 'scale' and 'color' between 'distance' and 'angle'")]
    public bool blend;

    [Header("Properties")]
    public string shaderColorPropertyName = "_TintColor";
  
    public Vector3 rotationOffset;

}
