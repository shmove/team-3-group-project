using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.PupilDataManager.DbUtils {
    public static class DefaultConnectionStringBuilder {
        public static readonly string VERSION = "0.1.7.10";
        public static readonly int BUILD = 10;
        public static string BuildConnectionString(string Location) {
            return "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + Location + "; Jet OLEDB:Engine Type=5";
        }
    }
}
