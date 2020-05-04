using CielaSpike;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using System;

namespace HBS {

    
    public static class AssetManager {

        public static AssetManagerInstance instance;
        static readonly WaitForEndOfFrame waitFrame = new WaitForEndOfFrame();

        public static void CancelAsync(string id) {
            Scheduler.Remove(id);
        }

        public static void DeleteAsset(string path) {
            if (File.Exists(path)) { File.Delete(path); }
            path = Path.GetDirectoryName(path) + "/" + System.IO.Path.GetFileName(path) + ".hbm";
            if (File.Exists(path)) { File.Delete(path); }
            path = Path.GetDirectoryName(path) + "/" + System.IO.Path.GetFileName(path) + ".png";
            if (File.Exists(path)) { File.Delete(path); }
            path = Path.GetDirectoryName(path) + "/" + System.IO.Path.GetFileName(path) + ".hbp";
            if (File.Exists(path)) { File.Delete(path); }
            path = Path.GetDirectoryName(path) + "/" + System.IO.Path.GetFileName(path) + ".hba";
            if (File.Exists(path)) { File.Delete(path); }
        }
        public static void CreatMetaFile(string path, string assetType) {
            path = ConvertToHbmPath(path);
            XElement hbm = new XElement("HBMETA");
            hbm.Add(new XElement("Type", assetType));
            hbm.Save(path);
        }
        public static string ConvertToHbmPath(string path) {
            return Path.GetDirectoryName(path) + "/" + Path.GetFileNameWithoutExtension(path) + ".hbm";
        }

        static void SetAssetComponent(GameObject o, string path) {
            if (o != null) { if (o.GetComponent<Asset>() != null) { o.GetComponent<Asset>().path = path; } else { var a = o.AddComponent<Asset>(); a.path = path; }; }
        }
        static void ClearAssetComponent(GameObject o) {
            if (o != null) {
                var assets = o.GetComponentsInChildren<Asset>();
                foreach (var a in assets) {
                    GameObject.DestroyImmediate(a, false);
                }
            }
        }

        public static GameObject Instantiate(string path) {
            var o = HBS.Serializer.GameObjects.LoadGameObject(path);
            SetAssetComponent(o, path);
            return o;
        }

        public static void Save(string path, string assetType, GameObject o, bool makeHbm = true) {
            ClearAssetComponent(o);
            HBS.Serializer.GameObjects.SaveGameObject(path, o);
            if (makeHbm) {
                CreatMetaFile(path, assetType);
            }
        }



        
        public static class Scheduler {

            public static Dictionary<string, ScheduleBand> bands;
            public static ScheduleStats stats = new ScheduleStats();

            public static IEnumerator RunSchedule() {

                yield return Ninja.JumpToUnity;

                while (true) {
                    yield return waitFrame;
                    RunBands();
                    BuildStats();
                }
            }

            private static void RunBands() {
                if (bands == null || bands.Count == 0) { return; }
                try {
                    foreach (var band in bands) {
                        band.Value.RunItems();
                    }
                } catch (Exception e) {
                    Debug.LogError(e.ToString());
                }

            }
            private static void BuildStats() {
                if (bands == null || bands.Count == 0) { return; }

                if (stats == null) { stats = new ScheduleStats(); }

                stats.bands = bands.Keys.ToArray();
                stats.items = new ScheduleItem[0];
                stats.workingItems = new ScheduleItem[0];
                stats.waitingItems = new ScheduleItem[0];

                foreach (var band in bands) {
                    if (band.Value.items != null) {
                        foreach (var item in band.Value.items) {

                            if (item.Value.running && !item.Value.spent) {

                                Array.Resize(ref stats.workingItems, stats.workingItems.Length + 1);
                                stats.workingItems[stats.workingItems.Length - 1] = item.Value;
                            } else if (!item.Value.spent) {

                                Array.Resize(ref stats.waitingItems, stats.waitingItems.Length + 1);
                                stats.waitingItems[stats.waitingItems.Length - 1] = item.Value;
                            }

                            Array.Resize(ref stats.items, stats.items.Length + 1);
                            stats.items[stats.items.Length - 1] = item.Value;
                        }
                    }
                }
            }
            public static void SetBand(string band, int limit) {
                if (bands == null) { bands = new Dictionary<string, ScheduleBand>(); }

                if (bands.ContainsKey(band) == false) { bands.Add(band, new ScheduleBand()); }

                bands[band].maxRunningItems = limit;
            }
            public static string[] GetBandKeys() {
                if (bands == null) { return null; }
                return bands.Keys.ToArray();
            }

