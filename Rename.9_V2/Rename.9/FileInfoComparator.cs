using System.Collections.Generic;
using System.IO;

namespace Episode_Names
{
    class FileInfoComparator : IComparer<FileInfo>
    {
        public int Compare(FileInfo f1, FileInfo f2)
        {
            return (string.Compare(f1.Name, f2.Name));
        }
    }
}
