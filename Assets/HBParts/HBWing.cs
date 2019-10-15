using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HBS.SerializeAttribute]
public class HBWing : MonoBehaviour {
    //general air drag
    //F = 1/2*p*v^2*A*C   p = density of fluid = 1.200 kg/m^3 v = relative velocty m/S  C = final factor depending on the shape / skin friction / angle of attack
    public Bounds wingBounds {
        get {
            return new Bounds(wingCenterOffset, wingSize);
        }
        set {
            wingSize = value.size;
            wingCenterOffset = value.center;
            wingLocalArea = new Vector3(value.size.y * value.size.z, value.size.x * value.size.z, value.size.x * value.size.y);
        }
    }
    public Vector3 wingSize;
    public Vector3 wingLocalArea;
    public Vector3 wingCenterOffset;
    public Vector3 force = Vector3.zero;
    public float hp = 1f;
    

    private void OnDrawGizmos() {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(wingCenterOffset, 0.2f);
        Gizmos.DrawWireCube(wingBounds.center, wingBounds.size);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(wingCenterOffset,wingCenterOffset + (force * 0.1f));
    }

}
