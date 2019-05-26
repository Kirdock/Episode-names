using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace Episode_Names
{
    class StringComparator : IComparer<FileInfo>, IComparer<string>
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class SafeNativeMethods
        {
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
            public static extern int StrCmpLogicalW(string psz1, string psz2);
        }

        public int Compare(FileInfo a, FileInfo b)
        {
            return SafeNativeMethods.StrCmpLogicalW(a.Name, b.Name);
        }

        public int Compare(string a, string b)
        {
            return SafeNativeMethods.StrCmpLogicalW(a, b);
        }
    }
}
