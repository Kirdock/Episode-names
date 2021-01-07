using Episode_Names.Helper;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Episode_Names.Anisearch
{
    public partial class Anisearch_Table : Form
    {
        private List<string> episodeList;
        private readonly string tvdbDomain = "https://www.thetvdb.com";
        private readonly string aniDBDomain = "https://anidb.net/perl-bin/";
        private readonly string fernsehserienDomain = "https://www.fernsehserien.de";

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
            cmbLanguageEpisodes.DataSource = cmbWebsite.SelectedIndex == 0 ? getEnglish() : cmbWebsite.SelectedIndex == 2 ? getGerman() : getLanguagesWithJapanese();
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
            else if(cmbWebsite.SelectedIndex == 2)
            {
                languages = getGerman();
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

        private List<KeyValuePair<string, string>> getGerman()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            addGerman(list);
            return list;
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
            addJapanese(languages);
            return languages;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            string language = ((KeyValuePair<string, string>)cmbLanguageEpisodes.SelectedItem).Key;
            int selectedIndex = cmbWebsite.SelectedIndex;
            string url = txtUrl.Text;
            string urlTVDB = cmbSeasons.SelectedItem != null ? ((KeyValuePair<string, string>)cmbSeasons.SelectedItem).Key : null;
            int season = cmbSeasons.SelectedIndex;
            
            new Thread(() =>
            {
                bool valid = false;
                try
                {
                    StartProgressBar();
                    List<string> result = null;
                    if (selectedIndex == 1 && (valid = checkUrlAnisearch(language, url, out url))) //Anisearch
                    {
                        result = getEpisodeList(url, language);
                    }
                    else if (selectedIndex == 3 && (valid = checkUrlTVDB(url, out url)))
                    {
                        
                        result = GetEpisodeListTVDB(urlTVDB, language);
                    }
                    else if (selectedIndex == 0 && (valid = checkUrlAniDB(url)))
                    {
                        result = getEpisodeListAniDB(url);
                    }
                    else if (valid = checkUrlFernsehserien(url, out url))
                    {
                        result = getEpisodeListFernsehserien(url, season);
                    }
                    setUrl(url);
                    episodeList = result;

                }
                catch (Exception ex)
                {
                    ErrorMessage(ex);
                }
                finally
                {
                    StopProgressBar();
                    if (valid)
                    {
                        CloseForm();
                    }
                    else
                    {
                        ErrorMessage(new UriFormatException());
                    }
                }
            }).Start();
        }

        private bool checkUrlFernsehserien(string inputUrl, out string url)
        {
            bool valid;
            url = string.Empty;
            string startText = "https://www.fernsehserien.de/";
            if (valid = inputUrl.StartsWith(startText))
            {
                inputUrl = inputUrl.Replace(startText, string.Empty);
                string searchText = inputUrl.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0];
                string changedUrl = startText + searchText + "/episodenguide";
                HtmlWeb htmlWeb = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = htmlWeb.Load(changedUrl);

                if (valid = doc.DocumentNode.SelectSingleNode("//nav[@class='series-menu']") != null)
                {
                    url = changedUrl;
                }
            }
            return valid;
        }

        private List<string> getEpisodeListFernsehserien(string url, int season)
        {

            List<string>  episodeList = new List<string>();
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            
            var tables = doc.DocumentNode.SelectNodes("//table[contains(@class,'episodenliste')]//tbody[@itemprop='season' or @itemprop='containsSeason']");
            int beginCounter = season == 0 ? 0 : season-1;
            int endCounter = season == 0 ? tables.Count - 1 : season-1;
            for (int i = beginCounter; i <= endCounter; i++)
            {
                foreach (HtmlNode row in tables[i].SelectNodes("tr[@itemprop='episode']"))
                {
                    StringBuilder builder = new StringBuilder();

                    builder.Append(WebUtility.HtmlDecode(row.SelectNodes("td")[1]?.InnerText ?? string.Empty).Trim()).Append("\t");
                    builder.Append(WebUtility.HtmlDecode(row.SelectNodes("td")[4]?.InnerText ?? string.Empty).Trim()).Append("\t");
                    var episodeTitle = row.SelectSingleNode("td//span[@itemprop='name']")?.InnerText ?? row.SelectSingleNode("td [@lang='ja']//span[@itemprop='name']")?.InnerText ?? string.Empty;
                    builder.Append(WebUtility.HtmlDecode(episodeTitle).Trim());

                    episodeList.Add(builder.ToString().Trim());
                }
            }
            return episodeList;
        }

        private List<string> GetEpisodeListTVDB(string url, string language)
        {
            
            language = language == "com" ? "en" : language;

            List<string>  episodeList = new List<string>();
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
                        episodeList.Add(line.Trim());
                    }
                }
            }
            return episodeList;
        }

        private List<string> getEpisodeListAniDB(string url)
        {

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);


            List<string> episodeList = new List<string>();

            foreach (HtmlNode row in doc.DocumentNode.SelectSingleNode("//table[@id='eplist']//tbody").SelectNodes("tr"))
            {
                string line = null;
                try
                {
                    StringBuilder builder = new StringBuilder();
                    var list = row.SelectNodes("td");

                    builder.Append(WebUtility.HtmlDecode(list[0].InnerText).Trim()).Append("\t");
                    builder.Append(WebUtility.HtmlDecode(list[1].InnerText).Trim());
                    line = builder.ToString();

                    
                }
                catch (NullReferenceException)
                {
                }


                if (line != null)
                {
                    episodeList.Add(line.Trim());
                }
            }
            return episodeList;
        }

        private string getDomain()
        {
            string language = ((KeyValuePair<string,string>) cmbLanguageSearch.SelectedItem).Key;
            return "https://anisearch." + (language.Equals("de") ? language : "com");
        }

        private string getDomainEpisodes(string language)
        {
            return "https://anisearch." + (language.Equals("de") ? language : "com");
        }


        private bool checkUrlAnisearch(string language,string inputUrl, out string url)
        {
            bool valid;
            url = string.Empty;
            string[] text = inputUrl.Replace("http://", "").Replace("https://", "").Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            if (valid = (inputUrl.ToUpper().Contains("ANISEARCH.") && text.Length>=3))
            {
                url = getDomainEpisodes(language) + "/" + text[1] + "/" + text[2] + "/episodes";
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


        public List<string> getData()
        {
            return episodeList;
        }


        private void ErrorMessage(Exception exception)
        {
            MethodInvoker LabelUpdate = delegate
            {
                StopProgressBar();
                if (exception is FileNotFoundException)
                {
                    MessageHandler.MessagesOK(MessageBoxIcon.Error, "HtmlAgilityPack.dll konnte nicht gefunden werden");
                }

                else
                {
                    ErrorHelper.HandleException(exception);
                }
            };
            BeginInvoke(LabelUpdate);
        }


        private void StopProgressBar(){
            pgLoading.GetCurrentParent().Invoke(new MethodInvoker(() =>
            {
                pgLoading.Style = ProgressBarStyle.Blocks;
            }));

            
            BeginInvoke(new MethodInvoker(()=>
            {
                setEnabled(true);
            }));
            
        }


        private List<string> getEpisodeList(string url, string language)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            language = language == "com" ? "en" : language;

            List<string> episodeList = new List<string>();
            HtmlNode table = doc.DocumentNode.SelectSingleNode("//table[@class='responsive-table episodes']//tbody");
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
                    episodeList.Add(line.Trim());
                }
            }
            return episodeList;
        }


        private void CloseForm()
        {
            StopProgressBar();
            DialogResult = DialogResult.OK;
            BeginInvoke(new MethodInvoker(()=> {
                Close();
            }));
        }

        private void Anisearch_Table_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = cmbLanguageEpisodes.SelectedIndex;
            Properties.Settings.Default.SelectedWebsite = cmbWebsite.SelectedIndex;
            Properties.Settings.Default.SecondLanguage = cmbLanguageSearch.SelectedIndex;
            Properties.Settings.Default.Save();
        }


        private void StartProgressBar()
        {
            pgLoading.GetCurrentParent().BeginInvoke(new MethodInvoker(() => {
                pgLoading.Style = ProgressBarStyle.Marquee;
            }));;
            BeginInvoke(new MethodInvoker(() =>
            {
                setEnabled(false);
            }));
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
                int index = cmbWebsite.SelectedIndex;
                int selectedLanguageIndex = cmbLanguageSearch.SelectedIndex;
                string selectedLanguage = ((KeyValuePair<string, string>)cmbLanguageSearch.SelectedItem).Key;
                new Thread(() =>
                {
                    try
                    {
                        switch (index)
                        {
                            case 0: //aniDB
                                searchTextAniDB(searchText);
                                break;

                            case 1: //Anisearch
                                searchTextAnisearch(getSearchUrlAnisearch(searchText, domain), domain);
                                break;

                            case 2: //Fernsehserien.de
                                searchTextFernsehserien(searchText);
                                break;

                            case 3: //TVDB
                                string language = selectedLanguageIndex == 0 ? "de" : selectedLanguage;
                                searchTextTVDB(searchText, language);
                                break;
                        }
                    }
                    catch (Exception exception)
                    {
                        ErrorMessage(exception);
                    }
                    finally
                    {
                        StopProgressBar();
                    }
                }).Start();
                
            }
        }

        private string adjustSearchTextTVDB(string text)
        {
            return text.Replace("/", "%2F");
        }

        private void searchTextFernsehserien(string searchText)
        {
            Uri ur = new Uri($"{fernsehserienDomain}/suche/{adjustSearchTextTVDB(searchText).Replace("%2F"," ")}");
            List<KeyValuePair<string, string>> resultUrl = new List<KeyValuePair<string, string>>();

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(ur.AbsoluteUri);
            string url = web.ResponseUri.ToString();
            if (!url.StartsWith(fernsehserienDomain + "/suche/"))
            {
                setUrl(url);
                getSeasonsFernsehserien(url);
            }
            else
            {
                foreach (HtmlNode entry in doc.DocumentNode.SelectNodes("//li[contains(@class,'suchergebnis')]"))
                {
                    string text = WebUtility.HtmlDecode(entry.SelectSingleNode("a/span[@class='suchergebnis-titel']").InnerText);
                    string nurl = WebUtility.HtmlDecode(entry.SelectSingleNode("a[@href]").Attributes["href"].Value);
                    resultUrl.Add(new KeyValuePair<string, string>(fernsehserienDomain + nurl + "/episodenguide", text));
                }
                setReceivedUrls(resultUrl);
            }
        }


        private void searchTextAniDB(string searchText)
        {
            string baseUrl = "https://anidb.net/perl-bin/animedb.pl?";
            Uri ur = new Uri($"{baseUrl}adb.search={adjustSearchTextTVDB(searchText)}&show=animelist&do.search=search");
            List<KeyValuePair<string, string>> resultUrl = new List<KeyValuePair<string, string>>();

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(ur.AbsoluteUri);
            
            string url = web.ResponseUri.ToString();
            if (url.StartsWith($"{baseUrl}?show=anime&aid="))
            {
                setUrl(url);
            }
            else
            {
                HtmlNode table = doc.DocumentNode.SelectNodes("//table[@id= 'animelist']//tbody")[0];
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    string text = WebUtility.HtmlDecode(row.SelectSingleNode("td[@data-label='Title']//a").InnerText);
                    string nurl = WebUtility.HtmlDecode(row.SelectSingleNode("td//a[@href]").Attributes["href"].Value);
                    resultUrl.Add(new KeyValuePair<string, string>(aniDBDomain + nurl, text));
                }
                setReceivedUrls(resultUrl);
            }
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
                    resultUrl.Add(new KeyValuePair<string, string>($"{domain}/{nurl}", text));
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
            txtUrl.BeginInvoke(new MethodInvoker(() =>
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
                StartProgressBar();
                int selectedIndex = cmbWebsite.SelectedIndex;
                new Thread(() =>
                {
                    try
                    {
                        if (selectedIndex == 3) //TVDB
                        {
                            getSeasons(url);
                        }
                        else if (selectedIndex == 2) //Fernsehserien
                        {
                            getSeasonsFernsehserien(url);
                        }
                        StopProgressBar();

                        txtUrl.BeginInvoke(new MethodInvoker(() =>
                        {
                            txtUrl.Text = url;
                        }));
                    }
                    catch(Exception ex)
                    {
                        ErrorMessage(ex);
                    }
                    finally
                    {
                        StopProgressBar();
                    }
                }).Start();
            }
        }

        private void getSeasonsFernsehserien(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            IEnumerable<KeyValuePair<string, string>> seasons = doc.DocumentNode.SelectNodes("//nav[@class='series-menu']/ul/li[a[contains(text(), 'Episoden')]]/ul/li/a[1]").Select(node => new KeyValuePair<string, string>(fernsehserienDomain + node.Attributes["href"].Value, node.InnerText));
            List<KeyValuePair<string, string>> resultUrl = seasons?.ToList() ?? new List<KeyValuePair<string, string>>(){new KeyValuePair<string, string>(url, "Übersicht")};
            setSeasons(resultUrl);
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
            cmbSeasons.BeginInvoke(new MethodInvoker(() =>
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
            lblSeason.Visible = cmbSeasons.Visible = cmbWebsite.SelectedIndex > 1;
            setCmbLanguages();
        }

        private void btnCheckURL_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            string language = ((KeyValuePair<string, string>)cmbLanguageEpisodes.SelectedItem).Key;
            bool valid = cmbWebsite.SelectedIndex == 1 && checkUrlAnisearch(language,url, out url) || cmbWebsite.SelectedIndex == 0 && checkUrlAniDB(url);
            int selectedIndex = cmbWebsite.SelectedIndex;
            StartProgressBar();

            new Thread(() =>
            {
                if (selectedIndex == 3 && (valid = checkUrlTVDB(url, out url))) {
                
                    getSeasons(url);
                }
                else if(selectedIndex == 2 && (valid = checkUrlFernsehserien(url, out url)))
                {
                    getSeasonsFernsehserien(url);
                }
                
                StopProgressBar();
                if (!valid)
                {
                    ErrorMessage(new UriFormatException());
                }
                setUrl(url);
            }).Start();
        }

        private bool checkUrlTVDB(string inputUrl, out string url)
        {
            bool valid = false;
            url = string.Empty;
            string startText = "https://www.thetvdb.com/series/";
            if (inputUrl.StartsWith(startText))
            {
                string search = inputUrl.Replace(startText, string.Empty);

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
                htmlWeb.Load(inputUrl);
                if(valid = (lastStatusCode == HttpStatusCode.OK))
                {
                    url = $"{startText}{search}";
                }
            }
            return valid;
        }

        private bool checkUrlAniDB(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = htmlWeb.Load(url);
            return doc.DocumentNode.SelectSingleNode("//table[@id='eplist']//tbody") != null;
        }
    }
}