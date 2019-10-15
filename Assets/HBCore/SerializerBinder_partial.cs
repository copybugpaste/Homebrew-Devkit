using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
namespace HBS {
    public partial class SerializerBinder {
        public static Dictionary<Type,Action<Writer,object>> bindsSer = new Dictionary<Type,Action<Writer,object>>();
        public static Dictionary<Type,Func<Reader,object,object>> bindsRes = new Dictionary<Type,Func<Reader,object,object>>();

        public static void Serialize( HBS.Writer writer, object o ) {
            if( writer.WriteNull(o)) { return; }
            if(bindsSer.ContainsKey(o.GetType()) == false ){Debug.LogWarning( o.GetType().FullName + " not found in bindings" ); writer.Write('<'); return; } else { writer.Write('>');}
            bindsSer[o.GetType()].Invoke(writer,o);
        }
        public static object Unserialize( HBS.Reader reader , Type t , object o = null) {
            if( reader.ReadNull() ) { return null; }
            if( reader.ReadNull() ) { return null; }
            return bindsRes[o.GetType()].Invoke(reader,o);//t not realy needed?
        }
    }
}