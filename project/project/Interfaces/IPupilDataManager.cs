using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static project.PupilDataManager.SharedResources.Types;
using System.Drawing;
using System.IO;

namespace project.Interfaces {
    interface IPupilDataManager {
        void WritePupilData(Pupil p_Pupil);
        void DeletePupilData(Pupil p_Pupil);
        bool ConfirmPupilIDIntegrity();
        List<Pupil> GetPupilsByProperties(object Properties);
        List<T> CollatePropertyValuesFromPupils<T>(string Property);
        void SavePupilImage(Pupil p_Pupil, Image PupilImage);
        Image GetPupilImage(Pupil v_Pupil);
    }
    public abstract class BasePupilDataManager : IPupilDataManager, IInstallable{
        public static readonly string PUPIL_IMAGE_LOCATION = Environment.GetEnvironmentVariable("LocalAppData") + "\\PupilRecordsProgram\\PupilImages";
        public static readonly string DEFAULT_PUPIL_IMAGE = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAMCAIAAADQ/GvKAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA9SURBVChTjYxBDgAgCMP4/6dxZAsCkcRenB1gvqDCCjLDklbEWMn6J++CFkSmAnJ5kw+oFtw0+NhYi4b7AdBYyzVvFnVtAAAAAElFTkSuQmCC";
        public static readonly string IMAGE_FORMAT = "png";
        public BasePupilDataManager(string Location) {
            if (!this.CheckIfInstalled(Location)) this.Install(Location);
        }
        public abstract bool CheckIfInstalled(string Location);
        public abstract void Install(string Location);
        public abstract List<T> CollatePropertyValuesFromPupils<T>(string Property);
        public abstract bool ConfirmPupilIDIntegrity();
        public abstract List<Pupil> GetPupilsByProperties(object Properties);
        public abstract void WritePupilData(Pupil p_Pupil);
        public abstract void DeletePupilData(Pupil p_Pupil);
        public Pupil[] GetTestCases(int Count) {
            if ((Count >> 8) > 0) throw new Exception("Really?");
            Pupil[] PupilArray = new Pupil[Count];
            Random v_Random = new Random();
            for (int i = 0; i < Count; i++) PupilArray[i] = new Pupil(System.IO.Path.GetRandomFileName(), (v_Random.Next(0x00989680, 0x05f5e0ff) >> 0).ToString(), (v_Random.Next(0, 4) >> 1) > 1 ? "Tesco" : "Sainsbury's", v_Random.Next(0, 2) < 1, new List<Note>(){});
            return PupilArray;
        }
        public void SavePupilImage(Pupil p_Pupil, Image PupilImage){
            PupilImage.Save(PUPIL_IMAGE_LOCATION + "\\" + p_Pupil.PupilUUID + "." + IMAGE_FORMAT);
        }
        public Image GetPupilImage(Pupil p_Pupil){
            if(File.Exists(PUPIL_IMAGE_LOCATION + "\\" + p_Pupil.PupilUUID + "." + IMAGE_FORMAT)){
                return Image.FromFile(PUPIL_IMAGE_LOCATION + "\\" + p_Pupil.PupilUUID + "." + IMAGE_FORMAT);
            } else{
                byte[] ImageBytes = Convert.FromBase64String(DEFAULT_PUPIL_IMAGE);
                Image DefaultImage;
                MemoryStream v_MemoryStream = new MemoryStream(ImageBytes);
                DefaultImage = Image.FromStream(v_MemoryStream);
                return DefaultImage;
            }
        }
    }
}
