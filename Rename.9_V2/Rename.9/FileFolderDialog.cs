using System;
using System.IO;
using System.Windows.Forms;

namespace Episode_Names
{
    public class FileFolderDialog : CommonDialog
    {
        private OpenFileDialog dialog = new OpenFileDialog();


        public OpenFileDialog Dialog
        {
            get { return dialog; }
            set { dialog = value; }
        }

        public DialogResult ShowDialog(string path)
        {

            return ShowDialog(null, path);
        }

        public DialogResult ShowDialog(IWin32Window owner, string path)
        {
            // Set validate names to false otherwise windows will not let you select "Folder Selection."
            dialog.ValidateNames = false;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;
            dialog.Multiselect = false;
            dialog.InitialDirectory = path;

            dialog.FileName = "Folder";
            


            

            if (owner == null)
                return dialog.ShowDialog();
            else
                return dialog.ShowDialog(owner);
        }

        /// <summary>
        // Helper property. Parses FilePath into either folder path (if Folder Selection. is set)
        // or returns file path
        /// </summary>
        public string SelectedPath()
        {
            return Path.GetDirectoryName(dialog.FileName);
        }

        /// <summary>
        /// When multiple files are selected returns them as semi-colon seprated string
        /// </summary>
       

        public override void Reset()
        {
            dialog.Reset();
        }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            return true;
        }
    }
}
