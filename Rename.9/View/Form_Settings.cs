using Episode_Names.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Episode_Names
{
    public partial class Form_Settings : Form
    {
        private bool valueChanged = false;

        public Form_Settings()
        {
            InitializeComponent();
            SetData();
        }

        private void SetData()
        {
            chbForeground.Checked = Properties.Settings.Default.Foreground;
            TopMost = Properties.Settings.Default.Foreground;
            btnSave.Enabled = valueChanged = false;
        }


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ViewHelper.TabControl_DrawItem(sender, e);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageHandler.MessagesOK(MessageBoxIcon.Information, "Gespeichert");
        }

        private void SaveData()
        {
            btnSave.Enabled = valueChanged = false;
            Properties.Settings.Default.Foreground = TopMost = chbForeground.Checked;
            Properties.Settings.Default.Save();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = valueChanged = true;
        }

        private void Form_Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (valueChanged)
            {
                DialogResult result = MessageHandler.MessagesYesNo(MessageBoxIcon.Warning, "Die Einstellungen wurden nicht gespeichert!\n Jetzt speichern?");
                if (result == DialogResult.Yes)
                {
                    SaveData();
                    valueChanged = false;
                    DialogResult = DialogResult.Yes;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveData();
            DialogResult = DialogResult.Yes;
            Close();
        }


        private void btnFacSet_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageHandler.MessagesYesNo(MessageBoxIcon.Exclamation, "Sind Sie sicher, dass Sie die Einstellungen zurücksetzen möchten?");
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                SetData();
                DialogResult = DialogResult.Retry;
            }
        }

        private void GitHubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Kirdock/Episode-names/releases");
        }
    }
}
