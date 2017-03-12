using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Episode_Names.Anisearch
{
    public partial class Anisearch_Search : Form
    {
        #region Variablen
        private string url;
        private string selectedLanguage;
        #endregion

        public Anisearch_Search()
        {
            InitializeComponent();
            setData();
        }

        #region Standardwerte und gespeicherte Daten setzen
        private void setData()
        {
            cmbData();
            TopMost = Properties.Settings.Default.Foreground;
        }
        #endregion


        #region Sprachen der Combobox holen und zuletzt verwendete Sprache setzen
        private void cmbData()
        {
            List<KeyValuePair<string, string>> languages =new List<KeyValuePair<string, string>>();
            languages.Add(new KeyValuePair<string, string>("com", "None"));
            languages.AddRange(Anisearch_Table.getLanguageData());
            
            cmbLang.DisplayMember = "Value";
            cmbLang.DataSource = languages;
            cmbLang.SelectedIndex = Properties.Settings.Default.SecondLanguage;

        }
        #endregion


        #region mit Enter Suche starten
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchText();
            }
        }
        #endregion


        #region Text suchen / Backgroundworker starten
        private void searchText()
        {
            pgBar.Style = ProgressBarStyle.Marquee;
            selectedLanguage = ((KeyValuePair<string, string>)cmbLang.SelectedItem).Key;
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion


        #region Ergebnisse suchen
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string domain = "http://www.";
            if (new List<string> { "de", "en", "com" }.Contains(selectedLanguage)){
                domain += "anisearch." + (selectedLanguage.Equals("de") ? selectedLanguage : "com");
            }
            else
                domain += selectedLanguage + ".anisearch.com";


            string url = domain + "/anime/index/?char=all&text=" + txtSearch.Text.Replace(" ", "%20") + "&q=true";
            try
            {
                WebRequest objRequest = WebRequest.Create(url);
                WebResponse objResponse = objRequest.GetResponse();
                if (objResponse.ResponseUri.ToString().Contains("/index/"))
                {
                    StreamReader sr = new StreamReader(objResponse.GetResponseStream());


                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(sr.ReadToEnd());
                    sr.Close();
                    objResponse.Close();


                    HtmlNode table = doc.DocumentNode.SelectNodes("//table//tbody")[0];
                    List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {
                        string text = WebUtility.HtmlDecode(row.SelectNodes("th")[0].SelectNodes("a")[0].InnerText);
                        //string text = (row.SelectNodes("th//div") != null) ? WebUtility.HtmlDecode(row.SelectNodes("th//div")[0].InnerText) : WebUtility.HtmlDecode(row.SelectNodes("th")[0].SelectNodes("a")[0].InnerText);
                        string nurl = WebUtility.HtmlDecode(row.SelectNodes("th")[0].SelectNodes("a[@href]")[0].Attributes["href"].Value);
                        data.Add(new KeyValuePair<string, string>(domain + "/" + nurl, text));
                    }
                    add(data);
                }
                else
                {
                    this.url = objResponse.ResponseUri.ToString();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception exception)
            {
                ErrorMessage(exception);
            }
            finally
            {
                stopProgress();
            }

            
        }
        #endregion


        #region Ergebnisse ausgeben
        private void add(List<KeyValuePair<string, string>> data)
        {
            MethodInvoker LabelUpdate = delegate
            {
                listResult.DisplayMember = "Value";
                listResult.DataSource = data;
            };
            BeginInvoke(LabelUpdate);
        }
        #endregion


        #region Progressbar stoppen
        private void stopProgress()
        {
            MethodInvoker LabelUpdate = delegate
            {
                pgBar.Style = ProgressBarStyle.Blocks;
            };
            BeginInvoke(LabelUpdate);
        }
        #endregion


        #region ErrorMessages ausgeben
        private void ErrorMessage(Exception exception)
        {
            MethodInvoker LabelUpdate = delegate
            {
                Form1.ErrorMessage(exception);
            };
            BeginInvoke(LabelUpdate);
        }
        #endregion


        #region Beenden durch Doppelklick auf Item
        private void listResult_DoubleClick(object sender, EventArgs e)
        {
            if (listResult.SelectedItem != null)
            {
                url = ((KeyValuePair<string, string>)listResult.SelectedItem).Key;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        #endregion


        #region Sprache beim Beenden speichern
        private void Anisearch_Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SecondLanguage = cmbLang.SelectedIndex;
            Properties.Settings.Default.Save();
        }
        #endregion


        #region Auch mit Rechtsklick Items markieren
        private void listResult_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listResult.IndexFromPoint(e.Location);
                listResult.SelectedIndex = index;
            }
        }
        #endregion


        #region Link von Item im Browser öffnen
        private void openLinkInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listResult.SelectedIndex != -1)
            {
                Process.Start(((KeyValuePair<string, string>)listResult.SelectedItem).Key);
            }
        }
        #endregion


        #region Ausgewählte URL zurückgeben
        public string getUrl()
        {
            return url;
        }
        #endregion


    }
}