            public static string Insert(string band, Action<ScheduleItem> onRun) {

                if (bands == null) { bands = new Dictionary<string, ScheduleBand>(); }

                if (bands.ContainsKey(band) == false) { bands.Add(band, new ScheduleBand()); }

                if (bands[band].items == null) { bands[band].items = new Dictionary<string, ScheduleItem>(); }

                var id = Serializer.GetRandomID();
                var queItem = new ScheduleItem() { band = band, id = id, onRun = onRun };

                bands[band].items.Add(id, queItem);

                return id;

            }
            public static void Remove(string id) {
                if (bands == null) { return; }

                foreach (var band in bands) {
                    if (band.Value.items != null && band.Value.items.ContainsKey(id)) {
                        band.Value.items[id].Cancel();
                        band.Value.items.Remove(id);
                        return;
                    }
                }
            }

            
            public class ScheduleBand {
                public int maxRunningItems = 1;
                public int curRunningItems = 0;
                public Dictionary<string, ScheduleItem> items;
                public void RunItems() {
                    if (items == null || items.Count == 0) { return; }

                    var blacklist = new List<string>();
                    curRunningItems = 0;
                    foreach (var item in items) {
                        if (item.Value.running && !item.Value.spent) {
                            curRunningItems++;
                        } else if (item.Value.spent) {
                            blacklist.Add(item.Key);
                        }
                    }

                    foreach (var b in blacklist) {
                        items.Remove(b);
                    }

                    if (curRunningItems < maxRunningItems) {
                        foreach (var item in items) {
                            if (!item.Value.running && !item.Value.spent) {
                                item.Value.Run();
                                curRunningItems++;
                                if (curRunningItems >= maxRunningItems) { break; }
                            }
                        }
                    }
                }

            }

            
            public class ScheduleItem {
                public Task task;
                public Action<ScheduleItem> onRun;
                public GameObject gameObject;

                public bool running = false;
                public bool spent = false;
                public float progress = 0;

                public string band;
                public string id;
                public float mb;
                public int gameObjectCount;
                public string path;
                public string fileName;

                public void Run() { running = true; if (onRun != null) { onRun(this); } }

                public void Done() { spent = true; }

                public void Cancel() {
                    Debug.Log("ScheduleItem.Cancel " + fileName);
                    spent = true;
                    if (gameObject != null) { GameObject.Destroy(gameObject); }
                    if (task != null) { task.Cancel(); }
                }
            }

            
            public class ScheduleStats {
                public string[] bands;
                public ScheduleItem[] items;
                public ScheduleItem[] waitingItems;
                public ScheduleItem[] workingItems;
            }
        }

        
        public static class GameSpecifics {

            public static int regularSaveBandLimit = 2;
            public static int regularSaveAsyncGameObjectStructureSpeed = 15;
            public static int regularSaveAsyncComponentSpeed = 5;

            public static int regularBandLimit = 2;
            public static int regularAsyncGameObjectStructureSpeed = 15;
            public static int regularAsyncComponentSpeed = 5;
            public static int regularColliderSpeed = 1;
            
            
            //REGULAR SAVE

