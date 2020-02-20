using HBWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerializerTest : MonoBehaviour {

    public string p = "";

    public Image image;

    public GameObject asset;

    public void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            AssetManager.InstantiateAssetAsyncSmooth(p, (o, err) => {
                Debug.Log(err);
                if (o != null) {

                    asset = o;
                    o.transform.position = Vector3.zero;
                    o.transform.rotation = Quaternion.identity;
                }
            }, (progress) => {
                image.fillAmount = progress;
            });
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            AssetManager.InstantiateAssetAsync(p, (o, err) => {
                Debug.Log(err);
                if (o != null) {

                    asset = o;
                    o.transform.position = Vector3.zero;
                    o.transform.rotation = Quaternion.identity;
                }
            }, (progress) => {
                image.fillAmount = progress;
            });
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            AssetManager.SaveAssetAsyncSmooth(p, "GameObject", asset, true, (o, err) => {
                Debug.Log(err);
            }, (progress) => {
                image.fillAmount = progress;
            });
        }
    }

    [ContextMenu("Import")]
    public void ImportGameObject() {
        var path = UnityEditor.EditorUtility.OpenFilePanel("open part", Application.streamingAssetsPath + "/Assets/GameObjects/", "hbp");
        if (path == "") { return; }
        p = path;
        AssetManager.InstantiateAssetAsyncSmooth(path,(o,err) => {
            Debug.Log(err);
            if( o != null ) {
                asset = o;
                o.transform.position = Vector3.zero;
                o.transform.rotation = Quaternion.identity;
            }
        },(progress)=> {
            image.fillAmount = progress;
        });
        
    }

    [ContextMenu("export")]
    public void SaveGameObject() {
        var path = UnityEditor.EditorUtility.SaveFilePanel("save part", Application.streamingAssetsPath + "/Assets/GameObjects/","untitled", "hbp");
        if (path == "") { return; }
        AssetManager.SaveAssetAsyncSmooth(path, "GameObject", asset, true, (o, err) => {
            Debug.Log(err);
        }, (progress) => {
            image.fillAmount = progress;
        });
    }   
}
