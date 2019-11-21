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
            nbNumber.Value = Properties.Settings.Default.startNumber;
            chbForeground.Checked = Properties.Settings.Default.Foreground;
            TopMost = Properties.Settings.Default.Foreground;
            txtFormat.Text = Properties.Settings.Default.formatString;
            btnSave.Enabled = valueChanged = false;
        }


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ViewHelper.TabControl_DrawItem(sender, e);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                MessageHandler.MessagesOK(MessageBoxIcon.Information, "Gespeichert");
            }
        }

        private bool saveData()
        {
            bool success;
            if (success = FormatStringValid())
            {

                btnSave.Enabled = valueChanged = false;

                Properties.Settings.Default.startNumber = (int)nbNumber.Value;
                Properties.Settings.Default.Foreground = TopMost = chbForeground.Checked;
                Properties.Settings.Default.formatString = txtFormat.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageHandler.MessagesOK(MessageBoxIcon.Error, "Ungültiger Format-String!");
            }

            return success;

        }

        /// <summary>
        /// Checks if the entered format string is valid
        /// </summary>
        /// <returns>true or false, depending if the format is valid</returns>
        private bool FormatStringValid()
        {
            IEnumerable<string> text = txtFormat.Text.Split(new string[] { SettingHelper.Separator.ToString() }, StringSplitOptions.RemoveEmptyEntries);
            text = txtFormat.Text.StartsWith(SettingHelper.Separator.ToString()) ? text : text.Skip(1);

            IEnumerable<string> formates = SettingHelper.Formates;

            bool withoutNumber = text.Any(item => formates.Where(format => format != SettingHelper.Number).Any(format => item.Length >= format.Length && item.Substring(0, format.Length) == format));
            bool onlyNumber = text.Any(item => item.Length >= SettingHelper.Number.Length && item.Substring(0, SettingHelper.Number.Length) == SettingHelper.Number);
            

            Properties.Settings.Default.OnlyNumber = onlyNumber && !withoutNumber;
            Properties.Settings.Default.Save();
            return withoutNumber || onlyNumber;
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
                    if (!saveData())
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        valueChanged = false;
                        DialogResult = DialogResult.Yes;
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                DialogResult = DialogResult.Yes;
                Close();
            }
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
