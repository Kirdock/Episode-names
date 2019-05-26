using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_Names.Helper
{
    class FileHelper : MessageHandler
    {

        internal static IEnumerable<string> FileNamesOfFolder(string path)
        {
            return IsDirectoryValid(path) ? new DirectoryInfo(path).GetFiles()
                .Where(f => (f.Attributes & FileAttributes.Hidden) == 0)
                .Select(file => Path.GetFileNameWithoutExtension(file.Name))
                .OrderBy(a => a, new StringComparator()) : Enumerable.Empty<string>();
        }

        internal static IEnumerable<string> FolderNamesOfFolder(string path)
        {
            return IsDirectoryValid(path) ? new DirectoryInfo(path).GetDirectories()
                .Where(f => (f.Attributes & FileAttributes.Hidden) == 0)
                .Select(f => f.Name).OrderBy(f => f, new StringComparator()) : Enumerable.Empty<string>();
        }

        private static bool IsDirectoryValid(string path)
        {
            bool valid = Directory.Exists(path);
            if(!valid)
            {
                FolderNotFound();
            }
            return valid;
        }
    }
}
