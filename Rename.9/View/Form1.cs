using Episode_Names.Anisearch;
using Episode_Names.Exceptions;
using Episode_Names.Helper;
using GlobalSettings;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Episode_Names
{
    public partial class Form1 : Form
    {
        private readonly HistoryHelper History = new HistoryHelper();
        private List<string> Data;
        private bool abort;

        public Form1()
        {
            InitializeComponent();
            SetData();
        }

        private void SetData()
        {
            txtPath.Text = Properties.Settings.Default.BrowseLocation;
            nbPosition.Value = Properties.Settings.Default.position;
            txtSplit.Text = Properties.Settings.Default.splitString;
            TopMost = Properties.Settings.Default.Foreground;
            txtSearch.Text = Properties.Settings.Default.SR_Search;
            CPFormat.Expanded = Properties.Settings.Default.FormatExpanded;
            nbNumber.Value = Properties.Settings.Default.startNumber;
            TxtFormat.Text = Properties.Settings.Default.formatString;

            pgBar.Value = cmbOption.SelectedIndex = 0;
            LblMessage.Text = string.Empty;
            abort = false;
            Updater.CheckUpdate(true, pgBar);
        }


        #region Auswahl zwischen vier Methoden (Rename, Insert/Delete Position, Replace) (Kommt drauf an was in der cmbBox angegeben und ob diese visible ist)
        private void Rename_Click(object sender, EventArgs e)
        {
            SetStatusMessage(string.Empty);
            if (cmbOption.Visible && cmbOption.SelectedIndex == 0)
            {
                btnRename_Click();
            }
            else
            {
                renameWithoutData_Click(false);
            }
            abort = false;
        }
        #endregion

        #region Button "Rename"-Klick. Überprüfen welche Kategorie (OnlyNumber, Anzahl der Datensätze stimmen mit Dateien im Ordner überein)
        private void btnRename_Click()
        {
            if (Data != null || TxtFormat.OnlyNumber)
            {
                try
                {
                    #region Falls nur %n im Format String ist, wird alles nach diesem Schema umbenannt
                    if (TxtFormat.OnlyNumber)
                    {
                        renameWithoutData_Click(true);
                        SetStatusMessage("Abgeschlossen!!");
                        return;
                    }
                    #endregion

                    List<FileInfo> infos = new DirectoryInfo(txtPath.Text).GetFiles().Select(f => f).Where(f => (f.Attributes & FileAttributes.Hidden) == 0).OrderBy(field => field,new StringComparator()).ToList();
                    int countFileLines = Data?.Count ?? 0;
                    StartLoadingBar(infos.Count);
                    DialogResult result = DialogResult.Yes;

                    if (infos.Count > countFileLines)
                    {
                        result = MessageHandler.MessagesYesNo(MessageBoxIcon.Exclamation, "Im Ordner befinden sich mehr Dateien als Zeilen im File-Dokument.\nVorgang trotzdem fortsetzen?");
                    }

                    else if (infos.Count < countFileLines)
                    {
                        result = MessageHandler.MessagesYesNo(MessageBoxIcon.Exclamation, "Im Ordner befinden sich weniger Dateien als Zeilen im File-Dokument.\nVorgang trotzdem fortsetzen?");
                    }

                    if (result == DialogResult.Yes)
                    {
                        RenameFiles(infos);
                        SetStatusMessage("Abgeschlossen!!");
                    }

                }
                catch (IOException)
                {
                    DialogResult result = MessageHandler.MessagesYesNo(MessageBoxIcon.Error, "Umbenennen nicht möglich, da sich schon eine Datei mit gleichen Namen im Ordner befindet.\nAlte Daten wiederherstellen?");
                    if (result == DialogResult.Yes)
                    {
                        GoBack();
                    }
                }
                StopLoadingBar();
            }
            else
            {
                MessageHandler.MessagesOK(MessageBoxIcon.Exclamation, "Es wurden keine Daten gesetzt");
            }
                 
        }

        #endregion


        #region Anpassen des Format-Strings und Umbenennen der Dateien
        private void RenameFiles(List<FileInfo> infos)
        {
            List<HistoryHelper.HistoryEntry> history = new List<HistoryHelper.HistoryEntry>();
            int max = Math.Min(infos.Count, Data.Count);
            try
            {
                for(int i = 0; i < max; i++)
                {
                    string absolutePath = Path.Combine(infos[i].DirectoryName, FormatString(Data[i], infos[i].Directory.Name) + infos[i].Extension);

                    if (infos[i].FullName != absolutePath)
                    {
                        File.Move(infos[i].FullName, absolutePath);
                        history.Add( new HistoryHelper.HistoryEntry(infos[i].FullName,absolutePath));
                    }
                }
            }
            catch (AbortException)
            {
                //  Wurde nur als Abort-Bedingung geworfen
            }
            History.Add(history);
        }
        #endregion


        #region Format-String wird angepasst
        private string FormatString(string row, string dirName)
        {
            IEnumerable<string> text = TxtFormat.Text.Split(new string[] { FormatSettings.Separator.ToString() }, StringSplitOptions.RemoveEmptyEntries);

            List<string> formates = FormatSettings.Formates;
            List<string> formatesWithoutNumeration = FormatSettings.FormatesWithoutNumeration;

            StringBuilder fullname = new StringBuilder();
            if (!TxtFormat.Text.StartsWith(FormatSettings.Separator.ToString()))
            {
                fullname.Append(text.FirstOrDefault() ?? string.Empty);
                text = text.Skip(1);
            }

            foreach (string line in text)
            {
                string format = formates
                                .Where(f => line.Length >= f.Length && line.Substring(0, f.Length) == f)
                                .OrderBy(f=>f,new StringComparator())
                                .LastOrDefault();
                if(format == null)
                {
                    for(int i = 1; i <= FormatSettings.MaxNumber.ToString().Length; i++)
                    {
                        if(line.Length >= i && int.TryParse(line.Substring(0,i), out int result) && result <= FormatSettings.MaxNumber)
                        {
                            format = result.ToString();
                        }
                    }
                }

                if (format != null)
                {
                    try
                    {
                        #region Überprüfen um was für einen Format-String Befehl es sich handelt
                        if (format == FormatSettings.Number)
                        {
                            int temp = pgBar.Value + Properties.Settings.Default.startNumber;
                            string number = NullCharacters(pgBar.Maximum - 1 + Properties.Settings.Default.startNumber, temp) + temp;
                            fullname.Append(number);
                        }
                        else if (format == FormatSettings.Position)
                        {
                            char a = txtSplit.Text == "\\t" ? '\t' : '\n';
                            fullname.Append(SplitLine(row, a, (int)nbPosition.Value));
                        }
                        else if (format == FormatSettings.Directory)
                        {
                            fullname.Append(dirName);
                        }
                        else //Nummer 1-100
                        {
                            char a = txtSplit.Text == "\\t" ? '\t' : '\n';
                            fullname.Append(SplitLine(row, a, Convert.ToInt32(format)));
                        }

                        fullname.Append(line.Substring(format.Length, line.Length - format.Length)); //Rest der nach dem %-Befehl steht. Bsp: %nabc also "abc"
                        #endregion
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //Falls eine Position im Format-String nicht existiert
                        if (!abort)
                        {
                            DialogResult? res = MessageHandler.MessagesYesNo(MessageBoxIcon.Error, $"Die Position {nbPosition.Value} mit dem Split-String: {txtSplit.Text} gibt es nicht\nVorgang fortsetzen?");

                            if (res == DialogResult.No)
                            {
                                res = MessageHandler.MessagesYesNo(MessageBoxIcon.Question, "Restore ausführen?");
                                if (res == DialogResult.Yes)
                                    GoBack();
                                throw new AbortException();
                            }
                            else
                            {
                                abort = true;
                            }
                        }
                    }
                }
                else
                {
                    fullname.Append(FormatSettings.Separator).Append(line);
                }  
            }
            return ReplaceSpecialCharacters(fullname.ToString());
        }
        #endregion

        

        #region Format-String anpassen (mit nur %n)
        private string FormatNumberString()
        {
            int temp = pgBar.Value + Properties.Settings.Default.startNumber;
            string number = NullCharacters(pgBar.Maximum - 1 + Properties.Settings.Default.startNumber, temp) + temp;
            return TxtFormat.Text.Replace(FormatSettings.Separator + FormatSettings.Number, number);
        }
        #endregion


        #region Textline wird nach Split-String gesplittet, Position wird rausgeholt und Sonderzeichen werden ersetzt
        private string SplitLine(string line, char a, int position)
        {
            string erg = a == '\n' ?
                        line.Split(txtSplit.Text.Split(new string[] { "|" }, StringSplitOptions.None), StringSplitOptions.RemoveEmptyEntries)[position - 1]
                        : line.Split(new char[] { a }, StringSplitOptions.RemoveEmptyEntries)[position - 1];
            
            return ReplaceSpecialCharacters(erg);
        }
        #endregion


        #region Sonderzeichen werden ersetzt
        private static string ReplaceSpecialCharacters(string erg)
        {
            return erg.Replace("?",   "？")
                      .Replace(" : ", "：")
                      .Replace(":",   "：")
                      .Replace("/",   " ∕ ")
                      .Replace("\\",  "＼")
                      .Replace("\"",  "''")
                      .Replace(">",   "＞")
                      .Replace("<",   "＜")
                      .Replace("*",   "＊");
        }
        #endregion

        
        private void SetStatusMessage(string text)
        {
            LblMessage.Text = text;
        }

        private void bntNumber_Click(object sender, EventArgs e)
        {
            SetStatusMessage(string.Empty);
            renameWithoutData_Click(null);
        }


        #region Zurückgeben der 0er, welche vor einer Zahl aufgrund der Anzahl der Dateien fehlen
        private string NullCharacters(int max, int current)
        {
            int result = max.ToString().Length - current.ToString().Length;
            return new string('0', result);
        }
        #endregion


        #region Button-Browse Klick
        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                InitialDirectory = txtPath.Text
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtPath.Text = dialog.FileName;
            }
            dialog.Dispose();
        }
        #endregion


        #region Button-New_Data Klick. Aufrufen der Form und anschließendes Holen der Daten
        private void insertDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Insert form = new Data_Insert();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Data = string.IsNullOrWhiteSpace(form.getData()) ? null : form.getData().Split('\n').ToList();
            }
            form.Dispose();
        }
        #endregion


        #region ButtonEdit_Data Klick. Aufrufen der Form mit den gespeicherten Daten
        private void editDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Data != null)
            {
                startData_Insert(Data);
            }
            else
            {
                MessageHandler.MessagesOK(MessageBoxIcon.Error, "Es sind keine Daten vorhanden, welche bearbeitet werden können");
            }
        }
        #endregion


        #region Starten von Data_Insert mit geholten Daten
        private void startData_Insert(IEnumerable<string> data)
        {
            Data_Insert form = new Data_Insert(data);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Data = form.getData().Split('\n').ToList();
            }
        }
        #endregion


        #region FileNamen des angegebenen Ordners holen und falls erfolgreich "Data_Insert" aufrufen
        private void getFileNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                startData_Insert(FileHelper.FileNamesOfFolder(txtPath.Text));
            }

            catch (Exception e1)
            {
                ErrorHelper.HandleException(e1);
            }
        }
        #endregion


        #region Speichern der Daten beim Beenden
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.position = nbPosition.Value;
            Properties.Settings.Default.BrowseLocation = txtPath.Text;
            Properties.Settings.Default.SR_Search = txtSearch.Text;
            Properties.Settings.Default.FormatExpanded = CPFormat.Expanded;
            Properties.Settings.Default.formatString = TxtFormat.Text;
            if (!cmbOption.Visible)
            {
                Properties.Settings.Default.SR_Replace = txtSplit.Text;
            }
            else
            {
                if(cmbOption.SelectedIndex == 0)
                    Properties.Settings.Default.splitString = txtSplit.Text;
            }

            Properties.Settings.Default.Save();
        }
        #endregion



        #region Anisearch Menüpunkt
        private void anisearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anisearch_Table form = new Anisearch_Table();
            if (form.ShowDialog() == DialogResult.OK){
                startData_Insert(form.getData());
            }
            form.Dispose();
        }
        #endregion


        #region Einstellungen
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Settings form = new Form_Settings();
            switch (form.ShowDialog())
            {
                case DialogResult.Retry:
                    SetData();
                    break;

                case DialogResult.Yes:
                    TopMost = Properties.Settings.Default.Foreground;
                    break;
            }
            form.Dispose();
        }

        #endregion


        #region Search&Replace Klick
        private void searchReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (searchReplaceToolStripMenuItem.Text)
            {
                case "Umbenennen":
                    setVisibility(false);
                    break;

                default:
                    setVisibility(true);
                    break;
            }
        }
        #endregion


        #region Visibilität von Controls setzen (Trigger ist Klick auf Search&Replace
        private void setVisibility(bool v){
            int x = 477;
            string text = "Suchen && Ersetzen";

            txtSearch.Visible = v;
            lblReplace.Visible = v;
            lblSearch.Visible = v;
            cmbOption.Visible = !v;
            
            
            //falls auf true gesetzt wird
            if (cmbOption.Visible)
            {
                cmbOption_SelectedIndexChanged();
            }
            else
            {
                nbPosition.Visible = !v;
                lblPosition.Visible = !v;
                x = 529;
                text = "Umbenennen";
                if(cmbOption.SelectedIndex == 0)
                    Properties.Settings.Default.splitString = txtSplit.Text;
                string splitText = Properties.Settings.Default.SR_Replace;
                txtSplit.Text = splitText;
                txtSplit.Width = 160;

            }
            txtSplit.Location = new System.Drawing.Point(x, txtSplit.Location.Y);
            searchReplaceToolStripMenuItem.Text = text;
        }
        #endregion


        #region Insert-, Delete-Position, Number Klick
        private void renameWithoutData_Click(bool? numberClicked)
        {
            /* numberClicked hat drei bzw. vier Zustände:
                   null:                        btnNumber clicked
                   true:                        Der einzige Befehl im Format-String ist %n
                   false &&  cmbOption.Visible: Insert- oder Delete-Position clicked
                   false && !cmbOption.Visible: Search & Rename
            */
            

            List<FileInfo> infos = new List<FileInfo>( new DirectoryInfo(txtPath.Text).GetFiles().Select(f => f).Where(f => (f.Attributes & FileAttributes.Hidden) == 0));
            infos.Sort(new StringComparator());
            

            pgBar.Maximum = infos.Count;
            List<HistoryHelper.HistoryEntry> history = new List<HistoryHelper.HistoryEntry>();
            try
            {
                foreach (FileInfo info in infos)
                {
                    #region Anpassen des Format-Strings nach "Number", "Only %n" "Delete", "Insert" oder "Replace"
                    string absolutePath = info.DirectoryName + "\\";
                    string filename = info.Name.Replace(info.Extension, string.Empty);

                    #region Button "Number" wurde geklickt
                    if (numberClicked == null)
                    {
                        int temp = pgBar.Value + Properties.Settings.Default.startNumber;
                        string number = NullCharacters(pgBar.Maximum - 1 + Properties.Settings.Default.startNumber, temp);
                        number += temp;
                        absolutePath += number;
                    }
                    #endregion

                    #region Im FormatString ist der einzige Befehl %n
                    else if (numberClicked == true)
                    {
                        absolutePath += ReplaceSpecialCharacters(FormatNumberString());
                    }
                    #endregion

                    #region Insert- oder Delete-Position wurde geklickt
                    else if (cmbOption.Visible)
                    {
                        

                        switch (cmbOption.SelectedIndex)
                        {
                            case 1:
                                absolutePath += DeletePositions(filename);
                                break;

                            case 2:
                                txtSplit.Text = ReplaceSpecialCharacters(txtSplit.Text);
                                absolutePath += InsertPosition(filename);
                                break;
                        }
                    }
                    #endregion

                    #region Search & Rename wurde geklickt
                    else
                    {
                        absolutePath += filename.Replace(ReplaceSpecialCharacters(txtSearch.Text), ReplaceSpecialCharacters(txtSplit.Text));
                    }
                    absolutePath += info.Extension;
                    #endregion

                    #endregion

                    if (info.FullName != absolutePath)
                    {
                        File.Move(info.FullName, absolutePath);
                        history.Add(new HistoryHelper.HistoryEntry(info.FullName, absolutePath));
                    }

                    pgBar.Value++;

                }
                LblMessage.Text = "Abgeschlossen!!";
            }
            catch (IOException)
            {
                DialogResult? result = MessageHandler.MessagesYesNo(MessageBoxIcon.Error, "Umbenennen nicht möglich, da sich schon eine Datei mit gleichen Namen im Ordner befindet.\nRestore durchführen?");

                if (result == DialogResult.Yes)
                    GoBack();
            }
            catch (AbortException)
            {
                //Abbruchbedingung
            }
            catch (Exception ex)
            {
                ErrorHelper.HandleException(ex);
            }
            finally
            {
                pgBar.Value = pgBar.Maximum;
            }
            History.Add(history);
        }
        #endregion


        #region Position an angegebener Stelle einfügen
        private string InsertPosition(string filename)
        {
            return filename.Insert((int)(nbPosition.Value - 1), txtSplit.Text);
        }
        #endregion


        #region Angegebene Positionen löschen
        private string DeletePositions(string filename)
        {
            HashSet<int> positions = getPositions();
            var builder = new StringBuilder(filename);
            
            foreach (int position in positions.OrderByDescending(o => o))
            {
                try
                {
                    builder.Remove((position - 1), 1); //Position != Index
                }
                catch (ArgumentOutOfRangeException)
                {
                    if (!abort)
                    {
                        DialogResult? res = MessageHandler.MessagesYesNo(MessageBoxIcon.Error, $"Die Position {position} konnte nicht in jedem File gefunden werden\nVorgang fortsetzen?");

                        if (res == DialogResult.No)
                        {
                            res = MessageHandler.MessagesYesNo(MessageBoxIcon.Question, "Restore ausführen?");
                            if (res == DialogResult.Yes)
                                GoBack();
                            throw new AbortException();
                        }
                        else
                            abort = true;
                    }
                }
            }

            return builder.ToString();
        }
        #endregion


        #region Zu löschende Positionen holen
        private HashSet<int> getPositions()
        {
            HashSet<int> positions = new HashSet<int>(); //HashSet wegen Sortierung und keine Duplikate
            IEnumerable<string> stpositions = txtSplit.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);


            foreach (string position in stpositions)
            {
                List<string> arrpos = position.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if(int.TryParse(arrpos[0].Trim(), out int start))
                {
                    if (arrpos.Count == 1)
                    {
                        positions.Add(start);
                    }
                    else if (arrpos.Count == 2 && int.TryParse(arrpos[1].Trim(), out int secondNumber) && secondNumber >= start)
                    {
                        int count = secondNumber - start;
                        foreach (int pos in Enumerable.Range(start, count + 1))
                        {
                            positions.Add(pos);
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            
            return positions;
        }
        #endregion


        #region Ändern des Tooltips durch Ändernung der Option auf "Delete Position", "Insert Position" und "Rename" oder "Replace"
        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOption_SelectedIndexChanged();
        }
        private void cmbOption_SelectedIndexChanged()
        {
            bool visibility = true;
            int width = 113;
            string tooltipText = "Gibt an wonach jede Zeile in \"Data\" aufgeteilt werden soll\nBefehle werden mit | getrennt";
            string splitText = "";

            switch (cmbOption.SelectedIndex)
            {
                case 0:
                    splitText = Properties.Settings.Default.splitString;
                    break;

                case 1:
                    visibility = false;
                    width = 212;
                    tooltipText = cmbOption.Visible ? "Positionen werden mit \";\" getrennt\nEs kann von-bis angegeben werden\nBeispiel: \"1;5;7 - 10\" " : "";
                    break;

            }

            nbPosition.Visible = visibility;
            lblPosition.Visible = visibility;
            txtSplit.Text = splitText;
            txtSplit.Width = width;
            toolTip1.SetToolTip(txtSplit, tooltipText);
        }
        #endregion


        #region Split-String speichern, wenn Fokus verlässt
        private void txtSplit_Leave(object sender, EventArgs e)
        {
            if (cmbOption.Visible && cmbOption.SelectedIndex == 0)
            {
                Properties.Settings.Default.splitString = txtSplit.Text;
            }
        }
        #endregion

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updater.CheckUpdate(false, pgBar);
        }

        private void ordnernamenHolenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                startData_Insert(FileHelper.FolderNamesOfFolder(txtPath.Text));
            }

            catch (Exception e1)
            {
                ErrorHelper.HandleException(e1);
            }
        }

        #region History

        private void GoBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void GoForward_Click(object sender, EventArgs e)
        {
            GoForward();
        }

        private void GoForward()
        {
            if (History.Forward(out List<HistoryHelper.HistoryEntry> result))
            {
                HistoryWorker.RunWorkerAsync(result);
            }
        }

        private void GoBack()
        {
            if (History.Back(out List<HistoryHelper.HistoryEntry> result))
            {
                HistoryWorker.RunWorkerAsync(result);
            }
        }

        private void HistoryWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            object[] arguments = (object[])e.Argument;
            List<HistoryHelper.HistoryEntry> history = arguments[0] as List<HistoryHelper.HistoryEntry>;
            bool forceRename = (bool)arguments[1];
            StartLoadingBar(history.Count);
            if (forceRename || history.All(item => File.Exists(item.OldValue)))
            {
                RenameByHistory(history);
            }
            else
            {
                DialogResult result = MessageHandler.MessagesYesNo(MessageBoxIcon.Warning, "Es konnten nicht alle Dateien gefunden werden.\nTrotzdem ausführen?");
                if (result == DialogResult.OK)
                {
                    RenameByHistory(history);
                }
            }


            void RenameByHistory(List<HistoryHelper.HistoryEntry> historyEntry)
            {
                foreach (HistoryHelper.HistoryEntry entry in historyEntry)
                {
                    if (File.Exists(entry.OldValue))
                    {
                        File.Move(entry.OldValue, entry.NewValue);
                    }
                    HistoryWorker.ReportProgress(0);
                }
            }
        }

        private void HistoryWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            UpdateLoadingBar();
        }

        private void HistoryWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                if(e.Error is IOException)
                {
                    MessageHandler.MessagesOK(MessageBoxIcon.Error, "Wiederherstellen nicht möglich, da eine Datei den alten Namen einer anderen Datei besitzt.");
                }
                else
                {
                    ErrorHelper.HandleException(e.Error);
                }
            }
            else
            {
                SetStatusMessage("Wiederhergestellt!");
            }
            StopLoadingBar();
        }
        #endregion

        #region ProgressBar
        private void StartLoadingBar(int max)
        {
            pgBar.BeginInvoke(new MethodInvoker(() =>
            {
                pgBar.Style = ProgressBarStyle.Continuous;
                pgBar.Value = 0;
                pgBar.Maximum = max;
            }));
        }

        private void StartLoadingBar()
        {
            pgBar.BeginInvoke(new MethodInvoker(() =>
            {
                pgBar.Style = ProgressBarStyle.Marquee;
            }));
        }

        private void UpdateLoadingBar()
        {
            if (pgBar.Value < pgBar.Maximum)
            {
                pgBar.Value++;
            }
        }

        private void StopLoadingBar()
        {
            pgBar.Value = pgBar.Maximum = 0;
            pgBar.Style = ProgressBarStyle.Continuous;
        }
        #endregion

        private void BtnResetFormat_Click(object sender, EventArgs e)
        {
        }
    }
}