            public static string SaveAsync(string path, string assetType, GameObject o, bool makeHbm, Action<bool, string> onReturn, Action<float> onProgress = null) {
                Scheduler.SetBand("save asset", regularSaveBandLimit);
                return Scheduler.Insert("save asset", (item) => {
                    item.gameObject = o;
                    instance.StartCoroutineAsync(_SaveAsync(item, path, assetType, makeHbm, onReturn, onProgress), out item.task);
                });
            }
            static IEnumerator _SaveAsync(Scheduler.ScheduleItem item, string path, string assetType, bool makeHbm, Action<bool, string> onReturn, Action<float> onProgress) {
                
                ////////////////////////////////////////////////////
                yield return Ninja.JumpToUnity;
                ////////////////////////////////////////////////////
                
                //Debug.Log("_SaveAsync");

                item.path = path;
                item.fileName = Path.GetFileNameWithoutExtension(path);
                PostProgress(item, onProgress, 0);

                var o = item.gameObject;

                if (o == null) {
                    PostReturn(item, onReturn, false, "SaveAsync: want to save null");
                    yield break;
                }

                ClearAssetComponent(o);

                //make a clone
                o = GameObject.Instantiate(o);

                //disable clone
                o.SetActive(false);

                //provide game object to the schedule item for cleaning up when canceled
                item.gameObject = o;

                if (!Serializer.InitHooks()) {
                    PostReturn(item, onReturn, false, "SaveAsync: Serializer.InitHooks failed");
                    yield break;
                }

                ////////////////////////////////////////////////////
                yield return Ninja.JumpBack;
                ////////////////////////////////////////////////////

                string workPath;
                string dataPath;
                Writer w;
                if (!Serializer.GameObjects.StartSave(out w, out workPath, out dataPath)) {

                    ////////////////////////////////////////////////////
                    yield return Ninja.JumpToUnity;
                    ////////////////////////////////////////////////////

                    PostReturn(item, onReturn, false, "SaveAsync: Serializer.GameObjects.StartSave failed");
                    yield break;
                }

                ////////////////////////////////////////////////////
                yield return Ninja.JumpToUnity;
                ////////////////////////////////////////////////////

                PostProgress(item, onProgress, 0.05f);

                var asyncMeshes = new Dictionary<string, Mesh>();
                Serializer.OverrideSerializeType(typeof(Mesh), (writer, mesh) => { MeshExtension.SaveMeshAsync(writer, workPath,  mesh , ref asyncMeshes); });
                var asyncRevAudioClips = new Dictionary<string, RevAudioClip>();
                Serializer.OverrideSerializeType(typeof(RevExtension), (writer, revAudioClip) => { RevExtension.SaveRevAudioClipAsync(writer,workPath, revAudioClip,  ref asyncRevAudioClips); });

                List<GameObject> children;
                Serializer.GameObjects.WriteGameObjectHead(w, o, out children);

                item.gameObjectCount = children.Count;

                var i = 0;

                for ( i = 0; i < children.Count; i++) {
                    Serializer.GameObjects.WriteGameObjectStructureChunk(w, o, children, i, 1);
                    if (Wait(regularSaveAsyncGameObjectStructureSpeed, i)) {
                        yield return waitFrame;
                        PostProgress(item, onProgress, 0.05f, 0.5f, i, children.Count);
                    }
                }

                for ( i = 0; i < children.Count; i++) {
                    Serializer.GameObjects.WriteComponentDataChunk(w, o, children, i, 1);
                    if (Wait(regularSaveAsyncComponentSpeed, i)) {
                        yield return waitFrame;
                        PostProgress(item, onProgress, 0.5f, 0.85f, i, children.Count);
                    }
                }

                //save meshes 
                i = 0;
                foreach (var v in asyncMeshes) {

                    yield return instance.StartCoroutineAsync(MeshUtilities.SaveH3dAsyncToFile(v.Key, v.Value));

                    PostProgress(item, onProgress, 0.85f, 0.9f, i, asyncMeshes.Count);
                    i++;
                }

                //load rev audio clips
                i = 0;
                foreach (var v in asyncRevAudioClips) {

                    yield return instance.StartCoroutineAsync(RevAudioClipUtilities.SaveHraAsyncToFile(v.Key, v.Value));

                    PostProgress(item, onProgress, 0.9f, 0.95f, i, asyncRevAudioClips.Count);
                    i++;
                }

                ////////////////////////////////////////////////////
                yield return Ninja.JumpBack;
                ////////////////////////////////////////////////////

                Serializer.GameObjects.StopSave(w, workPath, dataPath, path);

                if (makeHbm) {
                    CreatMetaFile(path, assetType);
                }

                ////////////////////////////////////////////////////
                yield return Ninja.JumpToUnity;
                ////////////////////////////////////////////////////

                GameObject.DestroyImmediate(o, false);

                PostProgress(item, onProgress, 1f);
                PostReturn(item, onReturn, true, "");
            }

            //REGULAR INSTANTIATE

