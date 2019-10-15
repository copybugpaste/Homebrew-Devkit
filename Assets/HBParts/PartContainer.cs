using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace HBBuilder {
    [HBS.SerializeAttribute]
    public class PartContainer : MonoBehaviour {

        public string stringData;

        

        public bool parentLocked = false;

        public bool symmetry = false;
        public GameObject symmetryClone = null;

        public bool symmetrySlave = false;
        public GameObject symmetryOriginal = null;

        public bool preSymmetrySlave = false;
        public GameObject preSymmetryOriginal = null;

        public string symmetryData = "";
    }
//}