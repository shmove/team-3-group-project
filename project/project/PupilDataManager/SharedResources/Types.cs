using project.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
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
            public string Name {get; set;}
            public string Company {get; set;}
            public bool A2E {get; set;}
            public List<Note> Notes {get; set;}
            public List<TodoEntry> TodoList {get; set;}
            public YearGroups YearGroup {get; set;}
            public string A2EDescription {get; set;}
            public string LastAccess {get; set;}
            public bool Struggling {get; set;}
            public enum YearGroups{
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
            }
            
            public Pupil() {}
            [Obsolete("Old constructor. Please switch to the new constructor that supports the new properties.")]
            public Pupil(string p_Name, string p_PupilID, string p_Company, bool p_A2E, List<Note> p_Notes) {
                PupilUUID = System.Guid.NewGuid().ToString();
                Name = p_Name;
                A2E = p_A2E;
                Company = p_Company;
                Notes = p_Notes;
                PupilID = p_PupilID;
            }
            public Pupil(string p_Name, string p_PupilID, string p_Company, bool p_A2E, List<Note> p_Notes, List<TodoEntry> p_TodoEntries, Pupil.YearGroups p_YearGroup, string p_A2EDescription, string p_LastAccess, bool p_Struggling) {
                PupilUUID = System.Guid.NewGuid().ToString();
                Name = p_Name;
                A2E = p_A2E;
                Company = p_Company;
                Notes = p_Notes;
                PupilID = p_PupilID;
                TodoList = p_TodoEntries;
                YearGroup = p_YearGroup;
                A2EDescription = p_A2EDescription;
                LastAccess = p_LastAccess;
                Struggling = p_Struggling;
            }
            public Pupil(object Object) {}
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
    }
}
