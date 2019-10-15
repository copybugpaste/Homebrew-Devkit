using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace HBBuilder {
    [HBS.SerializeAttribute]
    public class Hull : MonoBehaviour {

        public BodyContainer bodyContainer {
            get {
                return GetComponentInParent<BodyContainer>();
            }
        }

	    [HideInInspector]
	    public Vector3[] verts = null;
	    [HideInInspector]
	    public int[] quads = null;
	    [HideInInspector]
	    public int[] tris = null;
	    [HideInInspector]
	    public CurveHandle[] handles;
        [HideInInspector]
        public QuadData[] quadsData;
        [HideInInspector]
        public TriData[] trisData;

	    public Action onChange;

	    //INTERFACE



	    //GL PREVIEW

	    void OnDrawGizmosSelected() {
		    Gizmos.matrix = transform.localToWorldMatrix;
		    Gizmos.color = Color.yellow;
		    if( quads != null ) {
			    for( int i = 0; i < quads.Length; i+=4 ) {
				    Vector3 p1 = verts[quads[i  ]];
				    Vector3 p2 = verts[quads[i+1]];
				    Vector3 p3 = verts[quads[i+2]];
				    Vector3 p4 = verts[quads[i+3]];
				    Gizmos.DrawLine(p1,p2);
				    Gizmos.DrawLine(p2,p3);
				    Gizmos.DrawLine(p3,p4);
				    Gizmos.DrawLine(p4,p1);
			    }
		    }
		    if( tris != null ) {
			    for( int i = 0; i < tris.Length; i+=3 ) {
				    Vector3 p1 = verts[tris[i  ]];
				    Vector3 p2 = verts[tris[i+1]];
				    Vector3 p3 = verts[tris[i+2]];
				    Gizmos.DrawLine(p1,p2);
				    Gizmos.DrawLine(p2,p3);
				    Gizmos.DrawLine(p3,p1);
			    }
		    }
		    if( verts != null ) {
			    for( int i = 0; i < verts.Length; i+= 1) {
				    Gizmos.DrawSphere(verts[i],0.1f);
			    }
		    }
		
	    }
    }

    [HBS.SerializeAttribute]
    public class QuadData {
        public int vertIndex1;
        public int vertIndex2;
        public int vertIndex3;
        public int vertIndex4;
        public string data;
    }

    [HBS.SerializeAttribute]
    public class TriData {
        public int vertIndex1;
        public int vertIndex2;
        public int vertIndex3;
        public string data;
    }
}