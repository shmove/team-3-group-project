using project.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.PupilDataManager.DbUtils {
    public class ConditionList {
        public string[] Conditions;
        public ConditionList(string[] p_Conditions = null){
            this.Conditions = p_Conditions ?? new string[]{};
        }
        public string Concatenate(){
            if(this.Conditions.Length != 0) return "WHERE " + string.Join(" AND ", this.Conditions);
            return "";
        }
    }

    public class Condition{
        public enum Operators{
            [StringValue("Test")]
            Equals = 0
        }
    }
}
