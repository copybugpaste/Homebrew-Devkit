using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

    [Serializable]
    public class Property {

        //[NonSerialized]
        //public Part parent;
        //[NonSerialized]
        //public PropertyUI UIparent;
        //[NonSerialized]
        //public PropertyUI UIparentKismet;
        public string data;
        public string pname;
        public string descriptiveName;
        public PropertyCollapseName collapserName;
        public PropertyType type;
        public string value;
        public string minValue;
        public string maxValue;
        public string enumTypeName;
        public string buttonFunction;
        public PropertyLinkType linkType;
        public bool arrayBehavior = false;
        public List<HBAssetTypes> assetTypes = new List<HBAssetTypes>();//used on ASset properties , the type or types of asset to load
        public bool hidden = false;
        public bool nonserialized = false;
        public string defaultValue;
        public bool thisSingleLink = false;//some parts with a multylink type need single links 
        public string assetResourcePath = "";
        public bool isOutput {
            get {
                return (type == PropertyType.POutput || type == PropertyType.KeybindOutput);
            }
        }
        public bool isInput {
            get {
                return type == PropertyType.PInput;
            }
        }
        public bool singleLink {
            get {
                if (thisSingleLink) {
                    return true;
                }
                switch (linkType) {
                    case PropertyLinkType.Driveshaft:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public List<PropertyRefrence> outputToInputProperties = new List<PropertyRefrence>();
        public List<PropertyRefrence> inputToOutputProperties = new List<PropertyRefrence>();
        public List<string> outputToInputPropertyRefrences = new List<string>();
        public List<string> inputToOutputPropertyRefrences = new List<string>();

        public Property() {
        }
        public Property(Property p) {
            pname = p.pname;
            descriptiveName = p.descriptiveName;
            collapserName = p.collapserName;
            type = p.type;
            value = p.value;
            minValue = p.minValue;
            maxValue = p.maxValue;
            enumTypeName = p.enumTypeName;
            buttonFunction = p.buttonFunction;
            linkType = p.linkType;
            arrayBehavior = p.arrayBehavior;
            assetTypes = p.assetTypes;
            hidden = p.hidden;
            nonserialized = p.nonserialized;
            defaultValue = p.defaultValue;
            thisSingleLink = p.thisSingleLink;
            data = p.data;
            assetResourcePath = p.assetResourcePath;
        }

        //public string GetCollapserName() {
        //    if (collapserName == PropertyCollapseName.None) { return ""; }
        //    return collapserName.ToString();
        //}
        //public Color GetLinkColor() {
        //    if (type == PropertyType.PInput || type == PropertyType.POutput || type == PropertyType.KeybindOutput) {
        //        if (linkType == PropertyLinkType.Air) {
        //            return new Color(0.0f, 1f, 1f, 1f);
        //        }
        //        if (linkType == PropertyLinkType.Ammo) {
        //            return new Color(0.4f, 0.6f, 0.3f, 1f);
        //        }
        //        if (linkType == PropertyLinkType.Driveshaft) {
        //            return new Color(0f, 0.5f, 0f, 1f);
        //        }
        //        if (linkType == PropertyLinkType.ElectricWire) {
        //            return new Color(241f / 255f, 176f / 255f, 23f / 255f, 1f);
        //        }
        //        if (linkType == PropertyLinkType.Float) {
        //            return new Color(40f / 255f, 161f / 255f, 211f / 255f, 1f);
        //        }
        //        if (linkType == PropertyLinkType.Fuel) {
        //            return new Color(238f / 255f, 78f / 255f, 18f / 255f, 1f);
        //        }
        //        if (linkType == PropertyLinkType.Joint) {
        //            return new Color(1f, 0.5f, 0f, 1f);
        //        }
        //        if (linkType == PropertyLinkType.SimpleDriveshaft) {
        //            return new Color(138f / 255f, 183f / 255f, 27f / 255f, 1f);
        //        }
        //        if (linkType == PropertyLinkType.Vector) {
        //            return new Color(0.5f, 0f, 1f, 1f);
        //        }
        //        if (linkType == PropertyLinkType.Seat) {
        //            return new Color(1f, 0.5f, 0f, 1f);
        //        }
        //    }
        //    return Color.white;
        //}
        //
        ////UnLink adn Link will link output to input AND input to output , use these to link and unlink parts , itl auto keep the ito and oti lists in order
        //public bool Unlink(Part myPart) {
        //    bool unlinkedSometing = false;
        //    if (outputToInputProperties.Count > 0 || inputToOutputProperties.Count > 0) {
        //        unlinkedSometing = true;
        //    }
        //    foreach (PropertyRefrence pref in outputToInputProperties) {
        //        if (pref.GetProperty() != null) {
        //            pref.GetProperty().RemoveInputLink(myPart, this);
        //            pref.part.OnReadFromProperties();//NEW call read from props on the other side of the link 
        //        }
        //    }
        //    outputToInputProperties.Clear();
        //    foreach (PropertyRefrence pref in inputToOutputProperties) {
        //        if (pref.GetProperty() != null) {
        //            pref.GetProperty().RemoveOutputLink(myPart, this);
        //            pref.part.OnReadFromProperties();//NEW call read from props on the other side of the link 
        //        }
        //    }
        //    inputToOutputProperties.Clear();
        //    return unlinkedSometing;
        //}
        //
        //public bool Link(Part myPart, Part toPart, Property p) {
        //    if (isInput && p.isInput) { return false; }
        //    if (isOutput && p.isOutput) { return false; }
        //    if (p.linkType != linkType) { return false; }
        //    if (isInput) {
        //        p.AddOutputLink(myPart, this);
        //        return AddInputLink(toPart, p);
        //    } else {
        //        p.AddInputLink(myPart, this);
        //        return AddOutputLink(toPart, p);
        //    }
        //}
        //public bool LinkNew(Part myPart, Part toPart, Property p) {
        //    if (isInput && p.isInput) { return false; }
        //    if (isOutput && p.isOutput) { return false; }
        //    if (p.linkType != linkType) { return false; }
        //
        //    //dont link multiple float outputs to float input
        //    //if (p.linkType == PropertyLinkType.Float) {
        //    //    if (isOutput) {
        //    //        if (p.inputToOutputProperties.Count > 0) { return false; }
        //    //    }
        //    //    if (isInput) {
        //    //        if (inputToOutputProperties.Count > 0) { return false; }
        //    //    }
        //    //}
        //
        //    if (isInput) {
        //        p.AddOutputLink(myPart, this);
        //        return AddInputLink(toPart, p);
        //    } else {
        //        p.AddInputLink(myPart, this);
        //        return AddOutputLink(toPart, p);
        //    }
        //
        //}
        //public bool UnlinkNew(Part myPart) {
        //    bool unlinkedSometing = false;
        //    if (outputToInputProperties.Count > 0 || inputToOutputProperties.Count > 0) {
        //        unlinkedSometing = true;
        //    }
        //    foreach (PropertyRefrence pref in outputToInputProperties) {
        //        if (pref.GetProperty() != null) {
        //            pref.GetProperty().RemoveInputLink(myPart, this);
        //            pref.part.OnReadFromPropertiesNew();// call read from props on the other side of the link 
        //        }
        //    }
        //    outputToInputProperties.Clear();
        //    foreach (PropertyRefrence pref in inputToOutputProperties) {
        //        if (pref.GetProperty() != null) {
        //            pref.GetProperty().RemoveOutputLink(myPart, this);
        //            pref.part.OnReadFromPropertiesNew();// call read from props on the other side of the link 
        //        }
        //    }
        //    inputToOutputProperties.Clear();
        //    return unlinkedSometing;
        //}
        //
        //public bool AddOutputLink(Part toPart, Property p) {
        //    foreach (PropertyRefrence pref in outputToInputProperties) {
        //        if (pref.part == toPart && pref.propertyName == p.pname) {
        //            //already have this one 
        //            return false;
        //        }
        //    }
        //    PropertyRefrence newRef = new PropertyRefrence(toPart, p.pname);
        //    outputToInputProperties.Add(newRef);
        //    return true;
        //}
        //public bool RemoveOutputLink(Part toPart, Property p) {
        //    PropertyRefrence tr = null;
        //    foreach (PropertyRefrence pref in outputToInputProperties) {
        //        if (pref.part == toPart && pref.propertyName == p.pname) {
        //            tr = pref;
        //            break;
        //        }
        //    }
        //    if (tr != null) {
        //        outputToInputProperties.RemoveAll(PropertyRefrence => PropertyRefrence == tr);
        //        return true;
        //    }
        //    return false;
        //}
        //public bool AddInputLink(Part toPart, Property p) {
        //    foreach (PropertyRefrence pref in inputToOutputProperties) {
        //        if (pref.part == toPart && pref.propertyName == p.pname) {
        //            //already have this one 
        //            return false;
        //        }
        //    }
        //    PropertyRefrence newRef = new PropertyRefrence(toPart, p.pname);
        //    inputToOutputProperties.Add(newRef);
        //    return true;
        //}
        //public bool RemoveInputLink(Part toPart, Property p) {
        //    PropertyRefrence tr = null;
        //    foreach (PropertyRefrence pref in inputToOutputProperties) {
        //        if (pref.part == toPart && pref.propertyName == p.pname) {
        //            tr = pref;
        //            break;
        //        }
        //    }
        //    if (tr != null) {
        //        inputToOutputProperties.RemoveAll(PropertyRefrence => PropertyRefrence == tr);
        //        return true;
        //    }
        //    return false;
        //}
        //
        //public string[] GetOptions() {
        //    if (type == PropertyType.Asset) {
        //        if (string.IsNullOrEmpty(assetResourcePath) == false) {
        //            GameObject[] all = Resources.LoadAll<GameObject>(assetResourcePath);
        //            List<string> ret = new List<string>();
        //            foreach (GameObject a in all) {
        //                ret.Add(a.name);
        //            }
        //            return ret.ToArray();
        //        }
        //    }
        //    if (type == PropertyType.Enum) {
        //        return Enum.GetNames(System.Type.GetType(enumTypeName));
        //    }
        //    return new string[0];
        //}
        //
        //public string GetLinKType() {
        //    if (isInput == false && isOutput == false) { return ""; }
        //    return linkType.ToString();
        //}
        ///// <summary>
        ///// Bakes the part to an XML
        ///// TODO: Get rid of all the useless information. 
        ///// For instance: If you have a float wire, you don't need e,bf,lt,ab,ns,dvl,at,etc.. Especially when baking a vehicle e_e 
        ///// that's just a stupid amount of data
        ///// </summary>
        ///// <param name="parentE">The parent XElement to add this info in</param>
        ///// <param name="part">The part to bake</param>
        public void BakeXElement(XElement parentE, Part part) {
            //save everyting about the property
            XElement propE = new XElement("Prop");
            propE.Add(new XElement("n", pname));
            propE.Add(new XElement("dn", descriptiveName));
            propE.Add(new XElement("cn", collapserName.ToString()));
            propE.Add(new XElement("t", type.ToString()));
            //if this is a nonserialized property then save the default prop as prop
            if (nonserialized) {
                propE.Add(new XElement("v", defaultValue));
            } else {
                propE.Add(new XElement("v", value));
            }
            propE.Add(new XElement("mv", minValue));
            propE.Add(new XElement("mxv", maxValue));
            propE.Add(new XElement("e", enumTypeName));
            propE.Add(new XElement("bf", buttonFunction));
            propE.Add(new XElement("lt", linkType.ToString()));
            propE.Add(new XElement("ab", arrayBehavior.ToString()));
            propE.Add(new XElement("h", hidden.ToString()));
            propE.Add(new XElement("ns", nonserialized.ToString()));
            propE.Add(new XElement("dvl", defaultValue));
            propE.Add(new XElement("tsl", thisSingleLink.ToString()));
            propE.Add(new XElement("data", data));
            propE.Add(new XElement("arp", assetResourcePath));
        
            XElement assetTypesE = new XElement("AssetTypes");
            foreach (HBAssetTypes assettype in assetTypes) {
                assetTypesE.Add(new XElement("at", assettype.ToString()));
            }
            propE.Add(assetTypesE);
        
            XElement otilinks = new XElement("OutputToInputLinks");
            if (outputToInputProperties != null) {
                foreach (PropertyRefrence outputToInputProperty in outputToInputProperties) {
                    if (outputToInputProperty.part != null) {//coudv been unwelded
                        otilinks.Add(new XElement("pl", outputToInputProperty.part.GetComponent<RefrenceID>().ID + "/" + outputToInputProperty.propertyName));
                    }
                }
            }
            propE.Add(otilinks);
            XElement itolinks = new XElement("InputToOutputLinks");
            if (inputToOutputProperties != null) {
                foreach (PropertyRefrence inputToOutputProperty in inputToOutputProperties) {
                    if (inputToOutputProperty.part != null) {//coudv been unwelded
                        itolinks.Add(new XElement("pl", inputToOutputProperty.part.GetComponent<RefrenceID>().ID + "/" + inputToOutputProperty.propertyName));
                    }
                }
            }
            propE.Add(itolinks);
        
            parentE.Add(propE);
        }
        public void FromXElement(XElement parentE) {
            if (parentE.Element("n") != null) {
                pname = parentE.Element("n").Value;
            }
            if (parentE.Element("dn") != null) {
                descriptiveName = parentE.Element("dn").Value;
            }
            if (parentE.Element("cn") != null) {
                if (parentE.Element("cn").Value != "") {
                    collapserName = (PropertyCollapseName)Enum.Parse(typeof(PropertyCollapseName), parentE.Element("cn").Value);
                } else {
                    collapserName = PropertyCollapseName.None;
                }
            }
            if (parentE.Element("t") != null) {
                type = (PropertyType)Enum.Parse(typeof(PropertyType), parentE.Element("t").Value);
            }
            if (parentE.Element("v") != null) {
                value = parentE.Element("v").Value;
            }
            if (parentE.Element("mv") != null) {
                minValue = parentE.Element("mv").Value;
            }
            if (parentE.Element("mxv") != null) {
                maxValue = parentE.Element("mxv").Value;
            }
            if (parentE.Element("e") != null) {
                enumTypeName = parentE.Element("e").Value;
            }
            if (parentE.Element("bf") != null) {
                buttonFunction = parentE.Element("bf").Value;
            }
            if (parentE.Element("lt") != null) {
                linkType = (PropertyLinkType)Enum.Parse(typeof(PropertyLinkType), parentE.Element("lt").Value);
            }
            if (parentE.Element("ab") != null) {
                arrayBehavior = bool.Parse(parentE.Element("ab").Value);
            }
            if (parentE.Element("h") != null) {
                hidden = bool.Parse(parentE.Element("h").Value);
            }
            if (parentE.Element("ns") != null) {
                nonserialized = bool.Parse(parentE.Element("ns").Value);
            }
            if (parentE.Element("dvl") != null) {
                defaultValue = parentE.Element("dvl").Value;
            }
            if (parentE.Element("tsl") != null) {
                thisSingleLink = bool.Parse(parentE.Element("tsl").Value);
            }
            if (parentE.Element("data") != null) {
                data = parentE.Element("data").Value;
            }
            if (parentE.Element("arp") != null) {
                assetResourcePath = parentE.Element("arp").Value;
            }
        
            assetTypes.Clear();
            XElement assetTypesE = parentE.Element("AssetTypes");
            if (assetTypesE != null) {
                foreach (XElement assettypeE in assetTypesE.Elements("at")) {
                    assetTypes.Add((HBAssetTypes)System.Enum.Parse(typeof(HBAssetTypes), assettypeE.Value));
                }
            }
        
            outputToInputPropertyRefrences.Clear();
            XElement otilinksE = parentE.Element("OutputToInputLinks");
            if (otilinksE != null) {
                foreach (XElement plE in otilinksE.Elements("pl")) {
                    outputToInputPropertyRefrences.Add(plE.Value);
                }
            }
            //cleanup
            otilinksE = null;
            
            inputToOutputPropertyRefrences.Clear();
            XElement itolinksE = parentE.Element("InputToOutputLinks");
            if (itolinksE != null) {
                foreach (XElement plE in itolinksE.Elements("pl")) {
                    inputToOutputPropertyRefrences.Add(plE.Value);
                }
            }
        
            //cleanup
            //itolinksE = null;
        
            //clenaup
            parentE = null;
        }
        //
        public void ApplyRefrences(Part[] allparts) {
            //Debug.Log("Applying refrences on " + pname + "  " + outputToInputPropertyRefrences.Count.ToString() + "  "+ inputToOutputPropertyRefrences.Count.ToString()  );
            //OUTPUT TO INPUT
            if (outputToInputPropertyRefrences.Count > 0) {
                outputToInputProperties.Clear();
                foreach (string path in outputToInputPropertyRefrences) {
                    foreach (Part part in allparts) {
                        foreach (Property prop in part.properties) {
                            string pPath = part.GetComponent<RefrenceID>().ID + "/" + prop.pname;
                            if (pPath == path) {
                                //Debug.Log("OTI added :" + pPath);
                                outputToInputProperties.Add(new PropertyRefrence(part.gameObject.GetComponent<Part>(), prop.pname));
                            }
                        }
                    }
                }
                //cleanup
                outputToInputPropertyRefrences.Clear();
            }
        
        
        
            //INPUT TO OUTPUT
            if (inputToOutputPropertyRefrences.Count > 0) {
                inputToOutputProperties.Clear();
                foreach (string path in inputToOutputPropertyRefrences) {
                    foreach (Part part in allparts) {
                        foreach (Property prop in part.properties) {
                            string pPath = part.GetComponent<RefrenceID>().ID + "/" + prop.pname;
                            if (pPath == path) {
                                //Debug.Log("ITO added :" + pPath);
                                inputToOutputProperties.Add(new PropertyRefrence(part.gameObject.GetComponent<Part>(), prop.pname));
                            }
                        }
                    }
                }
                //cleanup
                inputToOutputPropertyRefrences.Clear();
            }
        
        }

    
        [System.Serializable]
        public class PropertyRefrence {
        
            public Part part;
            public string propertyName;
            public PropertyRefrence(Part p, string pname) {
                part = p;
                propertyName = pname;
            }
            public Property GetProperty() {
                if (part == null) {
                    return null;
                }
                return part.GetPropertyByName(propertyName);
            }
        }

    }
    public enum HBToolType {
        Select,
        Adjust,
        Weld,
        Symetry,
        Pipe,//outdated after 2/09/2011 sure bout it
        SimplePipe,
        CurvedPipe,
    }
    public enum PropertyType {
        Bool = 1,
        Int = 2,
        Float = 3,
        Text = 4,
        Password = 5,
        Email = 6,
        Dialoge = 7,
        Slider = 8,
        PInput = 9,
        POutput = 10,
        Button = 11,
        Enum = 12,
        KeybindOutput = 13,
        Asset = 14,
    }
    public enum PropertyLinkType {
        Fuel,
        Float,
        ElectricWire,
        Driveshaft,
        SimpleDriveshaft,
        Air,
        Joint,
        Ammo,
        Vector,
        Seat,
    }
    public enum BuildNodeType {
        Standart,
        OneWay
    }
    public enum MovableNodeType {
        BezierMain,
        Bezier,
        Position,
        Stretch,
    }
    public enum MeshCombine {
        Static, //is static for all lods , handy for pipes
        StaticLOD0,
        StaticLOD1,
        StaticLOD2,
        DynamicLOD0, //will be dynamic on lod0
        DynamicLOD1, //will be dynamic on lod0 and lod1
        Dynamic //will always be dynamic
    }
    public enum Splittertype {
        Rotator,
        Joint
    }
    public enum InputType {
        Keyboard,
        Mouse,
        Joystick
    }
    public enum KeybindType {
        Button,
        Axis,
        ButtonAxis,
        Toggle,
    }
    public enum HBAssetTags {
        Project,
        Local,
        Part,
        Assembly,
        Electric,
        Combustion,
        Pipe,
        Wheel,
        Propellor,
        Adjustable,
        New,
        Plate,
        Gear,
        Sensor,
        Engine,
        AiroDynamics,
        Programmable,
        Curve,
        Straight,
        Template,
        Other,
        WorkshopUploaded,
        WorkshopDownloaded,
        WorkshopEdit,
        EnviromentVehicle,
        Favorite,
    }
    public enum BrowserActionType {
        Delete,
        Rename,
        Clone,
        FastEdit,
        UploadToWorkshop,
        Favorite,
    }
    public enum HBAssetTypes {
        None,
        Part,
        Pipe,
        Assembly,
        Project,
        Template,
        Vehicle,
        Wheel,
        Propellor,
        SteerWheel,
        VideoSettingsPreset,
        GameplaySettingsPreset,
        AudioSettingsPreset,
        KeybindSettingsPreset,
        Effect,
        PipePart,
        WorkshopUpload,
        WorkshopDownload,
        SolidRocket,
        DefaultVehicles,
        HeliPropellor,
    }
    public enum HBRefrenceType {
        AppData,
        Resources,
        Assetbundle,
    }
    public enum AdjustablePipeType {
        Straight,//<----------->
        Curved,//O--o------o---O
        Simple,//O------------O
    }
    public enum CurveType {
        Bezier,
        Circular,
        Straight,
    }
    public enum QuestionBoxType {
        OkCancel,
        SaveDontSaveCancel,
        OverwriteDontOverwriteCancel,
        YesNo,
    }
    public enum PropertyCollapseName {
        Properties,
        Controls,
        Inputs,
        Outputs,
        None
    }
    public enum SpeedType {
        KilometresPerHour,
        MilesPerHour,
        MetresPerSecond,
        Knots,
    }
    public enum ThirdPersonCameraMode {
        Action,
        Loose,
        Fixed,
        Lookaround,
    }

