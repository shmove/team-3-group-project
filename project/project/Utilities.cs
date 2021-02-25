using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project {
    public static class Utilities {
        public static T GetReflect<T>(object Base, string Property) {
            return (T)Base.GetType().GetProperty(Property).GetValue(Base, null);
        }
        public static void SetReflect<T>(object Base, string Property, T Value) {
            Base.GetType().GetProperty(Property).SetValue(Base, Value, null);
        }
    }
}
