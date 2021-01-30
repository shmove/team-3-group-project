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

namespace project.PupilDataManager {
    class DbPupilDataManager : BasePupilDataManager {
        public static readonly string VERSION = "0.0.1.1";
        public static readonly int BUILD = 1;
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

            Catalog v_Catalog = new Catalog();
            v_Catalog.Create(CONNECTION_STRING_TEMPLATE + Location + "\\" + DATABASE_NAME + "; Jet OLEDB:Engine Type=5");
            Table PupilsTable = new Table();
            PupilsTable.Name = "Pupil";
            string[] TableNames = new string[] {"PupilUUID", "PupilID", "Name", "Company", "A2E", "ImgRef"}; //Notes will be a separate table!
            foreach (string Entry in TableNames) {
                PupilsTable.Columns.Append(Entry);
            }
            PupilsTable.Keys.Append("PrimaryKey", ADOX.KeyTypeEnum.adKeyPrimary, "PupilUUID", null, null);
            v_Catalog.Tables.Append(PupilsTable);

            Table NotesTable = new Table();
            NotesTable.Name = "Note";
            string[] TableNames2 = new string[] {"PupilUUID", "Note"};
            foreach(string Entry in TableNames2) {
                NotesTable.Columns.Append(Entry);
            }
            NotesTable.Keys.Append("ForeignKey", KeyTypeEnum.adKeyForeign, "PupilUUID", "Pupil", "PupilUUID");
            v_Catalog.Tables.Append(NotesTable);

            Table MetadataTable = new Table();
            MetadataTable.Name = "Metadata";
            string[] TableNames3 = new string[] {"Version", "Build", "DateCreated"};
            foreach(string Entry in TableNames3) {
                MetadataTable.Columns.Append(Entry);
            }
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
