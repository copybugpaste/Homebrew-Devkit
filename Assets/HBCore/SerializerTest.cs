using HBWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializerTest : MonoBehaviour {

    public string p = "";

    public void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            AssetManager.InstantiateAssetAsync(p, (o, err) => {
                Debug.Log(err);
                if (o != null) {
                    o.transform.position = Vector3.zero;
                    o.transform.rotation = Quaternion.identity;
                }
            });
        }
    }

    [ContextMenu("Import")]
    public void ImportGameObject() {
        var path = UnityEditor.EditorUtility.OpenFilePanel("open part", Application.streamingAssetsPath + "/Assets/GameObjects/", "hbp");
        if (path == "") { return; }
        p = path;
        AssetManager.InstantiateAssetAsync(path,(o,err) => {
            Debug.Log(err);
            if( o != null ) {
                o.transform.position = Vector3.zero;
                o.transform.rotation = Quaternion.identity;
            }
        });
        
    }
    
    
}
