using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using project.Interfaces;
using static project.PupilDataManager.SharedResources.Types;

namespace project {
    /// <summary>
    /// This is version 0.2.0.5 of the pupil file manager.                                                                     <br />
    ///                                                                                                                        <br />
    /// This version supports:                                                                                                 <br />
    ///                                                                                                                        <br />
    ///  -  Getting a pupil's info with their name                                                                             <br />
    ///  -  Getting a pupil's info from an arbitrary location                                                                  <br />
    ///  -  Getting a list of all registered pupils                                                                            <br />
    ///  -  Getting a list of pupils with certain properties (unstable)                                                        <br />
    ///  -  Write / update pupil data to disk                                                                                  <br />
    ///  -  Generate test cases (doesn't contain notes)                                                                        <br />
    ///  -  Having multiple pupils with the same name.                                                                         <br />
    ///  -  Collating property values from pupils.                                                                             <br />
    ///  -  Has a basic installation process.                                                                                  <br />
    ///                                                                                                                        <br />
    /// This version doesn't support:                                                                                          <br />
    ///                                                                                                                        <br />
    ///  -  Storing the pupils' images in the same directory as their info file                                                <br />
    ///  -  Having any possible APPLICABLE_DIRECTORY_NAME_PATTERN.                                                             <br />
    ///  -  The search for pupils by their properties can still be extremely unreliable.                                       <br />
    /// 
    /// </summary>
    class PupilFileManager : BasePupilDataManager{
        public static readonly string VERSION = "0.2.1.6";
        public static readonly int BUILD = 6;
        private static readonly string APPLICABLE_DIRECTORY_NAME_PATTERN = "Pupil_*"; //Please don't change this.
        private static readonly string PUPIL_INFO_FILE_NAME = "PupilInfo.json";
        private static readonly string DEFAULT_LOCATION = Environment.GetEnvironmentVariable("LocalAppData") + "\\PupilRecordsProgram\\Files";
        public string RootFolderPath;
        /// <summary>
        ///     The constructor.
        /// <br />
        /// <br />Example:
        /// <br /><code>
        /// <br />    PupilFileManager Mgr = new PupilFileManager(@"C:\dev\PupilFiles\");
        /// <br /></code>
        /// </summary>
        /// <param name="p_RootFolderPath">There must be a backslash ("\") at the end of the path name.</param>
        public PupilFileManager(string p_RootFolderPath) : base(p_RootFolderPath){
            RootFolderPath = p_RootFolderPath;
        }

        public PupilFileManager() : base(DEFAULT_LOCATION) {
            RootFolderPath = DEFAULT_LOCATION;
            //RootFolderPath = Environment.GetEnvironmentVariable("LocalAppData") + "\\PupilRecordsProgram\\Assets\\Files";

        }
        public override bool CheckIfInstalled(string Location) {
            this.RootFolderPath = Location; //I don't like this at all...
            if (Directory.Exists(Location)) return true;
            new WarningException("Folder wasn't found; the PupilFileManager will be installed.");
            return false;
        }

        public override void Install(string Location) {
            Directory.CreateDirectory(Location);
            this.GenerateTestCases(5);
        }

