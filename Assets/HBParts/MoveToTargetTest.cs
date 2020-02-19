using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetTest : MonoBehaviour {

    public MoveToTarget moveToTarget;

    [Header("slow update")]
    public float slowuUpdateDelay = 5f;
    
    private float slowTimer = 0f;
    
    void Update () {
        slowTimer += Time.deltaTime;
        if( slowTimer > slowuUpdateDelay) {
            slowTimer = 0f;
            SlowUpdate();
        }
    }

    void SlowUpdate() {
        moveToTarget.SetTarget(Random.insideUnitSphere * 10f,Quaternion.LookRotation(Random.insideUnitSphere), slowuUpdateDelay);
    }
}
