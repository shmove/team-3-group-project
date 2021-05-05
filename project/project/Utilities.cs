using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace project {
    public static class Utilities {
        public static T GetReflect<T>(object Base, string Property) {
            return (T)Base.GetType().GetProperty(Property).GetValue(Base, null);
        }
        public static string[] GetPropertyNames(object Base){
            PropertyInfo[] Properties = Base.GetType().GetProperties();
            string[] PropertyNames = new string[]{};
            int i = 0;
            foreach(PropertyInfo Property in Properties) PropertyNames[i++] = Property.Name;
            return PropertyNames;
        }
        public static void SetReflect<T>(object Base, string Property, T Value) {
            Base.GetType().GetProperty(Property).SetValue(Base, Value, null);
        }
        public static MergedType<T, U> Merge<T, U>(T First, U Second){
            return new MergedType<T, U>(First, Second);
        }
    }
    //https://stackoverflow.com/a/6755221
    public class MergedType<T1, T2> : DynamicObject{
     T1 t1;
     T2 t2;
     Dictionary<string, object> members = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

     public MergedType(T1 t1, T2 t2)
     {
        this.t1 = t1;
        this.t2 = t2;
        foreach (System.Reflection.PropertyInfo fi in typeof(T1).GetProperties())
        {
           members[fi.Name] = fi.GetValue(t1, null);
        }
        foreach (System.Reflection.PropertyInfo fi in typeof(T2).GetProperties())
        {
           members[fi.Name] = fi.GetValue(t2, null);
        }
     }

     public override bool TryGetMember(GetMemberBinder binder, out object result)
     {
        string name = binder.Name.ToLower();
        return members.TryGetValue(name, out result);
     }
    }
}