            public static string InstantiateAsync(string path, Action<GameObject, string> onReturn, Action<float> onProgress = null) {
                Scheduler.SetBand("load asset", regularBandLimit);
                return Scheduler.Insert("load asset", (item) => {
                    instance.StartCoroutineAsync(_InstantiateAsync(item, path, onReturn, onProgress), out item.task);
                });
            }
            static IEnumerator _InstantiateAsync(Scheduler.ScheduleItem item, string path, Action<GameObject, string> onReturn, Action<float> onProgress) {

                ////////////////////////////////////////////////////
                yield return Ninja.JumpToUnity;
                ////////////////////////////////////////////////////

                //Debug.Log("_InstantiateAsync");

                item.path = path;
                item.fileName = Path.GetFileNameWithoutExtension(path);
                PostProgress(item, onProgress, 0);

                if (!Serializer.InitHooks()) {
                    PostReturn(item, onReturn, null, "InstantiateAsync: Serializer.InitHooks failed");
                    yield break;
                }

                ////////////////////////////////////////////////////
                yield return Ninja.JumpBack;
                ////////////////////////////////////////////////////

                string workPath;
                string dataPath;
                Reader r;
                float mb;
                if (!Serializer.GameObjects.StartLoad(path, out r, out workPath, out dataPath, out mb)) {

                    ////////////////////////////////////////////////////
                    yield return Ninja.JumpToUnity;
                    ////////////////////////////////////////////////////

                    PostReturn(item, onReturn, null, "InstantiateAsync Serializer.GameObjects.StartLoad failed");
                    yield break;
                }

                ////////////////////////////////////////////////////
                yield return Ninja.JumpToUnity;
                ////////////////////////////////////////////////////

                item.mb = mb;

                PostProgress(item, onProgress, 0.05f);

                //setup mesh extension async func
                var asyncMeshes = new Dictionary<string, Mesh>();
                Func<Reader, Type, object, object> asyncFuncMesh = (reader, type, mesh) => {
                    return MeshExtension.LoadMeshAsync(reader, workPath, ref asyncMeshes);
                };
                var asyncRevAudioClips = new Dictionary<string, RevAudioClip>();
                Func<Reader, Type, object, object> asyncFuncRev = (reader, type, mesh) => {
                    return RevExtension.LoadRevAudioClipAsync(reader, workPath, ref asyncRevAudioClips);
                };

                //read game object head
                int prefix;
                int gameObjectCount;
                GameObject[] objs;
                Serializer.GameObjects.ReadGameObjectHead(r, out prefix, out gameObjectCount, out objs);

                GameObject o = null;


                item.gameObjectCount = gameObjectCount;

                var i = 0;

                //read game object structure
                for (i = 0; i < gameObjectCount; i++) {
                    Serializer.GameObjects.ReadGameObjectStructureChunk(prefix, r, o, out o, objs, i, 1);
                    ////provide game object to the schedule item for cleaning up when canceled
                    item.gameObject = o;
                    if (Wait(regularAsyncGameObjectStructureSpeed, i)) {
                        yield return waitFrame;
                        PostProgress(item, onProgress, 0.05f, 0.1f, i, gameObjectCount);
                    }
                }

                //read game object components
                for (i = 0; i < gameObjectCount; i++) {
                    int componentCount;
                    Component[] comps;
                    Serializer.GameObjects.ReadComponentStructureChunk(prefix, r, o, objs, i, 1, out componentCount, out comps);

                    for (var ii = 0; ii < componentCount; ii++) {

                        //set serializer type overrides
                        Serializer.OverrideUnserializeType(typeof(Mesh), asyncFuncMesh);
                        Serializer.OverrideUnserializeType(typeof(RevAudioClip), asyncFuncRev);

                        //read some components
                        Serializer.GameObjects.ReadComponentChunk(prefix, r, o, ii, 1, componentCount, comps);
                        if (Wait(regularAsyncComponentSpeed, i)) {
                            yield return waitFrame;
                        }
                    }

                    PostProgress(item, onProgress, 0.1f, 0.4f, i, gameObjectCount);
                }

                //load meshes 
                i = 0;
                foreach (var v in asyncMeshes) {

                    yield return instance.StartCoroutineAsync(MeshUtilities.LoadH3dOntoMeshAsync(v.Key, v.Value));

                    PostProgress(item, onProgress, 0.4f, 0.6f, i, asyncMeshes.Count);
                    i++;
                }

                //load rev audio clips
                i = 0;
                foreach (var v in asyncRevAudioClips) {

                    yield return instance.StartCoroutineAsync(RevAudioClipUtilities.LoadHraOntoRevAudioClipAsync(v.Key, v.Value));

                    PostProgress(item, onProgress, 0.6f, 0.7f, i, asyncRevAudioClips.Count);
                    i++;
                }

                ////////////////////////////////////////////////////
                yield return Ninja.JumpBack;
                ////////////////////////////////////////////////////

                Serializer.GameObjects.StopLoad(r, workPath);

                ////////////////////////////////////////////////////
                yield return Ninja.JumpToUnity;
                ////////////////////////////////////////////////////

                if (o != null) {

                    //disable colliders and renderers before the gameobject goes active

                    var enabledColliders = DisableMeshColliders(o);
                    //var enabledRenderers = DisableRenderers(o);

                    //activate ( lag spike expected )

                    o.SetActive(true);

                    //enable renderers and colliders smoothly

                    i = 0;
                    foreach (var v in enabledColliders) {
                        v.enabled = true;
                        if (Wait(regularColliderSpeed, i)) {
                            yield return waitFrame;
                            yield return waitFrame;
                            yield return waitFrame;
                            yield return waitFrame;
                            PostProgress(item, onProgress, 0.7f, 0.95f, i, enabledColliders.Count);
                        }
                        i++;
                    }

                }

                //attach asset component

                SetAssetComponent(o, path);

                //return 

                PostProgress(item, onProgress, 1);
                PostReturn(item, onReturn, o, "");

            }

            

