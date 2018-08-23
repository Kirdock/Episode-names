using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Episode_Names.Anisearch
{
    public partial class Anisearch_Table : Form
    {
        private List<string> data;
        private readonly string tvdbDomain = "https://www.thetvdb.com";
        private readonly string aniDBDomain = "https://anidb.net/perl-bin/";

        public Anisearch_Table()
        {
            InitializeComponent();
            setData();
        }

        #region Standardwerte und gespeicherte Daten setzen
        private void setData()
        {
            TopMost = Properties.Settings.Default.Foreground;
            cmbWebsite.SelectedIndex = Properties.Settings.Default.SelectedWebsite;
            setCmbLanguages();

        }
        #endregion

        
        private void setCmbLanguages()
        {
            cmbLanguageEpisodes.DataSource = cmbWebsite.SelectedIndex == 0 ? getEnglish() : getLanguagesWithJapanese();
            cmbLanguageEpisodes.DisplayMember = "Value";
            cmbLanguageEpisodes.ValueMember = "Key";


            List<KeyValuePair<string, string>> languages = new List<KeyValuePair<string, string>>();
            if (cmbWebsite.SelectedIndex == 0)
            {
                languages = getEnglish();
            }

            else if (cmbWebsite.SelectedIndex == 1)
            {
                languages.Add(new KeyValuePair<string, string>("com", "None"));
            }
            
            else
            {
                languages.AddRange(getLanguagesWithJapanese());
            }
            cmbLanguageSearch.DataSource = languages;
            cmbLanguageSearch.DisplayMember = "Value";
            cmbLanguageSearch.ValueMember = "Key";

            cmbLanguageSearch.SelectedIndex = Properties.Settings.Default.SecondLanguage;
            cmbLanguageEpisodes.SelectedIndex = Properties.Settings.Default.Language;
            
        }

        private void addGerman(List<KeyValuePair<string, string>> languages)
        {
            languages.Add(new KeyValuePair<string, string>("de", "Deutsch"));
        }

        private void addEnglish(List<KeyValuePair<string, string>> languages)
        {
            languages.Add(new KeyValuePair<string, string>("en", "English"));
        }

        private List<KeyValuePair<string, string>> getEnglish()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            addEnglish(list);
            return list;
        }

        private void addJapanese(List<KeyValuePair<string, string>> languages)
        {
            languages.Add(new KeyValuePair<string, string>("ja", "日本語"));
        }

        private List<KeyValuePair<string, string>> getLanguageData()
        {
            List<KeyValuePair<string, string>> languages = new List<KeyValuePair<string, string>>();
            addGerman(languages);
            addEnglish(languages);
            return languages;
        }

        private List<KeyValuePair<string, string>> getLanguagesWithJapanese()
        {
            List<KeyValuePair<string, string>> languages = getLanguageData();
            languages.Add(new KeyValuePair<string, string>("ja", "日本語"));
            return languages;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            bool valid = false;
            string language = ((KeyValuePair<string, string>)cmbLanguageEpisodes.SelectedItem).Key;
            if (cmbWebsite.SelectedIndex == 1 && (valid = checkUrlAnisearch())) //Anisearch
            {
                StartProgressBar();
                string url = txtUrl.Text;

                new Thread(() =>
                {
                    try
                    {
                        getEpisodeList(url, language);
                        CloseForm();
                    }
                    catch (Exception e1)
                    {
                        ErrorMessage(e1);
                    }
                }).Start();
            }
            else if(cmbWebsite.SelectedIndex == 2 && (valid = checkUrlTVDB()))
            {
                StartProgressBar();
                string url = ((KeyValuePair<string, string>) cmbSeasons.SelectedItem).Key;

                new Thread(() =>
                {
                    try
                    {
                        getEpisodeListTVDB(url, language);
                        CloseForm();
                    }
                    catch (Exception e1)
                    {
                        ErrorMessage(e1);
                    }

                }).Start();
            }
            else if(valid = checkUrlAniDB())
            {
                StartProgressBar();
                string url = txtUrl.Text;

                new Thread(() =>
                {
                    try
                    {
                        getEpisodeListAniDB(url);
                        CloseForm();
                    }
                    catch (Exception e1)
                    {
                        ErrorMessage(e1);
                    }

                }).Start();
            }

            
            if (!valid)
            {
                ErrorMessage(new UriFormatException());
            }
        }

        private void getEpisodeListTVDB(string url, string language)
        {
            
            language = language == "com" ? "en" : language;

            data = new List<string>();
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);

            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[@id='translations']//tbody"))
            {
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    string line = null;
                    try
                    {
                        StringBuilder builder = new StringBuilder();

                        builder.Append(WebUtility.HtmlDecode(row.SelectNodes("td")[0].SelectSingleNode("a").InnerText).Trim()).Append("\t");

                        HtmlNode episodeName = row.SelectNodes("td/a")[1].SelectSingleNode($"span[@data-language='{language}']");

                        line = builder.ToString();
                        if (episodeName != null)
                        {
                            builder.Append(WebUtility.HtmlDecode(episodeName.InnerText).Trim());
                        }

                        line = builder.ToString();
                    }
                    catch (NullReferenceException)
                    {
                    }


                    if (line != null)
                    {
                        data.Add(line.Trim());
                    }
                }
            }
        }

        private void getEpisodeListAniDB(string url)
        {

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            

            data = new List<string>();

            foreach (HtmlNode row in doc.DocumentNode.SelectSingleNode("//table[@id='eplist']//tbody").SelectNodes("tr"))
            {
                string line = null;
                try
                {
                    StringBuilder builder = new StringBuilder();
                    var list = row.SelectNodes("td");
                    for (int i = 0; i < list.Count-1; i++)
                    {
                        builder.Append(WebUtility.HtmlDecode(list[i].InnerText).Trim()).Append("\t");
                    }
                    builder.Remove(builder.Length - 3, 2);
                    line = builder.ToString();

                    
                }
                catch (NullReferenceException)
                {
                }


                if (line != null)
                {
                    data.Add(line.Trim());
                }
            }
        }

        private string getDomain()
        {
            string language = ((KeyValuePair<string,string>) cmbLanguageSearch.SelectedItem).Key;
            return "https://anisearch." + (language.Equals("de") ? language : "com");
        }

        private string getDomainEpisodes()
        {
            string language = ((KeyValuePair<string, string>)cmbLanguageEpisodes.SelectedItem).Key;
            return "https://anisearch." + (language.Equals("de") ? language : "com");
        }


        private bool checkUrlAnisearch()
        {
            bool valid = false;
            string[] text = txtUrl.Text.Replace("http://", "").Replace("https://", "").Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            if (txtUrl.Text.ToUpper().Contains("ANISEARCH.") && text.Length>=3)
            {
                valid = true;
                txtUrl.Text = getDomainEpisodes() + "/" + text[1] + "/" + text[2] + "/episodes";
            }
            return valid;
        }


        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(null, null);
            }
        }


        #region Episodenliste zurückgeben
        public List<string> getData()
        {
            return data;
        }
        #endregion


        private void ErrorMessage(Exception exception)
        {
            MethodInvoker LabelUpdate = delegate
            {
                StopProgressBar();
                if (exception is FileNotFoundException)
                    Form1.MessagesOK(MessageBoxIcon.Error, "HtmlAgilityPack.dll konnte nicht gefunden werden");

                else
                    Form1.ErrorMessage(exception);
            };
            BeginInvoke(LabelUpdate);
        }


        private void StopProgressBar(){
            pgLoading.GetCurrentParent().Invoke(new MethodInvoker(() =>
            {
                pgLoading.Style = ProgressBarStyle.Blocks;
            }));

            MethodInvoker invoker = delegate
            {
                setEnabled(true);
            };
            BeginInvoke(invoker);
            
        }


        private void getEpisodeList(string url, string language)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            language = language == "com" ? "en" : language;
            
            data = new List<string>();
            HtmlNode table = doc.DocumentNode.SelectNodes("//table[@class='responsive-table episodes']//tbody")[0];
            foreach (HtmlNode row in table.SelectNodes("tr"))
            {
                string line = null;


                #region Falls es mehr anderssprachige Einträge gibt
                try {
                    line = WebUtility.HtmlDecode(row.SelectNodes("th")[0].InnerText) + "\t" +
                            WebUtility.HtmlDecode(row.SelectNodes($"td[@data-title='{(language.Equals("de") ? "Titel" : "Title") }']")[0].SelectSingleNode($"div[@lang='{language}']").InnerText);
                }
                catch (NullReferenceException){
                }
                #endregion


                if (line != null)
                {
                    data.Add(line.Trim());
                }
            }
        }


        #region Schließen der Form mit DialogResult.OK
        private void CloseForm()
        {
            StopProgressBar();
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
            Properties.Settings.Default.Language = cmbLanguageEpisodes.SelectedIndex;
            Properties.Settings.Default.SelectedWebsite = cmbWebsite.SelectedIndex;
            Properties.Settings.Default.SecondLanguage = cmbLanguageSearch.SelectedIndex;
            Properties.Settings.Default.Save();
        }
        #endregion


        private void StartProgressBar()
        {
            pgLoading.Style = ProgressBarStyle.Marquee;
            setEnabled(false);
        }

        private void setEnabled(bool status)
        {
            ControlBox = btnCheckURL.Enabled =  cmbLanguageSearch.Enabled = cmbLanguageEpisodes.Enabled = cmbWebsite.Enabled = cmbSeasons.Enabled = btnOk.Enabled = listResult.Enabled = txtSearch.Enabled = status;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StartProgressBar();
                
                string searchText = txtSearch.Text;
                string domain = getDomain();
                switch (cmbWebsite.SelectedIndex)
                {
                    case 0: //aniDB
                        new Thread(() =>
                        {
                            try
                            {
                                searchTextAniDB(searchText);
                            }
                            catch (Exception exception)
                            {
                                ErrorMessage(exception);
                            }
                            StopProgressBar();
                        }).Start();
                        break;

                    case 1: //Anisearch
                        new Thread(() =>
                        {
                            try
                            {
                                searchTextAnisearch(getSearchUrlAnisearch(searchText, domain), domain);
                            }
                            catch (Exception exception)
                            {
                                ErrorMessage(exception);
                            }
                            StopProgressBar();
                        }).Start();
                        break;

                    case 2: //TVDB

                        string language = cmbLanguageSearch.SelectedIndex == 0 ? "de" : ((KeyValuePair<string, string>)cmbLanguageSearch.SelectedItem).Key;
                        new Thread(() =>
                        {
                            try
                            {
                                searchTextTVDB(searchText, language);
                            }
                            catch (Exception exception)
                            {
                                ErrorMessage(exception);
                            }
                            StopProgressBar();
                        }).Start();
                        break;

                }
                
            }
        }

        private string adjustSearchTextTVDB(string text)
        {
            return text.Replace("/", "%2F");
        }

        private void searchTextAniDB(string searchText)
        {
            Uri ur = new Uri($@"https://anidb.net/perl-bin/animedb.pl?adb.search={adjustSearchTextTVDB(searchText)}&show=animelist&do.search=search");
            List<KeyValuePair<string, string>> resultUrl = new List<KeyValuePair<string, string>>();

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(ur.AbsoluteUri);

            HtmlNode table = doc.DocumentNode.SelectNodes("//table[@id= 'animelist']//tbody")[0];
            foreach (HtmlNode row in table.SelectNodes("tr"))
            {
                string text = WebUtility.HtmlDecode(row.SelectSingleNode("td[@data-label='Title']//a").InnerText);
                string nurl = WebUtility.HtmlDecode(row.SelectSingleNode("td//a[@href]").Attributes["href"].Value);
                resultUrl.Add(new KeyValuePair<string, string>(aniDBDomain + nurl, text));
            }
            setReceivedUrls(resultUrl);
        }

        private void searchTextTVDB(string searchText, string language) //Thread
        {
            Uri ur = new Uri($@"{tvdbDomain}/search?q={adjustSearchTextTVDB(searchText)}&l={language}");

            List<KeyValuePair<string, string>> resultUrl = new List<KeyValuePair<string, string>>();

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(ur.AbsoluteUri);


            HtmlNode table = doc.DocumentNode.SelectNodes("//table//tbody")[0];

            foreach (HtmlNode row in table.SelectNodes("tr"))
            {
                string text = WebUtility.HtmlDecode(row.SelectSingleNode("td//a").InnerText);
                string nurl = WebUtility.HtmlDecode(row.SelectSingleNode("td//a[@href]").Attributes["href"].Value);
                resultUrl.Add(new KeyValuePair<string, string>(tvdbDomain + nurl, text));
            }
            setReceivedUrls(resultUrl);
        }



        private void searchTextAnisearch(string url, string domain) //Thread
        {
            WebRequest objRequest = WebRequest.Create(url);
            WebResponse objResponse = objRequest.GetResponse();
            if (objResponse.ResponseUri.ToString().Contains("/index/"))
            {
                List<KeyValuePair<string, string>> resultUrl = new List<KeyValuePair<string, string>>();

                getHtmlDocument(out HtmlAgilityPack.HtmlDocument doc, objResponse);
                        

                HtmlNode table = doc.DocumentNode.SelectNodes("//table//tbody")[0];
                        
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    string text = WebUtility.HtmlDecode(row.SelectNodes("th")[0].SelectNodes("a")[0].InnerText);
                    string nurl = WebUtility.HtmlDecode(row.SelectNodes("th")[0].SelectNodes("a[@href]")[0].Attributes["href"].Value);
                    resultUrl.Add(new KeyValuePair<string, string>(domain + "/" + nurl, text));
                }
                setReceivedUrls(resultUrl);
            }
            else
            {
                setUrl(objResponse.ResponseUri.ToString());
            }
        }

        private void setUrl(string url)
        {
            txtUrl.Invoke(new MethodInvoker(() =>
            {
                txtUrl.Text = url;
            }));
        }

        private void setReceivedUrls(List<KeyValuePair<string, string>> result)
        {
            listResult.Invoke(new MethodInvoker(() =>
            {
                listResult.DataSource = null;
                listResult.DataSource = result;
                listResult.DisplayMember = "Value";
                listResult.ValueMember = "Key";
            }));
        }

        private void getHtmlDocument(out HtmlAgilityPack.HtmlDocument doc, WebResponse objResponse)
        {
            StreamReader sr = new StreamReader(objResponse.GetResponseStream());
            doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(sr.ReadToEnd());
            sr.Close();
            objResponse.Close();
        }

        private string getSearchUrlAnisearch(string searchText,string domain)
        {
            return domain + "/anime/index/?char=all&text=" + searchText.Replace(" ", "%20") + "&q=true&view=2";
        }

        private void listResult_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                listResult.SelectedIndex = listResult.IndexFromPoint(e.Location);
            }
        }

        private void linkImBrowserÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listResult.SelectedIndex != -1)
            {
                Process.Start(((KeyValuePair<string, string>)listResult.SelectedItem).Key);
            }
        }

        private void listResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listResult.SelectedIndex != -1)
            {
                string url = ((KeyValuePair<string,string>)listResult.SelectedItem).Key;
                if (url.StartsWith("[") && url.EndsWith("]"))
                {
                    url = url.Substring(1, url.Length - 2);
                }
                if (cmbWebsite.SelectedIndex == 2) //TVDB
                {
                    StartProgressBar();
                    new Thread(() =>
                    {
                        getSeasons(url);
                        StopProgressBar();
                    }).Start();
                }

                txtUrl.Text = url;
            }
        }

        private void getSeasons(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);

            HtmlNode table = doc.DocumentNode.SelectSingleNode("//ul[@class= 'list-group list-group-condensed']");
            List<KeyValuePair<string, string>> resultUrl = new List<KeyValuePair<string, string>>();

            foreach (HtmlNode row in table.SelectNodes("li[@class= 'list-group-item']"))
            {
                string text = WebUtility.HtmlDecode(row.SelectSingleNode("h4/a").InnerText).Trim();
                string nurl = WebUtility.HtmlDecode(row.SelectSingleNode("h4/a[@href]").Attributes["href"].Value);
                resultUrl.Add(new KeyValuePair<string, string>(tvdbDomain + nurl, text));
            }
            setSeasons(resultUrl);
        }

        private void setSeasons(object data)
        {
            cmbSeasons.Invoke(new MethodInvoker(() =>
            {
                cmbSeasons.DataSource = null;
                cmbSeasons.DataSource = data;
                cmbSeasons.DisplayMember = "Value";
                cmbSeasons.ValueMember = "Key";
            }));
        }

        private void cmbWebsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            listResult.DataSource = null;
            lblSeason.Visible = cmbSeasons.Visible = cmbWebsite.SelectedIndex == 2;
            setCmbLanguages();
        }

        private void btnCheckURL_Click(object sender, EventArgs e)
        {
            StartProgressBar();
            bool valid = cmbWebsite.SelectedIndex == 1 && checkUrlAnisearch() || cmbWebsite.SelectedIndex == 0 && checkUrlAniDB();
            
            if(cmbWebsite.SelectedIndex == 2 && (valid = checkUrlTVDB())) {
                string url = txtUrl.Text;
                new Thread(() =>
                {
                    getSeasons(url);
                    StopProgressBar();
                }).Start();
            }
            else
            {
                StopProgressBar();
            }

            if (!valid)
            {
                ErrorMessage(new UriFormatException());
            }
        }

        private bool checkUrlTVDB()
        {
            bool valid = false;
            string url = txtUrl.Text;
            string startText = "https://www.thetvdb.com/series/";
            if (url.StartsWith(startText))
            {
                string search = url.Replace(startText, string.Empty);

                if(search.IndexOf("/") != -1)
                {
                    search = search.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0];

                }
                HtmlWeb htmlWeb = new HtmlWeb();
                HttpStatusCode lastStatusCode = HttpStatusCode.OK;

                htmlWeb.PostResponse = (request, response) =>
                {
                    if (response != null)
                    {
                        lastStatusCode = response.StatusCode;
                    }
                };
                htmlWeb.Load(url);
                if(lastStatusCode == HttpStatusCode.OK)
                {
                    valid = true;
                    txtUrl.Text = $"{startText}{search}";
                }
            }
            return valid;
        }

        private bool checkUrlAniDB()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = htmlWeb.Load(txtUrl.Text);
            return doc.DocumentNode.SelectSingleNode("//table[@id='eplist']//tbody") != null;
        }
    }
}