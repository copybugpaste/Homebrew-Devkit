using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 
[HBS.SerializePartAttribute]
public class HBSeat : Part {
    [HBS.SerializePartVarAttribute]
    public GameObject playerGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject playerCameraGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject bodyGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject lookAtGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject leftHandGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject leftHandBendGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject rightHandGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject rightHandBendGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject leftFootGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject leftFootBendGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject rightFootGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject rightFootBendGoal;
    [HBS.SerializePartVarAttribute]
    public GameObject steeringWheelHubGameObject;
}
