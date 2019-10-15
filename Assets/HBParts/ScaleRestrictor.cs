using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[HBS.SerializeAttribute]
public class ScaleRestrictor : MonoBehaviour {

	public ScaleRestriction scaleRestriction = ScaleRestriction.Fixed;
	public Vector3 minScale = new Vector3(0.5f,0.5f,0.5f);
	public Vector3 maxScale = new Vector3(2f,2f,2f);
    
}

[HBS.SerializeAttribute]
public enum ScaleRestriction {
	Limited,
	LimitedUniform,
	UnlimitedUniform,
	None,
	Fixed,
}