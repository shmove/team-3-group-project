using ADOX;
using project.Interfaces;
using project.PupilDataManager.SharedResources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static project.PupilDataManager.SharedResources.Types;

namespace project.PupilDataManager {
    class DbPupilDataManager : BasePupilDataManager {
        public static readonly string VERSION = "0.0.2.2";
        public static readonly int BUILD = 2;
        private static readonly string DEFAULT_DATABASE_LOCATION = Environment.GetEnvironmentVariable("LocalAppData") + "\\PupilRecordsProgram\\Databases";
        private static readonly string RELATIVE_PUPIL_PICTURES_LOCATION = "\\Pictures";
        private static readonly string DATABASE_NAME = "PleaseDontDeleteThis";
        private static readonly string CONNECTION_STRING_TEMPLATE = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ";
        public string DatabasePath;
        public DbPupilDataManager(string p_DatabasePath) : base(p_DatabasePath) {
            DatabasePath = p_DatabasePath;
        }

        public DbPupilDataManager() : base(DEFAULT_DATABASE_LOCATION) {
            DatabasePath = DEFAULT_DATABASE_LOCATION;
        }
        public override bool CheckIfInstalled(string Location) {
            this.DatabasePath = Location;
            if (Directory.Exists(Location)) {
                try {
                    Catalog v_Catalog = new Catalog();
                    v_Catalog.let_ActiveConnection(CONNECTION_STRING_TEMPLATE + Location);
                    //TODO: Check database integrity.
                    v_Catalog = null;
                } catch (Exception) {
                    return false;
                }
                return true;
            }
            return false;
        }
        public override void Install(string Location) {
            if (!Directory.Exists(Location)) Directory.CreateDirectory(Location);
            if (!Directory.Exists(Location + RELATIVE_PUPIL_PICTURES_LOCATION)) Directory.CreateDirectory(Location + RELATIVE_PUPIL_PICTURES_LOCATION);

            Action<Table, ValueTuple<string, ADOX.DataTypeEnum, int>[]> AddColumns = delegate(Table CurrentTable, ValueTuple<string, ADOX.DataTypeEnum, int>[] ColumnProperties){
                foreach (var Column in ColumnProperties){
                    if(Column.Item3 == -1) CurrentTable.Columns.Append(Column.Item1, Column.Item2);
                    else CurrentTable.Columns.Append(Column.Item1, Column.Item2, Column.Item3);
                }
            };

            Catalog v_Catalog = new Catalog();
            v_Catalog.Create(CONNECTION_STRING_TEMPLATE + Location + "\\" + DATABASE_NAME + "; Jet OLEDB:Engine Type=5");
            Table PupilsTable = new Table();
            PupilsTable.Name = "Pupil";
            
            AddColumns(PupilsTable, new ValueTuple<string, ADOX.DataTypeEnum, int>[]{
                ("PupilUUID", ADOX.DataTypeEnum.adVarWChar, 36),
                ("PupilID", ADOX.DataTypeEnum.adVarWChar, 16),
                ("Name", ADOX.DataTypeEnum.adVarWChar, 127),
                ("Company", ADOX.DataTypeEnum.adVarWChar, 160),
                ("A2E", ADOX.DataTypeEnum.adBoolean, -1),
                ("ImgRef", ADOX.DataTypeEnum.adVarWChar, 255)
            });

            PupilsTable.Keys.Append("PrimaryKey", ADOX.KeyTypeEnum.adKeyPrimary, "PupilUUID", null, null);
            v_Catalog.Tables.Append(PupilsTable);

            Table NotesTable = new Table();
            NotesTable.Name = "Note";
            
            AddColumns(NotesTable, new ValueTuple<string, ADOX.DataTypeEnum, int>[]{
                ("PupilUUID", ADOX.DataTypeEnum.adVarWChar, 36),
                ("Note", ADOX.DataTypeEnum.adLongVarWChar, 511),
                ("Date", ADOX.DataTypeEnum.adVarWChar, 22),
                ("UUID", ADOX.DataTypeEnum.adVarWChar, 36)
            });

            NotesTable.Keys.Append("ForeignKey", KeyTypeEnum.adKeyForeign, "PupilUUID", "Pupil", "PupilUUID");
            PupilsTable.Keys.Append("PrimaryKey", ADOX.KeyTypeEnum.adKeyPrimary, "UUID", null, null);
            v_Catalog.Tables.Append(NotesTable);

            Table MetadataTable = new Table();
            MetadataTable.Name = "Metadata";

            AddColumns(MetadataTable, new ValueTuple<string, ADOX.DataTypeEnum, int>[]{
                ("Version", ADOX.DataTypeEnum.adVarWChar, 16),
                ("Build", ADOX.DataTypeEnum.adVarWChar, -1),
                ("DateCreated", ADOX.DataTypeEnum.adVarWChar, 22)
            });
            v_Catalog.Tables.Append(MetadataTable);

            v_Catalog = null;

            OleDbConnection Connection = new OleDbConnection(CONNECTION_STRING_TEMPLATE + Location + "\\" + DATABASE_NAME);

            OleDbCommand InsertCommand = new OleDbCommand();
            InsertCommand.CommandType = CommandType.Text;
            InsertCommand.CommandText = "INSERT INTO [Metadata] ([Version], [Build], [DateCreated]) VALUES (@Version, @Build, @DateCreated)";
            InsertCommand.Parameters.AddWithValue("@Version", VERSION);
            InsertCommand.Parameters.AddWithValue("@Build", BUILD);
            InsertCommand.Parameters.AddWithValue("@DateCreated", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.s"));
            InsertCommand.Connection = Connection;

            Connection.Open();
            InsertCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public override List<T> CollatePropertyValuesFromPupils<T>(string Property) {
            throw new NotImplementedException();
        }

        public override bool ConfirmPupilIDIntegrity() {
            throw new NotImplementedException();
        }

        public override List<Pupil> GetPupilsByProperties(object Properties) {
            throw new NotImplementedException();
        }
        

        public override void WritePupilData(Pupil p_Pupil) {
            throw new NotImplementedException();
        }
    }
}
