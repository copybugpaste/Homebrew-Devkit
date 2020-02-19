using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour {

    public Vector3 position;
    public Quaternion rotation;
    public float arrivalTime;

    public Vector3 fromPosition;
    public Quaternion fromRotation;
    public float factor = 0f;

    public void SetTarget( Vector3 pos , Quaternion rot, float arrivalTime) {
        position = pos;
        rotation = rot;
        this.arrivalTime = arrivalTime;

        fromPosition = transform.position;
        fromRotation = transform.rotation;
        factor = 0f;
    }

    void Update () {
        factor += Time.deltaTime / arrivalTime;
        transform.position = Vector3.Lerp(fromPosition, position, factor);
        transform.rotation = Quaternion.Slerp(fromRotation, rotation, factor);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, position);
        Gizmos.DrawSphere(position, 0.05f);
    }
}
