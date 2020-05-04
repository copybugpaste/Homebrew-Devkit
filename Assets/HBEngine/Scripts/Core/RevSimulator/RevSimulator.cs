/* Copyright (C) CopyBugPaste - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevSimulator : MonoBehaviour {

    [Header("Controls")]
    [Range(0,1)]
    public float throttle = 0f;
    public int gear = 0;

    [Header("Stats")]
    public AnimationCurve torqueCurve;
    public float maxTorque = 250f;
    public float redlineRPM = 7000f;
    public float idleRPM = 1000f;
    public float throttleCutoffRPM = 10f;
    public float throttleCutoffSeconds = 0.01f;
    public float smoothInternalAudioThrottleSpeedFactor = 0.15f;
    public float smoothIneralRPMSpeedFactor = 0.25f;

    [Header("Inertia")]
    public float internalInertia = 1f;
    public float loadInertia = 10f;

    [Header("Friction")]
    public float counterTorque = 0.03f;

    [Header("Gears")]
    public float shiftUpRPM = 6000f;
    public float shiftDownRPM = 3000f;
    public float overallGearRatio = 0.291f;
    public float[] gearRatios = new float[] { 0.256f, 0.431f, 0.621f, 0.781f, 1f, 1.136f };

    //[Header("Internals")]
    private float internalThrottle = 0f;
    private float internalAudioThrottle = 0f;
    private float smoothInternalAudioThrottle = 0f;
    private float internalTorque = 0f;
    private float internalRPM = 0f;
    private float smoothInternalRPM = 0f;
    private float gearRatio = 1f;

    //[Header("Externals")]
    private float outTorque = 0f;
    private float outCounterTorque = 0f;
    private float outRPMAcceleration = 0f;
    private float outRPMDeceleration = 0f;
    private float outRPM = 0f;
    private float outRedlineRPM = 0f;
    private float outIdleRPM = 0f;
    private float outInertia = 1f;

    [Header("Audio")]
    public EngineAudioClip engineAudioClip;

    private float dt = 0f;
    private float throttleCutoffTime = 0f;
    
    void Update() {
        dt = Time.smoothDeltaTime;

        internalThrottle = Mathf.Clamp01(throttle);
        internalAudioThrottle = Mathf.Clamp01(throttle);

        if ( internalRPM > redlineRPM - throttleCutoffRPM ) {
            internalThrottle = 0f;
            throttleCutoffTime = Time.time + throttleCutoffSeconds;
        }
        if( Time.time < throttleCutoffTime ) {
            internalThrottle = 0f;
        }
        
        if( internalRPM < idleRPM ) { internalThrottle = 1f; }
        if( internalRPM <= idleRPM ) { internalAudioThrottle = 1f; }

        if (smoothInternalRPM > shiftUpRPM && gear < gearRatios.Length - 1) { gear++; ShiftGear(); }
        if (smoothInternalRPM < shiftDownRPM && internalThrottle <= 0f && gear > 0) { gear--; ShiftGear(); }
        
        internalTorque = torqueCurve.Evaluate(internalRPM/redlineRPM) * maxTorque * internalThrottle;
        
        if (gear > gearRatios.Length - 1) { gear = gearRatios.Length - 1; }
        if (gear < 0) { gear = 0; }
        gearRatio = overallGearRatio * gearRatios[gear];

        outTorque = internalTorque / gearRatio;
        outCounterTorque = counterTorque / gearRatio;
        outRedlineRPM = redlineRPM * gearRatio;
        outIdleRPM = idleRPM * gearRatio;
        outInertia = (internalInertia / gearRatio) + loadInertia;

        outRPMAcceleration = RadSecToRPM((outTorque / outInertia) * dt);
        outRPMDeceleration = RadSecToRPM((outCounterTorque / outInertia) * dt) * (1f - Mathf.Sqrt(internalThrottle));

        outRPM += (outRPMAcceleration-outRPMDeceleration) * dt;
       
        if (outRPM > outRedlineRPM) { outRPM = outRedlineRPM; }
        if (outRPM < outIdleRPM) { outRPM = outIdleRPM; }
        
        internalRPM = outRPM / gearRatio;
        
        smoothInternalAudioThrottle = Mathf.Lerp(smoothInternalAudioThrottle, internalAudioThrottle, smoothInternalAudioThrottleSpeedFactor);
        smoothInternalRPM = Mathf.Lerp(smoothInternalRPM, internalRPM, smoothIneralRPMSpeedFactor);
        
        if (engineAudioClip != null) {
            engineAudioClip.shift = Mathf.InverseLerp(idleRPM, redlineRPM, smoothInternalRPM);
            engineAudioClip.accel = smoothInternalAudioThrottle;
            engineAudioClip.throttle = throttle;
        }
    }

    float RadSecToRPM(float r) {
        return r * 9.5492965964254f;
    }

    void ShiftGear() {
        if (engineAudioClip != null) {
            engineAudioClip.ShiftGear();
        }
    }
    public bool drawGizmos = false;

#if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        if (!drawGizmos) { return; }
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.white;
        var right = Vector3.right;
        var inc = 5f;
        var a = 0f;
        var radius = 1f;
        var prePoint = Quaternion.Euler(0, 0, a) * right * radius;
        while ( a < 360 ) {
            a += inc;
            var point = Quaternion.Euler(0, 0, a) * right * radius;
            Gizmos.DrawLine(prePoint, point);
            prePoint = point;
        }

        radius = 1.05f;
        var needlePoint = Quaternion.Euler(0, 0, -45f + (Mathf.InverseLerp(idleRPM, redlineRPM, smoothInternalRPM) * 270f)) * right * radius;
        Gizmos.DrawLine(Vector3.zero, needlePoint);

        radius = 1.2f;
        UnityEditor.Handles.Label(transform.position + transform.up * radius * 0.5f, smoothInternalRPM.ToString() + " RPM");
        UnityEditor.Handles.Label(transform.position + (Quaternion.Euler(0, 0, 225f) * right * radius), redlineRPM.ToString() + " RPM");
        UnityEditor.Handles.Label(transform.position + (Quaternion.Euler(0, 0, -45f) * right * radius), idleRPM.ToString() + " RPM");

        Gizmos.color = Color.red;
        inc = 5f;
        a = -45+ (shiftUpRPM / redlineRPM*270f);
        radius = 0.9f;
        prePoint = Quaternion.Euler(0, 0, a) * right * radius;
        while (a < 225f) {
            a += inc;
            if( a > 225f ) { a = 225f; }
            var point = Quaternion.Euler(0, 0, a) * right * radius;
            Gizmos.DrawLine(prePoint, point);
            prePoint = point;
        }
    }
#endif
}