            //UTILS
            static void PostReturn(Scheduler.ScheduleItem item, Action<bool, string> onReturn, bool o, string s) {
                if (item != null) {
                    item.Done();
                }
                if (onReturn != null) {
                    onReturn(o, s);
                }
            }
            static void PostReturn(Scheduler.ScheduleItem item, Action<GameObject, string> onReturn, GameObject o, string s) {
                if (item != null) {
                    item.Done();
                }
                if (onReturn != null) {
                    onReturn(o, s);
                }
            }
            static void PostProgress(Scheduler.ScheduleItem item, System.Action<float> onProgress, float from, float to, int index, int max) {
                var f = Mathf.Lerp(from, to, (float)index / (float)(max - 1));
                PostProgress(item, onProgress, f);
            }
            static void PostProgress(Scheduler.ScheduleItem item, System.Action<float> onProgress, float f) {
                if (item != null) {
                    item.progress = f;
                }
                if (onProgress != null) {
                    onProgress(f);
                }
            }
            static bool Wait(float speed, int cc) {
                cc++;
                return cc % Mathf.Max(1, speed) == 0;
            }
            static List<Collider> DisableMeshColliders(GameObject o) {
                var ret = new List<Collider>();
                if (o == null) { return ret; }
                var allColliders = o.GetComponentsInChildren<Collider>(true);
                foreach (var v in allColliders) {
                    if (v.enabled) {
                        v.enabled = false;
                        ret.Add(v);
                    }
                }
                return ret;
            }
            public static Bounds CalculateLocalBounds(Transform transform) {

                var bounds = new Bounds();
                foreach (var r in transform.GetComponentsInChildren<MeshFilter>()) {
                    if (r.transform.parent == transform || r.transform == transform) {
                        if (r.sharedMesh != null) {
                            r.sharedMesh.RecalculateBounds();
                            bounds.Encapsulate(r.sharedMesh.bounds);
                        }
                    }
                }

                return bounds;

                /*var currentRotation = transform.rotation;

                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                var bounds = new Bounds(transform.position, Vector3.zero);

                var renderers = transform.GetComponentsInChildren<MeshRenderer>();
                foreach (var r in renderers) {
                    var mf = r.GetComponent<MeshFilter>();
                    if (mf != null ) {
                        if( mf.sharedMesh == null ) { continue; }
                        mf.sharedMesh.RecalculateBounds();
                        
                    }
                    if ( r.bounds.size.sqrMagnitude > 0 ) {
                        bounds.Encapsulate(r.bounds);
                    }
                }

                var localCenter = bounds.center - transform.position;
                bounds.center = localCenter;

                transform.rotation = currentRotation;

                return bounds;*/
                
                //previous bounds calc , uncomment if new method prooves wrong
                //return HBBuilder.BuilderUtils.GetGameObjectBounds(transform.gameObject);
            }
          
        }
    }

}
