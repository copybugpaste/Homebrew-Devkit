using System.Collections;
using UnityEngine;

namespace HBS {

    public class SerializerInstance : MonoBehaviour {

        void Awake() {
            Serializer.instance = this;
            Serializer.persistentDataPath = Application.persistentDataPath;
        }

        void OnDestroy() {
            Serializer.instance = null;
        }

        void OnApplicationQuit() {
            Serializer.OnApplicationQuit();
        }

    }
}
