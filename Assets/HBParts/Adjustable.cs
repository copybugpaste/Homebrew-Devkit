using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace HBBuilder { 
    [HBS.SerializeAttribute]
    public class Adjustable : MonoBehaviour {
        public string adjustableTypeName;
	    public string data;
        public Node[] nodes;
        public Action onChange;
        
    }

    [System.Serializable]
    [HBS.SerializeAttribute]
    public struct Node {
        public Vector3 position;
        public Quaternion rotation;
        public string data;
        //public Vector3 handle;
        //public Vector3 handle2;

        public Handle[] handles;
        
        
        //public void MoveHandle(int index, Vector3 point, Space space) {
        //    if (handles == null) { return; }
        //    if (space == Space.World) {
        //        point = point - position;
        //    }
        //
        //    if (index >= 0 && index < handles.Length) {
        //        handles[index].position = point;
        //    }
        //}
        //public Vector3 GetHandlePosition(int index, Space space) {
        //    if (handles == null) { return Vector3.zero; }
        //    if (index < 0 || index >= handles.Length) { return Vector3.zero; }
        //    Vector3 p = handles[index].position;
        //    if (space == Space.World) {
        //        p = p + position;
        //    }
        //    return p;
        //}
    }

    [System.Serializable]
    [HBS.SerializeAttribute]
    public struct Handle {
        public Vector3 position;
        public string data;
    }
}