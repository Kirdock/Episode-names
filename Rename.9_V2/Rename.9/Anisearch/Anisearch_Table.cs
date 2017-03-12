using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Episode_Names.Anisearch
{
    public partial class Anisearch_Table : Form
    {
        #region Variablen
        private List<string> data;
        private string url;
        private string language;
        #endregion

        public Anisearch_Table()
        {
            InitializeComponent();
            setData();
        }

        #region Standardwerte und gespeicherte Daten setzen
        private void setData()
        {
            TopMost = Properties.Settings.Default.Foreground;
            MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width * 2, 131);
            cmbData();
        }
        #endregion

        #region Sprachen der Combobox holen und zuletzt verwendete Sprache setzen
        private void cmbData()
        {
            List<KeyValuePair<string, string>> languages = getLanguageData();
            comboBox1.DisplayMember = "Value";
            comboBox1.DataSource = languages;
            comboBox1.SelectedIndex = Properties.Settings.Default.Language;
        }
        #endregion


        #region Sprachen der Combobox setzen
        public static List<KeyValuePair<string, string>> getLanguageData()
        {
            List<KeyValuePair<string, string>> languages = new List<KeyValuePair<string, string>>();
            languages.Add(new KeyValuePair<string, string>("de", "Deutsch"));
            languages.Add(new KeyValuePair<string, string>("en", "English"));
            languages.Add(new KeyValuePair<string, string>("es", "Español"));
            languages.Add(new KeyValuePair<string, string>("fr", "Français"));
            languages.Add(new KeyValuePair<string, string>("it", "Italiano"));
            languages.Add(new KeyValuePair<string, string>("pl", "Polski"));
            languages.Add(new KeyValuePair<string, string>("ru", "Русский"));
            languages.Add(new KeyValuePair<string, string>("tr", "Türkçe"));
            languages.Add(new KeyValuePair<string, string>("ja", "日本語"));
            return languages;
        }
        #endregion


        #region Url nach Button "OK" überprüfen
        private void btnOk_Click(object sender, EventArgs e)
        {
            checkUrl();
        }
        #endregion


        #region Url überprüfen
        private void checkUrl()
        {
            string[] text = txtUrl.Text.Replace("http://", "").Replace("https://", "").Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            if (txtUrl.Text.ToUpper().Contains("ANISEARCH.") && text.Length>=3)
            {
                language = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
                string domain = "https://";
                if (language.Equals("en") || language.Equals("de"))
                {
                    domain += "anisearch." + (language.Equals("de") ? language : "com");
                }
                else
                    domain += language + ".anisearch.com";

                url = domain + "/" + text[1] + "/" + text[2] + "/episodes";
                progressBar1.Style = ProgressBarStyle.Marquee;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                ErrorMessage(new UriFormatException());
            }
        }
        #endregion


        #region Enter zum Fortfahren
        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkUrl();
            }
        }
        #endregion


        #region Episodenliste zurückgeben
        public List<string> getData()
        {
            return data;
        }
        #endregion


        #region BackgroundWorker holt Episodenliste und schließt anschließend die Form
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                getTableData();
                CloseForm();
            }
            catch (Exception e1)
            {
                ErrorMessage(e1);
            }
            finally
            {
                StopProgress();
            }
        }
        #endregion


        #region ErrorMessages ausgeben
        private void ErrorMessage(Exception exception)
        {
            MethodInvoker LabelUpdate = delegate
            {
                if (exception is FileNotFoundException)
                    Form1.MessagesOK(MessageBoxIcon.Error, "HtmlAgilityPack.dll konnte nicht gefunden werden");

                else
                    Form1.ErrorMessage(exception);
            };
            BeginInvoke(LabelUpdate);
        }
        #endregion


        #region Progressbar stoppen
        private void StopProgress(){
            MethodInvoker LabelUpdate = delegate
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
            };
            BeginInvoke(LabelUpdate);
        }
        #endregion


        #region Episodenliste holen
        private void getTableData()
        {
            WebRequest objRequest = WebRequest.Create(url);
            WebResponse objResponse = objRequest.GetResponse();
            StreamReader sr = new StreamReader(objResponse.GetResponseStream());

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(sr.ReadToEnd());
            sr.Close();
            objResponse.Close();
            
            data = new List<string>();
            HtmlNode table = doc.DocumentNode.SelectNodes("//table[@class='responsive-table episodes']//tbody")[0];
            foreach (HtmlNode row in table.SelectNodes("tr"))
            {
                string line = null;


                #region Falls es mehr anderssprachige Einträge gibt
                try {
                    line = WebUtility.HtmlDecode(row.SelectNodes("th")[0].InnerText) + "\t" +
                            WebUtility.HtmlDecode(row.SelectNodes("td")[1].SelectSingleNode("div[@lang='" + language + "']").InnerText);
                }
                catch (NullReferenceException){
                }
                #endregion


                if(line!=null)
                    data.Add(line.Trim());
            }
        }
        #endregion


        #region Schließen der Form mit DialogResult.OK
        private void CloseForm()
        {

            DialogResult = DialogResult.OK;
            MethodInvoker LabelUpdate = delegate
            {
                Close();
            };
            BeginInvoke(LabelUpdate);
        }
        #endregion


        #region Sprache beim Beenden speichern
        private void Anisearch_Table_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = comboBox1.SelectedIndex;
            Properties.Settings.Default.Save();
        }
        #endregion


        #region Anisearch-Search aufrufen
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anisearch_Search form = new Anisearch_Search();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
                txtUrl.Text = form.getUrl();
        }
        #endregion


    }
}