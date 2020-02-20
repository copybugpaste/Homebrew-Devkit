using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

[HBS.SerializePartAttribute]
public class Part : MonoBehaviour {
   //#region LUA STUFF
   //private VehicleRoot root;
   //public bool IsSpawned {
   //    get {
   //        if (root != null) {
   //            return root.spawned;
   //        }
   //        return false;
   //    }
   //}
   ////bool useLua = false;
   //void Start() {
   //    root = GetComponentInParent<VehicleRoot>();
   //    StartPart();
   //}
   //public virtual void StartPart() {
   //
   //}
   //
   //#endregion
   // #region Stuff for BuildablePart...
   // ////////////////////////////////////////
   // //vars and methods for buildable parts...
   //
   // //it needs a partName 
   // //buildable part needs to know if this part is dynamic , meaning it will persist trough the baking proses
   // //if it is dynamic it needs the spawnrefrences to persist with the baking rposes > its absicly used to spawn the other BAked version of this part 
   // public string partName;
   // public bool dynamicPart = true;//when dynamic , the part will be saved when baked for (engines) //if static the part wont be saved it will jsut merge the mesh for (pipes)
   // public string spawnRefrenceType = "Resources";
   // public string spawnRefrencePath = "0HomebrewParts/Parts";
   // public bool isBuildable {
   //     get {
   //         if (GetComponentInParent<HBuildablePart>() != null) { return true; }
   //         if (GetComponentInParent<HBBuilder.Builder>() != null) { return true; }
   //         return false;
   //     }
   // }
   //
   //
   // public bool forConvert = false;
   // //[HideInInspector]
   // //public bool isWelded = false;
   [HBS.SerializePartVarAttribute]
   public bool forNewBuilder = false;
   [HBS.SerializePartVarAttribute]
   public Vector2 kismetPosition = Vector2.zero; //position of the kismetItem gets set when kismet changes position/closes , is saved using ToXElement in part
   //[HBS.SerializePartVarAttribute]
   public bool kismetPositionInitialized = true;
   [HBS.SerializePartVarAttribute]
   public string kismetData = "";
 //
 //  //refrence to current buildablepart this part is parented in
 //  public HBuildablePart buildPart;
 //
 //  //From and ToXelement for editable assembly saving
 //  public void ToXElement(XElement parent, int index) {
 //
 //      //write part , adjustablePart , properties and splitters
 //      XElement partE = new XElement("Part");
 //
 //      //write id
 //      RefrenceID ri = GetComponent<RefrenceID>();
 //      if (ri != null) {
 //          if (ri.instantiatedAtRuntime) {
 //              partE.Add(new XElement("ID", ri.ID));
 //          }
 //      }
 //
 //      //save RID wich is the index of the aprt in the buildablepart parts list
 //      partE.Add(new XElement("RID", index.ToString()));
 //
 //      //write kismet position
 //      partE.Add(new XElement("KPX", kismetPosition.x.ToString()));
 //      partE.Add(new XElement("KPY", kismetPosition.y.ToString()));
 //
 //      //write adjsutable part
 //      AdjustablePart ap = GetComponent<AdjustablePart>();
 //      if (ap != null) {
 //          ap.ToXElement(partE);
 //      }
 //
 //      //write properties
 //      PropertiesToXElement(partE);
 //
 //      if (buildPart != null) {
 //          if (buildPart.body != null) {
 //              //write splitters
 //              foreach (Splitter splitter in GetComponentsInChildren<Splitter>()) {
 //                  if (splitter.GetComponentInParent<Part>() == this) { //if this splitter is mine
 //                      splitter.ToXElement(partE);
 //                  }
 //              }
 //          }
 //      }
 //
 //      parent.Add(partE);
 //  }
 //  public void FromXElement(XElement parent) {
 //
 //      //read id
 //      RefrenceID ri = GetComponent<RefrenceID>();
 //      XElement idE = parent.Element("ID");
 //      if (idE != null && ri != null) {
 //          ri.ID = idE.Value;
 //          ri.instantiatedAtRuntime = true;
 //      }
 //
 //      //read kismet position
 //      XElement kpxE = parent.Element("KPX");
 //      if (kpxE != null) {
 //          float kismetX = 0f;
 //          float.TryParse(kpxE.Value, out kismetX);
 //          kismetPosition.x = kismetX;
 //      }
 //      XElement kpyE = parent.Element("KPY");
 //      if (kpyE != null) {
 //          float kismetY = 0f;
 //          float.TryParse(kpyE.Value, out kismetY);
 //          kismetPosition.y = kismetY;
 //      }
 //
 //      //read adjustable part
 //      AdjustablePart ap = GetComponent<AdjustablePart>();
 //      XElement apE = parent.Element("AdjustablePart");
 //      if (apE != null && ap != null) {
 //          ap.FromXElement(apE);
 //      }
 //
 //      //read properties
 //      XElement propsE = parent.Element("Props");
 //      if (propsE != null) {
 //          PropertiesFromXElement(propsE);
 //      }
 //
 //      //read splitter
 //      foreach (XElement splitterE in parent.Elements("Splitter")) {
 //          XElement splitteridE = splitterE.Element("RID");
 //          if (splitteridE != null) {
 //              foreach (Splitter splitter in GetComponentsInChildren<Splitter>()) {
 //                  if (splitter.GetComponentInParent<Part>() == this) { //if this splitter is mine
 //                      RefrenceID splitterid = splitter.GetComponent<RefrenceID>();
 //                      if (splitterid != null) {
 //                          if (splitterid.ID == splitteridE.Value) {
 //                              splitter.FromXElement(splitterE);
 //
 //                          }
 //                      }
 //                  }
 //              }
 //          }
 //      }
 //
 //  }
 //
 //  //Spreads Weld and UnWeld to the splitters
 //  public virtual void Weld() {
 //
 //      //isWelded = true;
 //
 //      //spread word to the splitters
 //      foreach (Splitter splitter in GetComponentsInChildren<Splitter>()) {
 //          if (splitter.GetComponentInParent<Part>() == this) { //if this splitter is mine
 //              splitter.Weld();
 //          }
 //      }
 //  }
 //  public virtual void UnWeld() {
 //
 //      //isWelded = false;
 //
 //      //spread word to the splitters
 //      foreach (Splitter splitter in GetComponentsInChildren<Splitter>()) {
 //          if (splitter.GetComponentInParent<Part>() == this) { //if this splitter is mine
 //              splitter.UnWeld();
 //          }
 //      }
 //
 //      //unlink all proprties if any , if we unlinked properties then trigger properties have changed TEST
 //      bool unlinkedSometing = false;
 //      foreach (Property p in properties) {
 //          if (p.Unlink(this)) {
 //              unlinkedSometing = true;
 //          }
 //      }
 //      if (unlinkedSometing) {
 //          DoReadFromProperties();
 //      }
 //  }
 //
 //  public XElement GetSpawnRefrence() {
 //      return new XElement("PrefabRefrence", new XElement("Type", spawnRefrenceType), new XElement("Path", spawnRefrencePath));
 //  }
 //
 //  ////////////////////////////////////////
 //  #endregion
    #region stuff for properties

