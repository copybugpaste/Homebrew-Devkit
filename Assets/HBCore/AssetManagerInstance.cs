using System.Collections;
using UnityEngine;
using CielaSpike;

namespace HBS { 
    public class AssetManagerInstance : MonoBehaviour {

        private Task schedulerRunTask;

        void Awake() {
            AssetManager.instance = this;
            this.StartCoroutineAsync(AssetManager.Scheduler.RunSchedule(), out schedulerRunTask);
        }

        void OnDestroy() {
            AssetManager.instance = null;
        }
        
        private void Update() {
            if (schedulerRunTask != null) {
                if (schedulerRunTask.Exception != null) {
                    Debug.LogErrorFormat("[AssetManagerInstance] ERROR: {0}", schedulerRunTask.Exception);
                    this.StartCoroutineAsync(AssetManager.Scheduler.RunSchedule(), out schedulerRunTask);
                }
            }
        }
        
    }
}