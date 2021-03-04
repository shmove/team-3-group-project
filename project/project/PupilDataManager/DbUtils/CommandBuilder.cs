using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.PupilDataManager.DbUtils {
    public static class CommandBuilder {
        public static readonly string VERSION = "0.1.7.10";
        public static readonly int BUILD = 10;
        public static OleDbCommand BuildUpdateCommand<T>(OleDbConnection Connection, T Instance, string Table, string[] OmittedProperties, string Condition = ""){
            OleDbCommand Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;

            Type InstanceType = typeof(T);

            List<string> TypePropertyNames = new List<string>();
            int Length = InstanceType.GetProperties().Length;
            for(int i = 0; i < Length; i++) TypePropertyNames.Add(InstanceType.GetProperties()[i].Name);
            
            string CommandText = "UPDATE [" + Table + "]";
            for (dynamic i = 0, FirstTrueIteration = true; i < Length; i++) {
                string PropertyName = TypePropertyNames[i];
                if(OmittedProperties.Contains(PropertyName)) continue;
                if(FirstTrueIteration){
                    FirstTrueIteration = false;
                    CommandText += " SET ";
                }
                else CommandText += ", ";
                CommandText += "[" + PropertyName + "] = @Value" + i;
            }

            CommandText += Condition + ";";
            Command.CommandText = CommandText;

            for (int i = 0; i < Length; i++) {
                if(OmittedProperties.Contains(TypePropertyNames[i])) continue;
                var Value = InstanceType.GetProperty(TypePropertyNames[i]).GetValue(Instance, null);
                Command.Parameters.AddWithValue("@Value" + i, Value);
            }

            return Command;
        }

        public static OleDbCommand BuildInsertCommand<T>(OleDbConnection Connection, T Instance, string Table, string[] OmittedProperties = null, string[] AddedProperties = null, dynamic[] AddedPropertyValues = null){
            OmittedProperties = OmittedProperties ?? new string[]{};
            AddedProperties = AddedProperties ?? new string[]{};
            AddedPropertyValues = AddedPropertyValues ?? new dynamic[]{};
            OleDbCommand Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;

            Type InstanceType = typeof(T);

            List<(string Name, dynamic Value)> PropertyInfo = new List<(string, dynamic)>();
            List<string> ListedOmittedProperties = OmittedProperties.ToList();
            for(int i = 0, ExistingPropertiesCount = InstanceType.GetProperties().Length; i < ExistingPropertiesCount; i++) if(!ListedOmittedProperties.Contains(InstanceType.GetProperties()[i].Name)) PropertyInfo.Add((InstanceType.GetProperties()[i].Name, InstanceType.GetProperties()[i].GetValue(Instance, null)));
            for(int i = 0, AddedPropertiesCount = AddedProperties.Length; i < AddedPropertiesCount; i++) PropertyInfo.Add((AddedProperties[i], AddedPropertyValues[i]));
            
            int Length = PropertyInfo.Count;

            string CommandText = "INSERT INTO [" + Table + "]";

            for (int i = 0; i < Length; i++) {
                string PropertyName = PropertyInfo[i].Name;
                if(i == 0) CommandText += " (";
                else CommandText += ", ";
                CommandText += "[" + PropertyName + "]";
            }

            CommandText += ") VALUES";

            for (int i = 0; i < Length; i++) {
                if(i == 0) CommandText += " (";
                else CommandText += ", ";
                CommandText += "@Value" + i;
            }

            CommandText += ");";

            Command.CommandText = CommandText;
            for (int i = 0; i < Length; i++) {
                Command.Parameters.AddWithValue("@Value" + i, PropertyInfo[i].Value);
            }

            return Command;
        }

        public static OleDbCommand BuildSelectCommand<T>(OleDbConnection Connection, T Instance, string Table, string[] OmittedProperties = null, string[] AddedProperties = null, ConditionList Conditions = null){
            OmittedProperties = OmittedProperties ?? new string[]{};
            AddedProperties = AddedProperties ?? new string[]{};
            Conditions = Conditions ?? new ConditionList();
            OleDbCommand Command = new OleDbCommand();
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;

            Type InstanceType = typeof(T);

            List<string> PropertyNames = new List<string>();
            List<string> ListedOmittedProperties = OmittedProperties.ToList();
            for(int i = 0, ExistingPropertiesCount = InstanceType.GetProperties().Length; i < ExistingPropertiesCount; i++) if(!ListedOmittedProperties.Contains(InstanceType.GetProperties()[i].Name)) PropertyNames.Add(InstanceType.GetProperties()[i].Name);
            for(int i = 0, AddedPropertiesCount = AddedProperties.Length; i < AddedPropertiesCount; i++) PropertyNames.Add(AddedProperties[i]);
            
            int Length = PropertyNames.Count;
            
            string CommandText = "SELECT ";
            for (dynamic i = 0, FirstTrueIteration = true; i < Length; i++) {
                string PropertyName = PropertyNames[i];
                if(OmittedProperties.Contains(PropertyName)) continue;
                if(FirstTrueIteration){
                    FirstTrueIteration = false;
                    CommandText += "";
                }
                else CommandText += ", ";
                CommandText += "[" + PropertyName + "] = @Value" + i;
            }

            CommandText += " FROM [" + Table + "] " + Conditions.Concatenate() + ";";

            Command.CommandText = CommandText;
            for (int i = 0; i < Length; i++) {
                Command.Parameters.AddWithValue("@Value" + i, PropertyNames[i]);
            }

            return Command;
        }
    }
}
