
using System.Collections.Generic;
using UnityEngine;

[HBS.SerializeAttribute]
public class BuoyancySolver : MonoBehaviour
{

    public Bounds bounds;
 
    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
    
}