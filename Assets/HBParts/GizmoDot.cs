using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDot : MonoBehaviour {

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawSphere(Vector3.zero, 0.05f);
    }
}
