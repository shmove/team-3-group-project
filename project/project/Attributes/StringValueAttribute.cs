using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Attributes {
    [AttributeUsage(AttributeTargets.Field)]
    class StringValueAttribute : Attribute{
        public string Value;
        public StringValueAttribute(string p_Value){
            Value = p_Value;
        }
    }
}