    public List<Property> properties = new List<Property>();
    public List<Property> backupProperties = new List<Property>();
    [NonSerialized]
    public bool backedup = false;
    
    public void PropertiesToBytes( HBS.Writer writer) {
        if( properties == null ) { writer.Write(0); return; }
        writer.Write(properties.Count);
        foreach (var p in properties) {
            if (p.assetTypes == null) {
                writer.Write(0);
            } else {
                writer.Write(p.assetTypes.Count);
            }
            foreach( var at in p.assetTypes ) {
                writer.Write((int)at);
            }

            writer.Write(p.pname);
            writer.Write(p.descriptiveName);
            writer.Write((int)p.collapserName);
            writer.Write((int)p.type);
            writer.Write(p.value);
            writer.Write(p.minValue);
            writer.Write(p.maxValue);
            writer.Write(p.enumTypeName);
            writer.Write(p.buttonFunction);
            writer.Write((int)p.linkType);
            writer.Write(p.arrayBehavior);
            writer.Write(p.hidden);
            writer.Write(p.nonserialized);
            writer.Write(p.defaultValue);
            writer.Write(p.thisSingleLink);
            writer.Write(p.data);
            writer.Write(p.assetResourcePath);
        }
    }

    public void BytesToProperties( HBS.Reader reader) {
        properties = new List<Property>();
        var count = (int)reader.Read();
        for( var i = 0; i < count; i++ ) {

            var assetTypeCount = (int)reader.Read();
            var assetTypes = new List<HBAssetTypes>();
            for ( var o = 0; o < assetTypeCount; o++) {
                assetTypes.Add((HBAssetTypes)(int)reader.Read());
            }

            var p = new Property() {
                pname = (string)reader.Read(),
                descriptiveName = (string)reader.Read(),
                collapserName = (PropertyCollapseName)(int)reader.Read(),
                type = (PropertyType)(int)reader.Read(),
                value = (string)reader.Read(),
                minValue = (string)reader.Read(),
                maxValue = (string)reader.Read(),
                enumTypeName = (string)reader.Read(),
                buttonFunction = (string)reader.Read(),
                linkType = (PropertyLinkType)(int)reader.Read(),
                arrayBehavior = (bool)reader.Read(),
                assetTypes = assetTypes,
                hidden = (bool)reader.Read(),
                nonserialized = (bool)reader.Read(),
                defaultValue = (string)reader.Read(),
                thisSingleLink = (bool)reader.Read(),
                data = (string)reader.Read(),
                assetResourcePath = (string)reader.Read(),
            };

            properties.Add(p);
        }
    }

