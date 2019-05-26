using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_Names.Helper
{
    class SettingHelper
    {
        internal static List<string> Formates => GetFormates();
        private static List<string> formates;
        internal static string Number = "n";
        internal static string Position = "pos";
        internal static string Directory = "dir";
        internal static char Separator = '%';
        
        private static List<string> GetFormates()
        {
            return formates ?? InitFormates();
        }

        private static List<string> InitFormates()
        {
            formates = new List<string>
            {
                Number,
                Position,
                Directory
            };
            formates.AddRange(Enumerable.Range(1, 99).Reverse().ToArray().Select(x => x.ToString()).ToList());
            return formates;
        }
    }
}