        /// <summary>
        /// Reads a pupil's info from an arbitrary file location, and returns a Pupil object.                                  <br />
        /// <b>The file must be formatted correctly.</b>                                                                       <br />
        ///                                                                                                                    <br />
        /// Example:                                                                                                           <br />
        /// <code>                                                                                                             <br />
        ///     PupilFileManager Mgr = new PupilFileManager("");                                                               <br />
        ///     Pupil MyPupil = Mgr.DeserializePupilFile(@"C:\dev\SomePupilData.json");                                        <br />
        /// </code>
        ///     
        /// </summary>
        /// <param name="FilePath">The file path of the pupil info data.</param>
        /// <returns>A Pupil object populated with the data from the file.</returns>
        private Pupil DeserializePupilFile(string FilePath) {
            string Serialized = System.IO.File.ReadAllText(FilePath).Replace("\r\n", "").Replace("\r", "").Replace("\t", "");
            return JsonConvert.DeserializeObject<Pupil>(Serialized);
        }
        private string[] GetDirectoryNameArray() {
            return Directory.GetDirectories(RootFolderPath, APPLICABLE_DIRECTORY_NAME_PATTERN, SearchOption.TopDirectoryOnly);
        }
        /// <summary>
        ///     Returns a List of Pupil objects that have the specified properties.
        /// <br />
        /// <br />This function accepts one parameter - an object containing the desired properties that are being searched
        /// for. Each of the provided key/value pairs will be checked against every pupil info file that can be found
        /// in the directory specified in the constructor. Properties that are left out in the Pattern will be ignored,
        /// but if the Pattern specifies properties that aren't available in the Inspectee, the check will fail.
        /// If a property has another object (class instance?) as its value, it won't be tested for equality/identity;
        /// instead, its properties will also be iterated over. This allows for nested checks.
        /// <br />
        /// <br />Note that this can only check for equality between the properties and can't test for a range of values/conditions.
        /// <br />Running this check on arrays might result in unexpected behaviour.
        /// <br />
        /// <br />Example:
        /// <br /><code>
        /// <br />    PupilFileManager Mgr = new PupilFileManager(@"C:\dev\PupilFiles\");
        /// <br />    List&lt;Pupil> PupilsTesco = Mgr.GetPupilsByProperties(new { Company = "Tesco", A2E = true }); //This would include the file below.
        /// <br />    List&lt;Pupil> PupilsAsda = Mgr.GetPupilsByProperties(new { Company = "Asda", A2E = true }); //This wouldn't include the file below.
        /// <br /></code>
        /// <br />
        /// <br />File C:\dev\PupilFiles\Pupil_John Atkinson\PupilInfo.json
        /// <br /><code>
        /// <br />{
        /// <br />· · "Name": "John Atkinson",
        /// <br />· · "Company": "Tesco",
        /// <br />· · "A2E": true,
        /// <br />· · "Notes": [
        /// <br />· · · · {
        /// <br />· · · · · · "Date": "2021-01-17",
        /// <br />· · · · · · "NotesList": [
        /// <br />· · · · · · · · "This is a note."
        /// <br />· · · · · · ]
        /// <br />· · · · }
        /// <br />· · ],
        /// <br />· · "ImgRef": "./Image.jpg"
        /// <br />}
        /// <br /></code>
        /// </summary>
        /// <param name="Properties">The pattern which will be searched for. Look up this function's definition for more information.</param>
        /// <returns>Returns a Pupil object if the provided pupil's data was found.</returns>
        public override List<Pupil> GetPupilsByProperties(object Properties) {
            string[] Directories = GetDirectoryNameArray();
            string[] SearchableFileNames = new string[Directories.Length];
            for(int i = 0, Length = Directories.Length; i < Length; i++) {
                SearchableFileNames[i] = Directories[i] + "\\" + PUPIL_INFO_FILE_NAME;
            }
            List<Pupil> Pupils = new List<Pupil>();
            for(int i = 0, Length = Directories.Length; i < Length; i++) {
                Pupil CurrentPupil = DeserializePupilFile(SearchableFileNames[i]);
                if (CheckNestedMatch(CurrentPupil, Properties)) Pupils.Add(CurrentPupil);
            }
            return Pupils;
        }

        
        private static string[] CHECK_NESTED_MATCH_PROPERTY_BLACKLIST = { "Length", "Chars" };
        private bool CheckNestedMatch(object Inspectee, object Pattern) { //This is a mess, I'm sorry...
            if (Inspectee == null && Pattern == null) return true;
            if (Inspectee == null || Pattern == null) return false;
            PropertyInfo[] Properties = Pattern.GetType().GetProperties();
            int Length = 0;
            foreach (PropertyInfo Property in Properties) if (!CHECK_NESTED_MATCH_PROPERTY_BLACKLIST.Contains(Property.Name)) Length++;
            if (Length == 0) {
                return Object.Equals(Inspectee, Pattern);
            }
            foreach (PropertyInfo Property in Pattern.GetType().GetProperties()) {
                if (CHECK_NESTED_MATCH_PROPERTY_BLACKLIST.Contains(Property.Name)) continue;

                if (Inspectee.GetType().GetProperty(Property.Name) == null) return false; //As this was iterated over, it implies that the Pattern definitely has this property.

                if (Inspectee.GetType().GetProperty(Property.Name).GetIndexParameters().Length != 0 ||
                   Pattern.GetType().GetProperty(Property.Name).GetIndexParameters().Length != 0) continue;

                dynamic InspecteeValue = Inspectee.GetType().GetProperty(Property.Name)?.GetValue(Inspectee, null);
                dynamic PatternValue = Pattern.GetType().GetProperty(Property.Name).GetValue(Pattern, null);
                if (PatternValue == null) continue;

                /*if (InspecteeValue == PatternValue) {
                    return true;
                } else */
                {
                    if (PatternValue is object) {
                        if (InspecteeValue is object) {
                            if (!CheckNestedMatch(InspecteeValue, PatternValue)) return false;
                        } else return false;
                    }
                }
            }
            return true;
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
            string[] Directories = GetDirectoryNameArray();
            List<T> PropertyValuesList = new List<T>();
            for (int i = 0, Length = Directories.Length; i < Length; i++) {
                string FileName = Directories[i] + "\\" + PUPIL_INFO_FILE_NAME;
                Pupil CurrentPupil = DeserializePupilFile(FileName);
                PropertyValuesList.Add((T)CurrentPupil.GetType().GetProperty(Property).GetValue(CurrentPupil, null));
            }
            return PropertyValuesList;
        }