    public void PropertiesToXElement(XElement parent) {
        //save only value and name
        XElement propE = new XElement("Props");
        propE.Add(new XElement("Prefix", "0"));
        foreach (Property p in properties) {
            p.BakeXElement(propE, this);
        }
        parent.Add(propE);
    }
    public void PropertiesFromXElement(XElement parent) {
        //back properties on first read awakened with
        if (backedup == false) {
            backupProperties.Clear();
            foreach (Property p in properties) {
                backupProperties.Add(new Property(p));
            }
            backedup = true;
        }

        //remember current properties as backup properties
        //load only value and name
        properties.Clear();
        foreach (XElement e in parent.Elements("Prop")) {
            Property newProperty = new Property();
            newProperty.FromXElement(e);
            properties.Add(newProperty);
        }
    }
    public string PropertiesToString() {
        XElement properties = new XElement("Properties");
        PropertiesToXElement(properties);
        return properties.ToString();
    }
    public void PropertiesFromString(string data) {

        XElement d = XElement.Parse(data);
        XElement props = d.Element("Props");
        if (props != null) {
            PropertiesFromXElement(props);
        }
    }
    //public void ResetProperties() {
    //    //unlink all proeprties first
    //    foreach (Property p in properties) {
    //        p.Unlink(this);
    //    }
    //    //on properties changedis already triggered via propertyPanelUI
    //    //will reset the properties to those the object had when it awakened 
    //    properties.Clear();
    //    foreach (Property p in backupProperties) {
    //        properties.Add(new Property(p));
    //    }
    //}
    //public void ScanAndAddNewProperties() {
    //    //use this for when a part is outdated
    //    //it can keep its current properties but add those who got added since last update
    //
    //    //add new properties the object had when it awakened
    //    foreach (Property p in backupProperties) {
    //        bool found = false;
    //        foreach (Property pp in properties) {
    //            if (pp.pname == p.pname) {
    //                found = true;
    //                break;
    //            }
    //        }
    //        if (found == false) {
    //            properties.Add(p);
    //        }
    //    }
    //}
    //public string PropertiesToName() {
    //    //used to compare properties list with other properties lists
    //    StringWriter sw = new StringWriter();
    //    foreach (Property prop in properties) {
    //        sw.Write(prop.pname);
    //        sw.Write('|');
    //        sw.Write(prop.type.ToString());
    //        sw.Write(',');
    //    }
    //    string ret = sw.ToString();
    //    sw.Close();
    //    sw.Dispose();
    //    return ret;
    //}
    //public string GetPropertiesSumName() {
    //    StringWriter sw = new StringWriter();
    //    sw.Write(gameObject.name);
    //    sw.Write('|');
    //    foreach (Property prop in properties) {
    //        sw.Write(prop.pname);
    //        sw.Write('|');
    //        sw.Write(prop.type.ToString());
    //        sw.Write(',');
    //    }
    //    string ret = sw.ToString();
    //    sw.Close();
    //    sw.Dispose();
    //    return ret;
    //}
    public Property GetPropertyByName(string nam) {
        foreach (Property p in properties) {
            if (p.pname == nam) {
                return p;
            }
        }
        return null;
    }
    //public bool HasInputsOrOutputs() {
    //    foreach (Property prop in properties) {
    //        if (prop.type == PropertyType.PInput || prop.type == PropertyType.POutput || prop.type == PropertyType.KeybindOutput) {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
    //
    //public void AddProperty(Property p) {
    //    if (p == null) { return; }
    //    properties.Add(p);
    //}
    //
    //public void RemoveProperty(Property p) {
    //    if (p == null) { return; }
    //    properties.Remove(p);
    //}
    //
    //public void RemoveProperty(string pname) {
    //    if (string.IsNullOrEmpty(pname)) { return; }
    //    Property p = properties.Find((pp) => { return pp.pname == pname; });
    //    if (p == null) { return; }
    //    properties.Remove(p);
    //}

    #endregion

    #region Stuff for Part Baseclass...
    ////////////////////////////////////////

