using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Episode_Names
{
    public partial class Data_Insert : Form
    {
        #region CopyPasteListener DllImports dessen Variablen

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        private const int WM_DRAWCLIPBOARD = 0x0308;
        private IntPtr _clipboardViewerNext;
        #endregion


        #region Variablen
        private bool CopyRunning;
        private bool firstClick;
        #endregion

        public Data_Insert()
        {
            Data_InsertCons();
        }

        #region Hineinschreiben von bereits geholten Daten
        public Data_Insert(List<string> data)
        {
            Data_InsertCons();
            setRichTextData(data);
        }
        #endregion

        private void Data_InsertCons()
        {
            InitializeComponent();
            setData();
        }

        private void setRichTextData(List<string> data)
        {
            
            richTextBox1.Text = string.Join("\n", (List<string>)data);
            
            richTextBox1.SelectAll();
            richTextBox1.SelectionFont = richTextBox1.Font;
            richTextBox1.SelectionLength = 0;
        }

        public string getData()
        {
            return richTextBox1.Text;
        }

        #region Gespeicherte Daten setzen
        private void setData()
        {
            CopyRunning = false;
            firstClick = true;
            TopMost = Properties.Settings.Default.Foreground;
        }
        #endregion
        

        #region Beenden durch Button "Finish"
        private void btnFinish_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion


        #region ContextMenü und Aktionen
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool noSelectedText = string.IsNullOrEmpty(richTextBox1.SelectedText);
            ausschneidenToolStripMenuItem.Enabled = !noSelectedText;
            kopierenToolStripMenuItem.Enabled = !noSelectedText;

            bool noClipboardText = string.IsNullOrEmpty(Clipboard.GetText());
            einfügenToolStripMenuItem.Enabled = !noClipboardText;
        }

        private void kopierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void einfügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void ausschneidenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        #endregion


        #region CopyPasteListener
        private void copyPasteListenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRunning = !CopyRunning;

            if (CopyRunning)
            {
                _clipboardViewerNext = SetClipboardViewer(Handle);
                lblIsRunning.Text = "Running";
            }

            else
            {
                ChangeClipboardChain(Handle, _clipboardViewerNext);
                lblIsRunning.Text = "Stopped";
            }

            
            
        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);    // Process the message 

            
            if (m.Msg == WM_DRAWCLIPBOARD)
            {

                if (CopyRunning && !firstClick)
                {
                    string temp = "";
                    if (richTextBox1.Lines.Count() != 0)
                        temp = "\n";
                    
                    richTextBox1.AppendText(temp + Clipboard.GetText());      // Clipboard text
                }
                firstClick = false;
            }
        }
        #endregion


        #region Beenden des CopyPasteListener falls er noch läuft
        private void Data_Insert_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ChangeClipboardChain(Handle, _clipboardViewerNext);
            }
            catch { }
        }

        #endregion
    }
}
