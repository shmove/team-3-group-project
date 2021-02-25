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
        public class Note {
            public string Date {get; set;}
            public string Text {get; set;}
            private string m_UUID;
            public string UUID {
                get {
                    return m_UUID;
                }
                set {
                    if (m_UUID == null) m_UUID = value;
                    else throw new FieldAccessException("Tried re-setting the UUID of a note.");
                }
            }
            public Note(string p_Text){
                this.Date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.s");
                this.Text = p_Text;
                this.UUID = System.Guid.NewGuid().ToString();
            }
            public Note(string p_Date, string p_Text){
                this.Date = p_Date;
                this.Text = p_Text;
                this.UUID = System.Guid.NewGuid().ToString();
            }
            public Note(string p_Date, string p_Text, string p_UUID){
                this.Date = p_Date;
                this.Text = p_Text;
                this.UUID = p_UUID;
            }
            public Note(){
                
            }
        }
    }
}