        /// <summary>
        ///     Writes pupil data to the disk: this can be used to update existing records or create new ones.
        /// <br />
        /// <br />Example:
        /// <br /><code>
        /// <br />    PupilFileManager Mgr = new PupilFileManager(@"C:\dev\PupilFiles\");
        /// <br />    Pupil MyPupil = Mgr.GetPupilByName("John Atkinson"); //Get pupil's info
        /// <br />    MyPupil.A2E = !MyPupil.A2E; //Toggle AbleToEnable
        /// <br />    Mgr.WritePupilData(MyPupil);//Write changes to disk
        /// <br /></code>
        /// </summary>
        /// <param name="p_Pupil">The Pupil object; the p_Pupil.Name property will be used for the containing folder's name.</param>
        public override void WritePupilData(Pupil p_Pupil) {
            string Name = p_Pupil.Name;
            string FolderName = APPLICABLE_DIRECTORY_NAME_PATTERN.Remove(APPLICABLE_DIRECTORY_NAME_PATTERN.Length - 1) + Name + "_" + p_Pupil.PupilUUID;
            System.IO.Directory.CreateDirectory(RootFolderPath + "\\" + FolderName);
            FileStream v_FileStream = File.Create(RootFolderPath + "\\" + FolderName + "\\" + PUPIL_INFO_FILE_NAME);
            string Serialized = JsonConvert.SerializeObject(p_Pupil);
            byte[] ByteData = Encoding.UTF8.GetBytes(Serialized);
            v_FileStream.Write(ByteData, 0, ByteData.Length);
            v_FileStream.Close();
        }

        public override bool ConfirmPupilIDIntegrity() {
            string[] Directories = GetDirectoryNameArray();
            string[] SearchableFileNames = new string[Directories.Length];
            for (int i = 0, Length = Directories.Length; i < Length; i++) {
                SearchableFileNames[i] = Directories[i] + "\\" + PUPIL_INFO_FILE_NAME;
            }
            HashSet<string> IDs = new HashSet<string>();
            for (int i = 0, Length = Directories.Length; i < Length; i++) {
                Pupil CurrentPupil = DeserializePupilFile(SearchableFileNames[i]);
                if (!IDs.Contains(CurrentPupil.PupilID)) IDs.Add(CurrentPupil.PupilID);
                else return false;
            }
            return true;
        }

        #region Testing
        ///<summary>
        /// This is used for testing purposes.
        ///</summary>

        public void GenerateTestCases(int Count) {
            if ((Count >> 8) > 0) throw new Exception("Really?");
            Random v_Random = new Random();
            for (int i = 0; i < Count; i++) {
                string Name = System.IO.Path.GetRandomFileName();
                Pupil v_Pupil = new Pupil(Name, (v_Random.Next(0x00989680, 0x05f5e0ff) >> 0).ToString(), (v_Random.Next(0, 4) >> 1) > 1 ? "Tesco" : "Sainsbury's", v_Random.Next(0, 2) < 1, new List<Note>(){}, System.IO.Path.GetRandomFileName());
                string FolderName = APPLICABLE_DIRECTORY_NAME_PATTERN.Remove(APPLICABLE_DIRECTORY_NAME_PATTERN.Length - 1) + Name + "_" + v_Pupil.PupilUUID;
                System.IO.Directory.CreateDirectory(RootFolderPath + "\\" +  FolderName);
                FileStream v_FileStream = File.Create(RootFolderPath + "\\" + FolderName + "\\" + PUPIL_INFO_FILE_NAME);
                string Serialized = JsonConvert.SerializeObject(v_Pupil);
                byte[] ByteData = Encoding.UTF8.GetBytes(Serialized);
                v_FileStream.Write(ByteData, 0, ByteData.Length);
                v_FileStream.Close();
            }
        }
        #endregion



    }

    
}