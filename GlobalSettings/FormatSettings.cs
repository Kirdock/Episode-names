using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalSettings
{
    public class FormatSettings
    {
        private static List<string> formates;
        public static readonly int MaxNumber = 100;
        public static string Number = "n";
        public static string Position = "pos";
        public static string Directory = "dir";
        public static readonly char Separator = '%';
        public static List<string> FormatesWithoutNumeration = new List<string>
        {
                Number,
                Position,
                Directory
        };
        public static List<string> Formates = InitFormates();

        private static List<string> InitFormates()
        {
            formates = new List<string>(FormatesWithoutNumeration);

            formates.AddRange(Enumerable.Range(1, MaxNumber - 1).Reverse().Select(x => x.ToString()).ToList());
            return formates;
        }
    }
}
