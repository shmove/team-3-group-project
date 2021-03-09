using System;
using System.Collections.Generic;
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
    }
}
