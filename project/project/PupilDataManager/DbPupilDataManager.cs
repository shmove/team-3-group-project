using ADOX;
using project.Interfaces;
using project.PupilDataManager.SharedResources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static project.PupilDataManager.SharedResources.Types;
using project.PupilDataManager.DbUtils;

namespace project {
    /// <summary>
    /// This is version 0.1.8.11 of DbPupilDataManager.                                                                        <br />
    ///                                                                                                                        <br />
    /// This version supports:                                                                                                 <br />
    ///                                                                                                                        <br />
    ///  -  Getting a pupil's info with their name,                                                                            <br />
    ///  -  Getting a list of pupils with certain properties.                                                                  <br />
    ///  -  Write / update pupil data to the database.                                                                         <br />
    ///  -  Generate test cases (doesn't contain notes)                                                                        <br />
    ///  -  Having multiple pupils with the same name.                                                                         <br />
    ///  -  Collating property values from pupils.                                                                             <br />
    ///  -  Has a basic installation process.                                                                                  <br />
    ///  -  Deleting pupils from the database.                                                                                 <br />
    ///                                                                                                                        <br />
    /// This version doesn't support:                                                                                          <br />
    ///                                                                                                                        <br />
    ///  -  Support for multiple users.                                                                                        <br />
    /// 
    /// </summary>
    class DbPupilDataManager : BasePupilDataManager {
        public static readonly string VERSION = "0.1.8.11";
        public static readonly int BUILD = 11;
        private static readonly string DEFAULT_DATABASE_LOCATION = Environment.GetEnvironmentVariable("LocalAppData") + "\\PupilRecordsProgram\\Databases";
        private static readonly string RELATIVE_PUPIL_PICTURES_LOCATION = "\\Pictures";
        private static readonly string DATABASE_NAME = "PleaseDontDeleteThis";
        private static readonly string CONNECTION_STRING_TEMPLATE = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ";
        private static readonly string[] PUPIL_TABLE_COLUMN_NAMES = new string[]{"PupilUUID", "PupilID", "Name", "Company", "A2E"};
        public string ConnectionString;
        /// <summary>
        /// Sets a custom database location.
        /// </summary>
        /// <param name="p_DatabasePath"></param>
        public DbPupilDataManager(string p_DatabasePath) : base(p_DatabasePath) {
            //DatabasePath = p_DatabasePath;
        }
        /// <summary>
        /// Constructs with the default database location.
        /// </summary>
        public DbPupilDataManager() : base(DEFAULT_DATABASE_LOCATION) {
            //DatabasePath = DEFAULT_DATABASE_LOCATION;
        }
        /// <summary>
        /// Checks whether the DbPupilDataManager has been ran previously, and installed.
        /// In the future, it will also check for database integrity, etc.
        /// </summary>
        /// <param name="Location"></param>
        /// <returns>Whether DbPupilDataManager has already been installed.</returns>
        public override bool CheckIfInstalled(string Location) {
            string DatabasePath = Location + "\\" + DATABASE_NAME;
            this.ConnectionString = DefaultConnectionStringBuilder.BuildConnectionString(DatabasePath);
            if (Directory.Exists(Location)) {
                try {
                    Catalog v_Catalog = new Catalog();
                    v_Catalog.let_ActiveConnection(CONNECTION_STRING_TEMPLATE + Location + "\\" + DATABASE_NAME);
                    //TODO: Check database integrity.
                    v_Catalog = null;
                } catch (Exception) {
                    return false;
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Installs the DbPupilDataManager, creating the database and setting up the tables.
        /// </summary>
        /// <param name="Location"></param>
        public override void Install(string Location) {
            if (!Directory.Exists(Location)) Directory.CreateDirectory(Location);
            if (!Directory.Exists(Location + RELATIVE_PUPIL_PICTURES_LOCATION)) Directory.CreateDirectory(Location + RELATIVE_PUPIL_PICTURES_LOCATION);

            Catalog v_Catalog = new Catalog();
            v_Catalog.Create(this.ConnectionString);

            TableManager v_TableManager = new TableManager(v_Catalog);

            v_TableManager.CreateTable("Pupil", new ValueTuple<string, ADOX.DataTypeEnum, int>[]{
                ("PupilUUID", ADOX.DataTypeEnum.adVarWChar, 36),
                ("PupilID", ADOX.DataTypeEnum.adVarWChar, 16),
                ("Name", ADOX.DataTypeEnum.adVarWChar, 127),
                ("Company", ADOX.DataTypeEnum.adVarWChar, 160),
                ("A2E", ADOX.DataTypeEnum.adBoolean, -1)
            }, new string[]{"PupilUUID"}, null);

            v_TableManager.CreateTable("Note", new ValueTuple<string, ADOX.DataTypeEnum, int>[]{
                ("PupilUUID", ADOX.DataTypeEnum.adVarWChar, 36),
                ("Text", ADOX.DataTypeEnum.adLongVarWChar, 511),
                ("Date", ADOX.DataTypeEnum.adVarWChar, 22),
                ("UUID", ADOX.DataTypeEnum.adVarWChar, 36)
            }, new string[]{"UUID"}, new ValueTuple<string, string, string>[]{
                ("PupilUUID", "Pupil", "PupilUUID")
            });

            v_TableManager.CreateTable("Metadata", new ValueTuple<string, ADOX.DataTypeEnum, int>[]{
                ("Version", ADOX.DataTypeEnum.adVarWChar, 16),
                ("Build", ADOX.DataTypeEnum.adVarWChar, -1),
                ("DateCreated", ADOX.DataTypeEnum.adVarWChar, 22)
            }, null, null);

            v_Catalog = null;

            OleDbConnection Connection = new OleDbConnection(CONNECTION_STRING_TEMPLATE + Location + "\\" + DATABASE_NAME);
            OleDbCommand InsertCommand = CommandBuilder.BuildInsertCommand<dynamic>(Connection, null, "Metadata", null, new string[]{"Version", "Build", "DateCreated"}, new dynamic[]{VERSION, BUILD, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.s")});
            Connection.Open();
            InsertCommand.ExecuteNonQuery();
            Connection.Close();
        }
        
        
        /// <summary>
        /// Collates a list of all the values that a property has.
        /// <br />
        /// <br />Example:
        /// <br /><code>
        /// <br />    List<string> IDs = Mgr.GetPropertyValuesFromPupils<string>("PupilID");
        /// <br /></code>
        /// </summary>
        /// <typeparam name="T">Same as the type of the Property parameter.</typeparam>
        /// <param name="Property">The property, of which the values will be collated</param>
        /// <returns></returns>
        public override List<T> CollatePropertyValuesFromPupils<T>(string Property) {
            OleDbConnection Connection = new OleDbConnection(this.ConnectionString);

            OleDbCommand SelectCommand = new OleDbCommand();
            SelectCommand.CommandType = CommandType.Text;
            SelectCommand.Connection = Connection;
            //SelectCommand.CommandText = "SELECT @Property FROM [Pupil];";
            //SelectCommand.Parameters.AddWithValue("@Property", Property);
            SelectCommand.CommandText = "SELECT * FROM [Pupil];";

            List<T> PropertyValues = new List<T>();

            int Index = Array.IndexOf(PUPIL_TABLE_COLUMN_NAMES, Property);
            if(Index == -1) return PropertyValues;

            Connection.Open();
            OleDbDataReader DataReader = SelectCommand.ExecuteReader();

            while(DataReader.Read()) if(!PropertyValues.Contains((T)DataReader[Index])) PropertyValues.Add((T)DataReader[Index]);

            Connection.Close();
            return PropertyValues;
        }

        public override bool ConfirmPupilIDIntegrity() {
            List<Pupil> Pupils = this.GetPupilsByProperties(new {});
            List<string> PupilIDs = new List<string>();
            foreach(Pupil i_Pupil in Pupils){
                if(PupilIDs.Contains(i_Pupil.PupilID)) return false;
                PupilIDs.Add(i_Pupil.PupilID);
            }
            return true;
        }
        private static readonly string[] CHECK_NESTED_MATCH_PROPERTY_BLACKLIST = { "Length", "Chars" };
        /// <summary>
        ///     Returns a List of Pupil objects that have the specified properties.
        /// <br />
        /// <br />This function accepts one parameter - an object containing the desired properties that are being searched
        /// for. Each of the provided key/value pairs will be checked against every pupil record that can be found
        /// in the database. Properties that are left out in the Pattern will be ignored,
        /// but if the Pattern specifies properties that aren't available in the Inspectee, the check will fail.
        /// <b>Nested checks aren't supported in DbPupilDataManager.</b>
        /// <br />
        /// <br />Note that this can only check for equality between the properties and can't test for a range of values/conditions.
        /// <br />Running this check on arrays might result in unexpected behaviour.
        /// <br />
        /// <br />Example:
        /// <br /><code>
        /// <br />    DbPupilDataManager Mgr = new DbPupilDataManager();
        /// <br />    List&lt;Pupil> PupilsTesco = Mgr.GetPupilsByProperties(new { Company = "Tesco", A2E = true }); 
        /// <br />    List&lt;Pupil> PupilsAsda = Mgr.GetPupilsByProperties(new { Company = "Asda", A2E = true }); 
        /// <br /></code>
        /// </summary>
        /// <param name="Properties">The pattern which will be searched for. Look up this function's definition for more information.</param>
        /// <returns>Returns a Pupil object if the provided pupil's data was found.</returns>
        public override List<Pupil> GetPupilsByProperties(object Properties) {
            List<(string, object)> StringProperties = new List<(string, object)>();
            foreach (PropertyInfo Property in Properties.GetType().GetProperties()) {
                if (CHECK_NESTED_MATCH_PROPERTY_BLACKLIST.Contains(Property.Name)) continue;
                dynamic PatternValue = Properties.GetType().GetProperty(Property.Name).GetValue(Properties, null);
                if (PatternValue == null) continue;
                StringProperties.Add((Property.Name, PatternValue));
            }

            OleDbConnection Connection = new OleDbConnection(this.ConnectionString);

            //OleDbCommand TestCommand = CommandBuilder.BuildSelectCommand<dynamic>(Connection, null, "Pupil", null, Utilities.GetPropertyNames(Properties), 


            OleDbCommand SelectCommand = new OleDbCommand();
            SelectCommand.CommandType = CommandType.Text;
            SelectCommand.Connection = Connection;
            string CommandText = "SELECT * FROM [Pupil]";

            for (int i = 0; i < StringProperties.Count; i++){
                (string, object) StringProperty = StringProperties[i];

                if(i == 0) CommandText += " WHERE ";
                else CommandText += " AND ";
                CommandText += StringProperty.Item1 + " = @Value" + i;
            }
            CommandText += ";";
            SelectCommand.CommandText = CommandText;

            for(int i = 0; i < StringProperties.Count; i++){
                (string, object) StringProperty = StringProperties[i];
                SelectCommand.Parameters.AddWithValue("@Value" + i, StringProperty.Item2);
            }

            Connection.Open();
            OleDbDataReader DataReader = SelectCommand.ExecuteReader();
            List<Pupil> Pupils = new List<Pupil>();
            while(DataReader.Read()){
                //(string, object)[] PropertyAndValue = new (string, object)[DataReader.FieldCount];
                Pupil CurrentPupil = new Pupil();
                for(int i = 0; i < DataReader.FieldCount; i++){
                    CurrentPupil.GetType().GetProperty(PUPIL_TABLE_COLUMN_NAMES[i]).SetValue(CurrentPupil, DataReader[i], null);
                }
                CurrentPupil.Notes = new List<Note>();

                OleDbCommand NoteSelectCommand = new OleDbCommand();
                NoteSelectCommand.CommandType = CommandType.Text;
                NoteSelectCommand.Connection = Connection;
                string NoteCommandText = "SELECT [Text], [Date], [UUID] FROM [Note] WHERE [PupilUUID] = @PupilUUID;";
                string[] PropertyOrder = new string[]{"Text", "Date", "UUID"};
                NoteSelectCommand.CommandText = NoteCommandText;
                NoteSelectCommand.Parameters.AddWithValue("@PupilUUID", CurrentPupil.PupilUUID);
                OleDbDataReader NoteDataReader = NoteSelectCommand.ExecuteReader();
                while(NoteDataReader.Read()){
                    Note CurrentNote = new Note();
                    for(int i = 0; i < NoteDataReader.FieldCount; i++){
                        Utilities.SetReflect<object>(CurrentNote, PropertyOrder[i], NoteDataReader[i]);
                    }
                    CurrentPupil.Notes.Add(CurrentNote);
                }
                Pupils.Add(CurrentPupil);
            }
            Connection.Close();
            return Pupils;
        }
        
        private static readonly string[] UPDATE_PUPIL_DATA_PROPERTY_BLACKLIST = new string[]{"PupilUUID", "Notes"};
        /// <summary>
        ///     Writes pupil data to the database: this can be used to update existing records or create new ones.
        /// <br />
        /// <br />Example:
        /// <br /><code>
        /// <br />    DbPupilDataManager Mgr = new DbPupilDataManager();
        /// <br />    Pupil MyPupil = Mgr.GetPupilByName("John Atkinson"); //Get pupil's info
        /// <br />    MyPupil.A2E = !MyPupil.A2E; //Toggle AbleToEnable
        /// <br />    Mgr.WritePupilData(MyPupil);//Write changes to disk
        /// <br /></code>
        /// </summary>
        /// <param name="p_Pupil">The Pupil object; the p_Pupil.Name property will be used for the containing folder's name.</param>
        public override void WritePupilData(Pupil p_Pupil) {
            OleDbConnection Connection = new OleDbConnection(this.ConnectionString);

            {

                OleDbCommand Command = new OleDbCommand();
                Command.CommandType = CommandType.Text;
                Command.Connection = Connection;

                //DbCommandBuilder CommandBuilder = DbProviderFactories.GetFactory("System.Data.OleDb").CreateCommandBuilder();

                if(this.GetPupilsByProperties(new {PupilUUID = p_Pupil.PupilUUID}).Count == 0){ //If the pupil doesn't already exist
                    Command = CommandBuilder.BuildInsertCommand<Pupil>(Connection, p_Pupil, "Pupil", new string[]{"Notes"});
                }else{
                    Command = CommandBuilder.BuildUpdateCommand<Pupil>(Connection, p_Pupil, "Pupil", UPDATE_PUPIL_DATA_PROPERTY_BLACKLIST, " WHERE [PupilUUID] = @PupilUUID");
                    Command.Parameters.AddWithValue("@PupilUUID", p_Pupil.PupilUUID);
                }
            
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();

            }

            {
                OleDbCommand SelectCommand = new OleDbCommand();
                SelectCommand.CommandType = CommandType.Text;
                SelectCommand.Connection = Connection;
                SelectCommand.CommandText = "SELECT [UUID] FROM [Note] WHERE [PupilUUID] = @PupilUUID;";
                SelectCommand.Parameters.AddWithValue("@PupilUUID", p_Pupil.PupilUUID);

                List<string> StoredNoteUUIDs = new List<string>();

                Connection.Open();

                OleDbDataReader DataReader = SelectCommand.ExecuteReader();

                while(DataReader.Read()) StoredNoteUUIDs.Add((string)DataReader[0]);

                Connection.Close();

                List<string> CurrentNoteUUIDs = new List<string>();
                Dictionary<string, Note> NoteUUIDLookup = new Dictionary<string,Note>();
                foreach(Note i_Note in p_Pupil.Notes){
                    CurrentNoteUUIDs.Add(i_Note.UUID);
                    NoteUUIDLookup.Add(i_Note.UUID, i_Note);
                }

                foreach(string NoteUUID in CurrentNoteUUIDs.Union(StoredNoteUUIDs).ToList()){
                    bool Current = CurrentNoteUUIDs.Contains(NoteUUID);
                    bool Stored = StoredNoteUUIDs.Contains(NoteUUID);
                    bool Both = Current && Stored;

                    OleDbCommand Command = new OleDbCommand();
                    Command.CommandType = CommandType.Text;
                    Command.Connection = Connection;

                    if(Both){ //Update
                        Command = CommandBuilder.BuildUpdateCommand<Note>(Connection, NoteUUIDLookup[NoteUUID], "Note", new string[]{"UUID"}, " WHERE [UUID] = @UUID");
                        Command.Parameters.AddWithValue("@UUID", NoteUUID);
                    }else if(Current){ //Insert
                        Command = CommandBuilder.BuildInsertCommand<Note>(Connection, NoteUUIDLookup[NoteUUID], "Note", new string[]{}, new string[]{"PupilUUID"}, new dynamic[]{p_Pupil.PupilUUID});
                    }else if(Stored){ //Delete
                        Command.CommandText = "DELETE FROM [Note] WHERE [UUID] = @UUID;";
                        Command.Parameters.AddWithValue("@UUID", NoteUUID);
                    }
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                }
            }
        }
        /// <summary>
        /// Deletes the data for the specified pupil from the database.
        /// <br />
        /// <br />Example:
        /// <br /><code>
        /// <br />    DbPupilDataManager Mgr = new DbPupilDataManager();
        /// <br />    Pupil MyPupil = Mgr.GetPupilsByProperties(new {PupilID = "33554432")[0]; //Get pupil object.
        /// <br />    Mgr.DeletePupilData(MyPupil);
        /// <br /></code>
        /// <br />Don't forget to update your array(s) after deleting the pupil.
        /// </summary>
        /// <param name="p_Pupil">The pupil to be deleted.</param>
        public override void DeletePupilData(Pupil p_Pupil) {
            OleDbConnection Connection = new OleDbConnection(this.ConnectionString);
            {
                OleDbCommand Command = new OleDbCommand();
                Command.CommandType = CommandType.Text;
                Command.Connection = Connection;
                Command.CommandText = "DELETE FROM [Note] WHERE [PupilUUID] = @UUID;";
                Command.Parameters.AddWithValue("@UUID", p_Pupil.PupilUUID);
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
            }
            {
                OleDbCommand Command = new OleDbCommand();
                Command.CommandType = CommandType.Text;
                Command.Connection = Connection;
                Command.CommandText = "DELETE FROM [Pupil] WHERE [PupilUUID] = @UUID;";
                Command.Parameters.AddWithValue("@UUID", p_Pupil.PupilUUID);
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
            }
        }
    }
}
