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
    }
}
