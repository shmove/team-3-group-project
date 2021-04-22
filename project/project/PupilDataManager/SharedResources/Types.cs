using project.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace project.PupilDataManager.SharedResources {
    public class Types {
        public class Pupil {
            private string m_PupilUUID;
            public string PupilUUID {
                get {
                    return m_PupilUUID;
                }
                set {
                    if (m_PupilUUID == null) m_PupilUUID = value;
                    else throw new FieldAccessException("Tried re-setting the UUID of a pupil.");
                }
            }
            public string PupilID {get; set;}
            public string Forename {get; set;}
            public string Surname {get; set;}
            public string Name {
                get{
                    return this.Forename + " " + this.Surname;
                }
            }
            public string Company {get; set;}
            public bool A2E {get; set;}
            public List<Note> Notes {get; set;}
            public List<TodoEntry> TodoList {get; set;}
            public int YearGroup {get; set;}
            public string A2EDescription {get; set;}
            public string LastAccess {get; set;}
            public bool Struggling {get; set;}
            /*public enum YearGroups{
                [StringValue("S1")]
                S1 = 1,
                [StringValue("S2")]
                S2 = 2,
                [StringValue("S3")]
                S3 = 3,
                [StringValue("S4")]
                S4 = 4,
                [StringValue("S5")]
                S5 = 5,
                [StringValue("S6")]
                S6 = 6,
                [StringValue("College1")]
                College1 = 7,
                [StringValue("College2")]
                College2 = 8,
                [StringValue("Uni1")]
                Uni1 = 9,
                [StringValue("Uni2")]
                Uni2 = 10,
                [StringValue("Uni3")]
                Uni3 = 11,
                [StringValue("Uni4")]
                Uni4 = 12
            }*/
            
            public Pupil() {}
            [Obsolete("Old constructor. Please switch to the new constructor that supports the new properties.")]
            public Pupil(string p_Name, string p_PupilID, string p_Company, bool p_A2E, List<Note> p_Notes) {
                PupilUUID = System.Guid.NewGuid().ToString();
                Forename = p_Name;
                Surname = p_Name;
                A2E = p_A2E;
                Company = p_Company;
                Notes = p_Notes;
                PupilID = p_PupilID;
            }
            public Pupil(string p_Forename, string p_Surname, string p_PupilID, string p_Company, bool p_A2E, string p_A2EDescription, bool p_Struggling, int p_YearGroup, string p_LastAccess, List<Note> p_Notes = null, List<TodoEntry> p_TodoEntries = null) {
                PupilUUID = System.Guid.NewGuid().ToString();
                Forename = p_Forename;
                Surname = p_Surname;
                A2E = p_A2E;
                Company = p_Company;
                Notes = p_Notes ?? new List<Note>();
                PupilID = p_PupilID;
                TodoList = p_TodoEntries ?? new List<TodoEntry>();
                YearGroup = p_YearGroup;
                A2EDescription = p_A2EDescription;
                LastAccess = p_LastAccess;
                Struggling = p_Struggling;
            }
            public Pupil(object Object) {}
            public static string GetYearGroupString(int Year){
                int Last2Digits = (Year + 1) % 100;
                return Year.ToString() + "-" + Last2Digits.ToString("00");
            }
            public static int? GetYearGroupInt(string Year){
                try{
                    return Int32.Parse(Year.Split('-')[0]);
                }catch{
                    return null;
                }
            }
        }
        public interface IListable{
            string Date {get; set;}
            string Text {get; set;}
            string UUID {get; set;}
        }
        public abstract class BaseListable : IListable{
            public string Date{get; set;}
            public string Text{get; set;}
            protected string m_UUID;
            public string UUID{
                get {
                    return m_UUID;
                }
                set {
                    if (m_UUID == null) m_UUID = value;
                    else throw new FieldAccessException("Tried re-setting the UUID of a note.");
                }
            }
            public BaseListable(string p_Text) : this(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.s"), p_Text, System.Guid.NewGuid().ToString()){}
            public BaseListable(string p_Date, string p_Text) : this(p_Date, p_Text, System.Guid.NewGuid().ToString()){}
            public BaseListable(string p_Date, string p_Text, string p_UUID){
                this.Date = p_Date;
                this.Text = p_Text;
                this.UUID = p_UUID;
            }
            public BaseListable(){}
        }
        public class Note : BaseListable {
            public Note(string p_Text) : base(p_Text) {}
            public Note(string p_Date, string p_Text) : base(p_Date, p_Text) {}
            public Note(string p_Date, string p_Text, string p_UUID) : base(p_Date, p_Text, p_UUID) {}
            public Note(){}
        }
        public class TodoEntry : BaseListable{
            public TodoEntry(string p_Text) : base(p_Text) {}
            public TodoEntry(string p_Date, string p_Text) : base(p_Date, p_Text) {}
            public TodoEntry(string p_Date, string p_Text, string p_UUID) : base(p_Date, p_Text, p_UUID) {}
            public TodoEntry(){}
        }

        public class DbUser{
            public string Username {get; set;}
            private string m_UserUUID;
            public string UserUUID {
                get {
                    return m_UserUUID;
                }
                set {
                    if (m_UserUUID == null) m_UserUUID = value;
                    else throw new FieldAccessException("Tried re-setting the UUID of a pupil.");
                }
            }
            public bool IsAuthenticated {get; private set;}
            public DbUser(string Username, string UserUUID = null){
                this.UserUUID = UserUUID ?? System.Guid.NewGuid().ToString();
                this.Username = Username;
            }
            public static DbUser GetUserFromDatabase(OleDbConnection Connection, string Username){
                //Yeah, yeah, the username isn't the primary key...
                OleDbCommand SelectCommand = new OleDbCommand();
                SelectCommand.CommandType = CommandType.Text;
                SelectCommand.Connection = Connection;
                string CommandText = "SELECT [Username], [UserUUID] FROM [User] WHERE [Username] = @Username";
                SelectCommand.Parameters.AddWithValue("@Username", Username);
                SelectCommand.CommandText = CommandText;
                Connection.Open();
                OleDbDataReader DataReader = SelectCommand.ExecuteReader();
                bool Exists = DataReader.Read();
                if(!Exists) return null;
                DbUser User = new DbUser((string)DataReader[0], (string)DataReader[1]);
                Connection.Close();
                return User;
            }
            public void SaveUser(OleDbConnection Connection, string Password){
                OleDbCommand Command = new OleDbCommand();
                Command.CommandType = CommandType.Text;
                Command.Connection = Connection;
                Command.CommandText = "INSERT INTO [User] ([UserUUID], [Username], [PasswordSHA256]) VALUES(@UserUUID, @Username, @PasswordSHA256);";
                Command.Parameters.AddWithValue("@UserUUID", this.UserUUID);
                Command.Parameters.AddWithValue("@Username", this.Username);
                Command.Parameters.AddWithValue("@PasswordSHA256", DbUser.sha256_hash(Password));
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
            }
            public bool Authenticate(OleDbConnection Connection, string Password){
                OleDbCommand SelectCommand = new OleDbCommand();
                SelectCommand.CommandType = CommandType.Text;
                SelectCommand.Connection = Connection;
                string CommandText = "SELECT * FROM [User] WHERE [UserUUID] = '" + this.UserUUID + "' AND [PasswordSHA256] = '" + DbUser.sha256_hash(Password) + "';";
                //The line above poses no threat to SQL injection, because both of the concatenations are generated by the program itself. 
                SelectCommand.CommandText = CommandText;
                Connection.Open();
                OleDbDataReader DataReader = SelectCommand.ExecuteReader();
                bool Success = DataReader.Read();
                this.IsAuthenticated = Success;
                Connection.Close();
                return Success;
            }
            public void SetPassword(OleDbConnection Connection, string Password){
                OleDbCommand Command = new OleDbCommand();
                Command.CommandType = CommandType.Text;
                Command.Connection = Connection;
                Command.CommandText = "UPDATE [User] SET [PasswordSHA256] = @PasswordSHA256 WHERE [UserUUID] = @UserUUID;";
                Command.Parameters.AddWithValue("@UserUUID", this.UserUUID);
                Command.Parameters.AddWithValue("@PasswordSHA256", DbUser.sha256_hash(Password));
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
            }
            public void GetAccessTo(OleDbConnection Connection, Pupil p_Pupil){
                OleDbCommand Command = new OleDbCommand();
                Command.CommandType = CommandType.Text;
                Command.Connection = Connection;
                Command.CommandText = "INSERT INTO [UserPupilAccess] ([FPupilUUID], [FUserUUID]) VALUES(@PupilUUID, @UserUUID);";
                Command.Parameters.AddWithValue("@PupilUUID", p_Pupil.PupilUUID);
                Command.Parameters.AddWithValue("@UserUUID", this.UserUUID);
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
            }

            public void RevokeAccessTo(OleDbConnection Connection, Pupil p_Pupil){
                OleDbCommand Command = new OleDbCommand();
                Command.CommandType = CommandType.Text;
                Command.Connection = Connection;
                Command.CommandText = "DELETE FROM [UserPupilAccess] WHERE [FPupilUUID] = @PupilUUID AND [FUserUUID] = @UserUUID;";
                Command.Parameters.AddWithValue("@PupilUUID", p_Pupil.PupilUUID);
                Command.Parameters.AddWithValue("@UserUUID", this.UserUUID);
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
            }

            public bool HasAccessTo(OleDbConnection Connection, Pupil p_Pupil){
                OleDbCommand SelectCommand = new OleDbCommand();
                SelectCommand.CommandType = CommandType.Text;
                SelectCommand.Connection = Connection;
                string CommandText = "SELECT * FROM [UserPupilAccess] WHERE [FUserUUID] = '" + this.UserUUID + "' AND [FPupilUUID] = '" + p_Pupil.PupilUUID + "';";
                //The line above poses no threat to SQL injection, because both of the concatenations are generated by the program itself. 
                SelectCommand.CommandText = CommandText;
                Connection.Open();
                OleDbDataReader DataReader = SelectCommand.ExecuteReader();
                bool Result = DataReader.Read();
                Connection.Close();
                return Result;
            }
            private static String sha256_hash(String value) { // https://stackoverflow.com/a/17001289
              StringBuilder Sb = new StringBuilder();

              using (SHA256 hash = SHA256Managed.Create()) {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                  Sb.Append(b.ToString("x2"));
              }

              return Sb.ToString();
            }
        }
    }
}
