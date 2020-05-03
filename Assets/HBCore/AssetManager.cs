using CielaSpike;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using System;
//using SLua;

namespace HBS {

    //[SLua.CustomLuaClass]
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
            //if (o != null) { o.GetOrAddComponent<Asset>().path = path; }
        }
        static void ClearAssetComponent(GameObject o) {
            /*if (o != null) {
                var assets = o.GetComponentsInChildren<Asset>();
                foreach (var a in assets) {
                    GameObject.DestroyImmediate(a, false);
                }
            }*/
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


            public static int worldBandLimit = 4;
            public static int worldAsyncGameObjectStructureSpeed = 5;
            public static int worldAsyncComponentSpeed = 3;
            public static int worldColliderSpeed = 1;


            public static int vehicleBandLimit = 2;
            public static int vehicleAsyncGameObjectStructureSpeed = 5;
            public static int vehicleAsyncComponentSpeed = 3;
            public static int vehicleColliderSpeed = 20;
            public static int vehicleApplyReferencesSpeed = 1;
            
            //REGULAR SAVE

            public static void Save(string path, string assetType, GameObject o, bool makeHbm = true) {
                ClearAssetComponent(o);
                HBS.Serializer.GameObjects.SaveGameObject(path, o);
                if (makeHbm) {
                    CreatMetaFile(path, assetType);
                }
            }
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

            public static GameObject Instantiate(string path) {
                var o = HBS.Serializer.GameObjects.LoadGameObject(path);
                SetAssetComponent(o, path);
                return o;
            }
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

            //WORLD INSTANTIATE
            /*
            public static string InstantiateWorldAsync(string path, Transform parent, Action<GameObject, string> onReturn, Action<float> onProgress = null) {
                Scheduler.SetBand("load world asset", worldBandLimit);
                return Scheduler.Insert("load world asset", (item) => {
                    instance.StartCoroutineAsync(_InstantiateWorldAsync(item, path, parent, onReturn, onProgress), out item.task);
                });
            }
            static IEnumerator _InstantiateWorldAsync(Scheduler.ScheduleItem item, string path, Transform parent, Action<GameObject, string> onReturn, Action<float> onProgress) {


                ////////////////////////////////////////////////////
                yield return Ninja.JumpToUnity;
                ////////////////////////////////////////////////////

                //Debug.Log("_InstantiateWorldAsync");

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

                    if (Wait(worldAsyncGameObjectStructureSpeed, i)) {
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
                        if (Wait(worldAsyncComponentSpeed, i)) {
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

                    //parent it ( will trigger mesh collider rebuild )

                    if (parent != null) {
                        o.transform.localScale = Vector3.one;
                        o.transform.SetParent(parent);
                        o.transform.localPosition = Vector3.zero;
                        o.transform.localEulerAngles = Vector3.zero;
                    }

                    //activate ( will trigger mesh collider rebuild )

                    o.SetActive(true);

                    //enable renderers and colliders smoothly

                    i = 0;
                    foreach (var v in enabledColliders) {
                        v.enabled = true;
                        if (Wait(worldColliderSpeed, i)) {
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
            */
            //VEHICLE INSTANTIATE
            /*
            public static GameObject InstantiateVehicle(string path,Vector3 position , Quaternion rotation, bool isMyVehicle, out string maySpawnError) {

                maySpawnError = "";

                var o = HBS.Serializer.GameObjects.LoadGameObject(path);

                if (o != null) {


                    //get vehicle root and enable it

                    var vr = VehicleGetOrAddVehicleRoot(o);

                    //check if we may spawn vehicle 

                    if (!VehicleCheckMaySpawn(o, vr , out maySpawnError)) { return null; }
                    
                    //setup collider ignore 

                    VehicleSetColliderIgnore(o);

                    //position vehicle

                    VehicleSetPosition(o, position, rotation);

                    //assign my conn id
                    VehicleAssignInitialConnIDForMyVehicle(o);

                    //apply property references smoothly
                    VehicleApplyPropertyReferences(o);
                    
                    //read from properties

                    VehicleReadFromProperties(o);

                    //apply collider physics material

                    VehicleApplyColliderPhysicsMaterial(o);

                    //assign shadow casting for vehicle

                    VehicleApplyRendererShadowCastingMode(o);

                    //set network position to update

                    VehicleApplyNetworkPositionUpdateMode(o);

                    //calc cog calculators

                    VehicleInitializeCogCalculators(o);

                    //init damage grids

                    VehicleInitializeDamageGrids(o);
                    
                    //set is my vehicle
                    VehicleSetIsMyVehicle(vr, isMyVehicle);

                    //init vehicle root 

                    VehicleInitializeVehicleRoot(vr);

                    //set hba transfer create file path

                    VehicleSetHBATransferCreateFilePath(o, vr, path);

                    //drop vehicle

                    //VehicleDropVehicle(o);

                } else {
                    maySpawnError = "Vehicle failed to spawn";
                }

                SetAssetComponent(o, path);
                return o;
            }
            public static string InstantiateVehicleAsync(string path, Vector3 position, Quaternion rotation, bool isMyVehicle, Action<GameObject, string> onReturn, Action<float> onProgress = null) {
                Scheduler.SetBand("load vehicle asset", vehicleBandLimit);
                return Scheduler.Insert("load vehicle asset", (item) => {
                    instance.StartCoroutineAsync(_InstantiateVehicleAsync(item, path, position, rotation, isMyVehicle, onReturn, onProgress), out item.task);
                });
            }
            static IEnumerator _InstantiateVehicleAsync(Scheduler.ScheduleItem item, string path, Vector3 position, Quaternion rotation, bool isMyVehicle, Action<GameObject, string> onReturn, Action<float> onProgress) {

                ////////////////////////////////////////////////////
                yield return Ninja.JumpToUnity;
                ////////////////////////////////////////////////////

                //Debug.Log("_InstantiateVehicleAsync");

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
                    if (Wait(vehicleAsyncGameObjectStructureSpeed, i)) {
                        yield return waitFrame;
                        PostProgress(item, onProgress, 0.05f, 0.2f, i, gameObjectCount);
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
                        if (Wait(vehicleAsyncComponentSpeed, i)) {
                            yield return waitFrame;
                        }
                    }

                    PostProgress(item, onProgress, 0.2f, 0.45f, i, gameObjectCount);
                }

                //load meshes 
                i = 0;
                foreach (var v in asyncMeshes) {

                    yield return instance.StartCoroutineAsync(MeshUtilities.LoadH3dOntoMeshAsync(v.Key, v.Value));

                    PostProgress(item, onProgress, 0.45f, 0.50f, i, asyncMeshes.Count);
                    i++;
                }

                //load rev audio clips
                i = 0;
                foreach (var v in asyncRevAudioClips) {

                    yield return instance.StartCoroutineAsync(RevAudioClipUtilities.LoadHraOntoRevAudioClipAsync(v.Key, v.Value));

                    PostProgress(item, onProgress, 0.50f, 0.55f, i, asyncRevAudioClips.Count);
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


                    //get vehicle root and enable it

                    var vr = VehicleGetOrAddVehicleRoot(o);

                    //check if we may spawn vehicle 

                    if (!VehicleCheckMaySpawnForAsync(item, o, vr, onReturn)) { yield break; }

                    PostProgress(item, onProgress, 0.70f);

                    yield return waitFrame;
                    
                    //activate colliders smoothly

                    var enabledColliders = DisableMeshColliders(o);

                    o.SetActive(true);

                    i = 0;
                    foreach (var v in enabledColliders) {
                        v.enabled = true;
                        if (Wait(vehicleColliderSpeed, i)) {
                            yield return waitFrame;
                            PostProgress(item, onProgress, 0.55f, 0.6f, i, enabledColliders.Count);
                        }
                        i++;
                    }

                    //setup collider ignore 

                    VehicleSetColliderIgnore(o);

                    yield return waitFrame;


                    yield return waitFrame;

                    //position vehicle

                    VehicleSetPosition(o, position, rotation);

                    //assign my conn id
                    VehicleAssignInitialConnIDForMyVehicle(o);

                    PostProgress(item, onProgress, 0.75f);

                    yield return waitFrame;

                    //apply property references smoothly

                    var parts = o.GetComponentsInChildren<Part>(true);

                    i = 0;
                    foreach (var part in parts) {
                        ApplyReferencesChunk(parts, i, 1);
                        if (Wait(vehicleApplyReferencesSpeed, i)) {
                            yield return waitFrame;
                            PostProgress(item, onProgress, 0.75f, 0.8f, i, parts.Length);
                        }
                        i++;
                    }

                    yield return waitFrame;

                    //read from properties

                    VehicleReadFromProperties(o);
                    
                    PostProgress(item, onProgress, 0.85f);

                    yield return waitFrame;

                    //apply collider physics material

                    VehicleApplyColliderPhysicsMaterial(o);

                    //assign shadow casting for vehicle

                    VehicleApplyRendererShadowCastingMode(o);

                    //set network position to update

                    VehicleApplyNetworkPositionUpdateMode(o);
                    
                    PostProgress(item, onProgress, 0.9f);

                    yield return waitFrame;

                    //calc cog calculators

                    VehicleInitializeCogCalculators(o);
                    
                    PostProgress(item, onProgress, 0.95f);

                    yield return waitFrame;

                    //init damage grids

                    VehicleInitializeDamageGrids(o);

                    yield return waitFrame;

                    //set is my vehicle
                    VehicleSetIsMyVehicle(vr, isMyVehicle);

                    //init vehicle root 

                    VehicleInitializeVehicleRoot(vr);
                    
                    //set hba transfer create file path

                    VehicleSetHBATransferCreateFilePath(o,vr, path); 
                    
                    //drop vehicle

                    //VehicleDropVehicle(o);
                    
                }

                //attach asset component

                SetAssetComponent(o, path);

                //return 

                PostProgress(item, onProgress, 1);
                PostReturn(item, onReturn, o, "");
            }
            */
            //VEHICLE UTILS

            static void ApplyReferencesChunk(Part[] parts, int fromIndex, int length) {
                for (var i = fromIndex; i < fromIndex + length; i++) {
                    var part = parts[i];
                    if (part == null) { continue; }
                    foreach (var property in part.properties) {
                        //OUTPUT TO INPUT
                        if (property.outputToInputPropertyRefrences.Count > 0) {
                            property.outputToInputProperties.Clear();
                            foreach (var p in property.outputToInputPropertyRefrences) {
                                foreach (var pt in parts) {

                                    if (pt == null) { continue; }
                                    if (pt.GetComponent<RefrenceID>() == null) { continue; }
                                    foreach (var prop in pt.properties) {
                                        if (p == pt.GetComponent<RefrenceID>().ID + "/" + prop.pname) {
                                            property.outputToInputProperties.Add(new Property.PropertyRefrence(pt.gameObject.GetComponent<Part>(), prop.pname));
                                        }
                                    }
                                }
                            }
                            property.outputToInputPropertyRefrences.Clear();
                        }


                        //INPUT TO OUTPUT
                        if (property.inputToOutputPropertyRefrences.Count > 0) {
                            property.inputToOutputProperties.Clear();
                            foreach (var p in property.inputToOutputPropertyRefrences) {
                                foreach (var pt in parts) {

                                    if (pt == null) { continue; }
                                    if (pt.GetComponent<RefrenceID>() == null) { continue; }
                                    foreach (var prop in pt.properties) {
                                        if (p == pt.GetComponent<RefrenceID>().ID + "/" + prop.pname) {
                                            property.inputToOutputProperties.Add(new Property.PropertyRefrence(pt.gameObject.GetComponent<Part>(), prop.pname));
                                        }
                                    }
                                }
                            }
                            property.inputToOutputPropertyRefrences.Clear();
                        }
                    }
                }
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
            static List<MeshCollider> DisableMeshColliders(GameObject o) {
                var ret = new List<MeshCollider>();
                if (o == null) { return ret; }
                var allColliders = o.GetComponentsInChildren<MeshCollider>(true);
                foreach (var v in allColliders) {
                    if (v.enabled) {
                        v.enabled = false;
                        ret.Add(v);
                    }
                }
                return ret;
            }
            public static Bounds CalculateLocalBounds(Transform transform) {

                var currentRotation = transform.rotation;

                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                var bounds = new Bounds(transform.position, Vector3.zero);

                var renderers = transform.GetComponentsInChildren<MeshRenderer>();
                foreach (var renderer in renderers) {
                    bounds.Encapsulate(renderer.bounds);
                }

                var localCenter = bounds.center - transform.position;
                bounds.center = localCenter;

                transform.rotation = currentRotation;

                return bounds;
                
                //previous bounds calc , uncomment if new method prooves wrong
                //return HBBuilder.BuilderUtils.GetGameObjectBounds(transform.gameObject);
            }
            /*
            static VehicleRoot VehicleGetOrAddVehicleRoot(GameObject o) {
                var vr = o.GetOrAddComponent<VehicleRoot>();

                vr.enabled = true;

                return vr;
            }
            static bool VehicleCheckMaySpawn(GameObject o, VehicleRoot vr, out string maySpawnError) {
                maySpawnError = "";
                if (HBNetworking.NetworkManager.isConnected && !HBNetworking.SessionSettingsManager.CheckVehicle(vr, out maySpawnError)) {
                    GameObject.Destroy(o);
                    return false;
                }
                return true;
            }
            static bool VehicleCheckMaySpawnForAsync(Scheduler.ScheduleItem item, GameObject o, VehicleRoot vr, Action<GameObject, string> onReturn) {
                var maySpawnError = "";
                if (HBNetworking.NetworkManager.isConnected && !HBNetworking.SessionSettingsManager.CheckVehicle(vr, out maySpawnError)) {
                    GameObject.Destroy(o);
                    PostReturn(item, onReturn, null, maySpawnError);
                    return false;
                }
                return true;
            }
            static void VehicleSetColliderIgnore(GameObject o) {
                var bodies = o.GetComponentsInChildren<Rigidbody>(true);
                var collidersPerBody = new List<Collider[]>();
                for (var i = 0; i < bodies.Length; i++) {
                    bodies[i].interpolation = RigidbodyInterpolation.Interpolate;
                    collidersPerBody.Add(bodies[i].gameObject.GetComponentsInChildren<Collider>(true));
                }

                var cc = collidersPerBody.Count;
                for (var i = 0; i < cc; i++) {
                    for (var j = 0; j < cc; j++) {
                        if (i != j) {
                            foreach (var c in collidersPerBody[i]) {
                                foreach (var c2 in collidersPerBody[j]) {
                                    Physics.IgnoreCollision(c, c2);
                                }
                            }
                        }
                    }
                }
                collidersPerBody.Clear();
            }
            static void VehicleSetPosition(GameObject o, Vector3 position, Quaternion rotation) {

                o.transform.position = position;
                o.transform.rotation = rotation;
                o.transform.localScale = Vector3.one;
            }
            static void VehicleAssignInitialConnIDForMyVehicle(GameObject o) {
                if (HBNetworking.NetworkManager.isConnected) {
                    var connid = HBNetworking.NetworkManager.connectors[0].myConnID;
                    var nb = o.GetComponent<HBNetworking.NetworkBase>();
                    if (nb != null) {
                        nb.connID = connid;
                    }
                    nb.instanceOwner = true;
                }
            }
            static void VehicleApplyPropertyReferences(GameObject o) {
                var parts = o.GetComponentsInChildren<Part>(true);
                ApplyReferencesChunk(parts, 0, parts.Length);
            }
            static void VehicleReadFromProperties(GameObject o ) {
                var parts = o.GetComponentsInChildren<Part>(true);
                foreach (var part in parts) {
                    part.OnReadFromPropertiesNew();
                }
            }
            static void VehicleApplyColliderPhysicsMaterial( GameObject o ) {
                var colliders = o.GetComponentsInChildren<Collider>(true);
                foreach (var collider in colliders) {
                    if (collider.sharedMaterial == null) {
                        collider.sharedMaterial = Resources.Load<PhysicMaterial>("PhysicsMaterials/VehiclePhyMat");
                    }
                }
            }
            static void VehicleApplyRendererShadowCastingMode(GameObject o) {
                var renderers = o.GetComponentsInChildren<Renderer>(true);
                foreach (var renderer in renderers) {
                    renderer.shadowCastingMode = HomebrewManager.vehicleShadowCastingMode;
                }
            }
            static void VehicleApplyNetworkPositionUpdateMode(GameObject o) {
                var networkPositions = o.GetComponentsInChildren<HBNetworking.Position>(true);
                foreach (var networkPosition in networkPositions) {
                    networkPosition.update = true;
                }
            }
            static void VehicleInitializeCogCalculators(GameObject o) {
                var coGCalculators = o.GetComponentsInChildren<CoGCalculator>(true);
                foreach (var cogs in coGCalculators) {
                    cogs.ForceCalcNew();
                }
            }
            static void VehicleInitializeDamageGrids(GameObject o) {
                var vehiclePieces = o.GetComponentsInChildren<VehiclePiece>();
                foreach (var vp in vehiclePieces) {
                    var vehiclePieceMass = 0f;
                    var vehiclePieceVolume = 0f;

                    var cogs = vp.GetComponentsInChildren<CoG>();
                    foreach (var cog in cogs) {
                        vehiclePieceMass += cog.mass;
                    }

                    var damageGrids = new List<DamageGrid>();
                    vp.GetComponentsInChildren<DamageGrid>(damageGrids);
                    foreach (var dg in damageGrids) {
                        dg.bounds = CalculateLocalBounds(dg.transform);
                        //dg.SetBoundsNew();
                        //var size = RoundVector(dg.bounds.size, 5);
                        vehiclePieceVolume += dg.bounds.size.x * dg.bounds.size.y * dg.bounds.size.z;
                    }

                    foreach (var dg in damageGrids) {
                        dg.Init(vehiclePieceMass, vehiclePieceVolume);
                        dg.entangledGrids = damageGrids;
                    }
                }
            }
            static void VehicleInitializeVehicleRoot(VehicleRoot vr) {
                vr.Init();
            }
            static void VehicleSetHBATransferCreateFilePath(GameObject o ,VehicleRoot vr , string path ) {

                var ntc = o.GetComponent<HBNetworking.HBATransferCreate>();
                if (ntc != null) {
                    ntc.InitTransferCreate(path);
                }

                //vr.spawned = true;
            }
            static void VehicleSetIsMyVehicle(VehicleRoot vr, bool isMyVehicle ) {
                if( vr == null ) { return; }
                vr.isMyVehicle = isMyVehicle;
            }
            static void VehicleDropVehicle(GameObject o) {
                var bodies = o.GetComponentsInChildren<Rigidbody>(true);
                foreach (var bodie in bodies) {
                    if (bodie.gameObject.tag != "Player") {
                        bodie.isKinematic = false;
                    }
                }
                var seats = o.GetComponentsInChildren<HBSeat>();
                foreach (var seat in seats) {
                    seat.OnDropVehicle();
                }
            }
            */
        }
    }

}
