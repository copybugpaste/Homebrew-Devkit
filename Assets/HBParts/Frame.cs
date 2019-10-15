/* 

Frame module, for making vehicle pipe frames , could be used for other stuff
essentially this is like a mesh but instead of triangles we have lines 

funcs for [adding , inserting , moving , removing] are included along with raycasting funcs for verts + lines   

//feel free to alter verts/lines array directly like we do with meshes

//it wont generate a mesh for the frame, other modules can handle this
//we probably want difrent meshes per line, therefore this is only the base module 

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace HBBuilder {
    [HBS.SerializeAttribute]
    public class Frame : MonoBehaviour {

        public BodyContainer bodyContainer {
            get {
                return GetComponentInParent<BodyContainer>();
            }
        }

	    [HideInInspector]
	    public Vector3[] verts;
	    [HideInInspector]
	    public int[] lines;
	    [HideInInspector]
	    public CurveHandle[] handles;
        [HideInInspector]
        public LineData[] linesData;

	    public Action onChange;
	

	    //GL PREVIEW

	    void OnDrawGizmosSelected() {
		    Gizmos.matrix = transform.localToWorldMatrix;
		    Gizmos.color = Color.yellow;
		    if( lines != null ) {
			    for( int i = 0; i < lines.Length; i+=2 ) {
				    Vector3 p1 = verts[lines[i]];
				    Vector3 p2 = verts[lines[i+1]];
				    Gizmos.DrawLine(p1,p2);
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
    public class LineData {
        public int vertIndex1;
        public int vertIndex2;
        public string data;
    }
}