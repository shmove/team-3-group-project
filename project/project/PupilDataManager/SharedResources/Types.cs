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
            public string ImgRef {get; set;}
            public Pupil() {}
            public Pupil(string p_Name, string p_PupilID, string p_Company, bool p_A2E, List<Note> p_Notes, string p_ImgRef) {
                PupilUUID = System.Guid.NewGuid().ToString();
                Name = p_Name;
                A2E = p_A2E;
                Company = p_Company;
                Notes = p_Notes;
                ImgRef = p_ImgRef;
                PupilID = p_PupilID;
            }
            public Pupil(object Object) {}
        }
        [Obsolete("Old notes version, don't use this.")]
        public class Notes {
            public string Date {get; set;}
            public List<string> NotesList {get; set;}
            public Notes(string p_Date, List<string> p_NotesList) {
                Date = p_Date;
                NotesList = p_NotesList;
            }
        }
        public class Note {
            public string Date {get; set;}
            public string Text {get; set;}
            public Note(string p_Date, string p_Text){
                this.Date = p_Date;
                this.Text = p_Text;
            }
        }
    }
}