   // //when a part existed before it got spawned for others over the network
   // //it eneds to state sync all parts that need it 
   // //for example the shiftbox couldv been shifted , so it needs to know on what it was set when this object is now spawned for others
   // //so this function is called by state syncer on all Parts , each part can write tis custum data in it 
   // //if the aprt is not using this function it will jsut read/write 1 byte 
   // public virtual void WriteStateSyncData(BinaryWriter writer) {
   //
   // }
   // public virtual void ReadStateSyncData(BinaryReader reader) {
   //
   // }
   //
   // //When a propertie has changed or after an editable or baked vehicle is spawned , it triggers this function wich will read the properties and apply them to the actual part
   // public void OnReadFromProperties() {
   //     //reading from properties requires multyple passes
   //     StartCoroutine(DoReadFromProperties());
   // }
   // IEnumerator DoReadFromProperties() {
   //     //all parts inherit from this part so in here we trigger the ReadFromProperties Passes
   //     //also trigger it for all HBLinks
   //     foreach (HBLink link in GetComponents<HBLink>()) {
   //         link.ReadFromPropertiesPassImmediate();
   //     }
   //     ReadFromPropertiesPassImmediate();
   //     yield return new WaitForEndOfFrame();
   //     foreach (HBLink link in GetComponents<HBLink>()) {
   //         link.ReadFromPropertiesPass2();
   //     }
   //     ReadFromPropertiesPass2();
   //     yield return new WaitForEndOfFrame();
   //     foreach (HBLink link in GetComponents<HBLink>()) {
   //         link.ReadFromPropertiesPass3();
   //     }
   //     ReadFromPropertiesPass3();
   // }
   // public virtual void ReadFromPropertiesPassImmediate() {
   //
   // }
   // public virtual void ReadFromPropertiesPass2() {
   //
   // }
   // public virtual void ReadFromPropertiesPass3() {
   //
   // }
   //
   // public void OnReadFromPropertiesConvert() {
   //     forConvert = true;
   //     StartCoroutine(DoReadFromPropertiesNew());
   // }
   // [ContextMenu("ReadFromPropertiesNew")]
   // public void OnReadFromPropertiesNew() {
   //     //reading from properties requires multyple passes
   //     StartCoroutine(DoReadFromPropertiesNew());
   // }
   // IEnumerator DoReadFromPropertiesNew() {
   //     //all parts inherit from this part so in here we trigger the ReadFromProperties Passes
   //     //also trigger it for all HBLinks
   //     forNewBuilder = true;
   //     foreach (HBLink link in GetComponents<HBLink>()) {
   //         link.ReadFromPropertiesPassImmediate();
   //     }
   //     ReadFromPropertiesPassImmediateNew();
   //     yield return new WaitForEndOfFrame();
   //     foreach (HBLink link in GetComponents<HBLink>()) {
   //         link.ReadFromPropertiesPass2();
   //     }
   //     ReadFromPropertiesPass2New();
   //     yield return new WaitForEndOfFrame();
   //     foreach (HBLink link in GetComponents<HBLink>()) {
   //         link.ReadFromPropertiesPass3();
   //     }
   //     ReadFromPropertiesPass3New();
   // }
   // public virtual void ReadFromPropertiesPassImmediateNew() {
   //
   // }
   // public virtual void ReadFromPropertiesPass2New() {
   //
   // }
   // public virtual void ReadFromPropertiesPass3New() {
   //
   // }
   //
   // #endregion
   // #region stuff for damage
   // public float hp = 1f; //hp clamped between ( 0 - 1 )
   // public virtual void OnTakeDamage() {
   //
   // }
   // public IEnumerator StartTakeDamageDelay() {
   //     yield return new WaitForSeconds(UnityEngine.Random.value);
   //     OnTakeDamage();
   // }
   // public virtual void DamageEffect(int type) {
   //     switch (type) {
   //         case 0://electric
   //             AkSoundEngine.PostEvent("play_electricity_die", gameObject);
   //             DamageManager.SpawnSmokeEffect(transform.position, 100f, 0);
   //             break;
   //         case 1://combustion engine
   //             AkSoundEngine.PostEvent("play_combustion_engine_die", gameObject);
   //             DamageManager.SpawnSmokeEffect(transform.position, 100f, 0);
   //             break;
   //         case 2://jet rocket or ramjet
   //             DamageManager.SpawnExplosionEffect(transform.position, 100f, 0);
   //             break;
   //         case 3://fuel
   //             DamageManager.SpawnExplosionEffect(transform.position, 100f, 0);
   //             break;
   //         case 4://weapon
   //             DamageManager.SpawnSmokeEffect(transform.position, 100f, 0);
   //             break;
   //         case 5://ammo
   //             DamageManager.SpawnExplosionEffect(transform.position, 300f, 0);
   //             break;
   //         case 10://transmission
   //             DamageManager.SpawnSmokeEffect(transform.position, 100f, 0);
   //             break;
   //     }
   // }
    #endregion
}