using ADOX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.PupilDataManager.DbUtils {
    public class TableManager {
        public static readonly string VERSION = "0.1.7.10";
        public static readonly int BUILD = 10;
        public Catalog m_Catalog;
        public TableManager(Catalog p_Catalog){
            this.m_Catalog = p_Catalog;
        }
        public Table CreateTable(string TableName, ValueTuple<string, ADOX.DataTypeEnum, int>[] ColumnsInfo, string[] PrimaryKeys, ValueTuple<string, string, string>[] ForeignKeys){
            //ColumnsInfo: (<Column Name>, <Column Type>, <Max Data Size>)
            //ForeignKeys: (<Column Name>, <Foreign Table>, <Foreign Key Name>)

            Table v_Table = new Table();
            v_Table.Name = TableName;

            TableManager.AddColumns(v_Table, ColumnsInfo);
            TableManager.AddPrimaryKeys(v_Table, PrimaryKeys);
            TableManager.AddForeignKeys(v_Table, ForeignKeys);

            m_Catalog.Tables.Append(v_Table);

            return v_Table;
        }

        public static void AddColumns(Table CurrentTable, ValueTuple<string, ADOX.DataTypeEnum, int>[] ColumnProperties){
            foreach (var Column in ColumnProperties){
                if(Column.Item3 == -1) CurrentTable.Columns.Append(Column.Item1, Column.Item2);
                else CurrentTable.Columns.Append(Column.Item1, Column.Item2, Column.Item3);
            }
        }

        public static void AddPrimaryKeys(Table CurrentTable, string[] PrimaryKeys){
            if(PrimaryKeys == null || PrimaryKeys.Length == 0) return;
            CurrentTable.Keys.Append("PrimaryKey", ADOX.KeyTypeEnum.adKeyPrimary, PrimaryKeys[0], null, null);
            for(int i = 1; i < PrimaryKeys.Length; i++) CurrentTable.Keys["PrimaryKey"].Columns.Append(PrimaryKeys[i]); //Not sure if this works...
        }

        public static void AddForeignKeys(Table CurrentTable, ValueTuple<string, string, string>[] ForeignKeys){
            if(ForeignKeys == null || ForeignKeys.Length == 0) return;
            foreach(ValueTuple<string, string, string> ForeignKey in ForeignKeys) CurrentTable.Keys.Append("ForeignKey", KeyTypeEnum.adKeyForeign, ForeignKey.Item1, ForeignKey.Item2, ForeignKey.Item3);
        }
    }
}
