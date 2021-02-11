using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static project.PupilDataManager.SharedResources.Types;

namespace project.Interfaces {
    interface IPupilDataManager {
        void WritePupilData(Pupil p_Pupil);
        bool ConfirmPupilIDIntegrity();
        List<Pupil> GetPupilsByProperties(object Properties);
        List<T> CollatePropertyValuesFromPupils<T>(string Property);
    }
    public abstract class BasePupilDataManager : IPupilDataManager, IInstallable{
        public BasePupilDataManager(string Location) {
            if (!this.CheckIfInstalled(Location)) this.Install(Location);
        }
        public abstract bool CheckIfInstalled(string Location);
        public abstract void Install(string Location);
        public abstract List<T> CollatePropertyValuesFromPupils<T>(string Property);
        public abstract bool ConfirmPupilIDIntegrity();
        public abstract List<Pupil> GetPupilsByProperties(object Properties);
        public abstract void WritePupilData(Pupil p_Pupil);
        public Pupil[] GetTestCases(int Count) {
            if ((Count >> 8) > 0) throw new Exception("Really?");
            Pupil[] PupilArray = new Pupil[Count];
            Random v_Random = new Random();
            for (int i = 0; i < Count; i++) PupilArray[i] = new Pupil(System.IO.Path.GetRandomFileName(), (v_Random.Next(0x00989680, 0x05f5e0ff) >> 0).ToString(), (v_Random.Next(0, 4) >> 1) > 1 ? "Tesco" : "Sainsbury's", v_Random.Next(0, 2) < 1, new List<Note>(){}, System.IO.Path.GetRandomFileName());
            return PupilArray;
        }
    }
}
