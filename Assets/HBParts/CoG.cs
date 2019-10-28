using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

[HBS.SerializeAttribute]
public class CoG : MonoBehaviour {

    public float mass;
    public Vector3 cogOffset;

    private void OnDrawGizmosSelected() {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(cogOffset, 0.05f);
    }
}
