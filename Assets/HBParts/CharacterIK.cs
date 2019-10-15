using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIK : MonoBehaviour {

    private float smoothSwing = 0f;
    private float smoothReach = 0f;
    private Vector3 preVelocity;
    private FullBodyBipedIK ik;
    private LookAtIK laik;
    private HBSeat seat;

    [ContextMenu("Bind To Seat")]
    public void Setup() {
        seat = GetComponentInParent<HBSeat>();
        ik = GetComponentInChildren<FullBodyBipedIK>();
        laik = GetComponentInChildren<LookAtIK>();
        if ( seat != null && ik != null) {
            
            if( seat.bodyGoal != null ) {
                ik.solver.bodyEffector.target = seat.bodyGoal.transform;
            }

            if (seat.leftHandGoal != null) {
                ik.solver.leftHandEffector.target = seat.leftHandGoal.transform;
            }

            if( seat.leftHandBendGoal != null ) {
                ik.solver.leftArmChain.bendConstraint.bendGoal = seat.leftHandBendGoal.transform;
            }

            if (seat.rightHandGoal != null) {
                ik.solver.rightHandEffector.target = seat.rightHandGoal.transform;
            }

            if (seat.rightHandBendGoal != null) {
                ik.solver.rightArmChain.bendConstraint.bendGoal = seat.rightHandBendGoal.transform;
            }

            if (seat.leftFootGoal != null) {
                ik.solver.leftFootEffector.target = seat.leftFootGoal.transform;
            }

            if (seat.leftFootBendGoal != null) {
                ik.solver.leftLegChain.bendConstraint.bendGoal = seat.leftFootBendGoal.transform;
            }

            if (seat.rightFootGoal != null) {
                ik.solver.rightFootEffector.target = seat.rightFootGoal.transform;
            }

            if (seat.rightFootBendGoal != null) {
                ik.solver.rightLegChain.bendConstraint.bendGoal = seat.rightFootBendGoal.transform;
            }
            if (seat.lookAtGoal != null && laik != null) {
                laik.solver.target = seat.lookAtGoal.transform;
            }
            HBSteerWheelHub steeringWheel = null;
            if ( seat.steeringWheelHubGameObject == null ) {
                float distance = 1f;
                foreach (HBSteerWheelHub hub in seat.transform.parent.GetComponentsInChildren<HBSteerWheelHub>()) {
                    float d = Vector3.Distance(seat.transform.position, hub.transform.position);
                    if (d < distance) {
                        steeringWheel = hub;
                        distance = d;
                    }
                }
            } else {
                steeringWheel = seat.steeringWheelHubGameObject.GetComponent<HBSteerWheelHub>();
            }
           
            
            if (steeringWheel != null) {
                if (steeringWheel.leftHandGoal != null) {
                    ik.solver.leftHandEffector.target = steeringWheel.leftHandGoal.transform;
                }

                if (steeringWheel.rightHandGoal != null) {
                    ik.solver.rightHandEffector.target = steeringWheel.rightHandGoal.transform;
                }
            }
            
        }
    }
    
}
