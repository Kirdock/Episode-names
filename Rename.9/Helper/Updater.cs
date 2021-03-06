﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Episode_Names.Helper
{
    class Updater
    {
        private readonly static string Repository = "https://github.com/Kirdock/Episode-names/releases";
        private readonly static string Tags = $"{Repository}/latest";
        private readonly static string FileNameWithoutExtension = "Anwendung";
        private readonly static string FileName = FileNameWithoutExtension + ".zip";
        private readonly static string Download = Repository + "/download/{0}/" + FileName;

        internal static void CheckUpdate(bool Prompt, ProgressBar progressBar)
        {
            
            if (!Prompt || !Properties.Settings.Default.UpdateDialogShowed)
            {
                new Thread(() =>
                {
                    try
                    {
                        WebRequest request = WebRequest.Create(Tags);
                        WebResponse response = request.GetResponse();

                        string version = response.ResponseUri.ToString().Split(new char[] { '/' }).Last();
                        System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                        FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

                        if (version != fvi.FileVersion.Substring(0, version.Length))
                        {
                            if (Prompt)
                            {
                                DialogResult result = MessageHandler.MessagesYesNoCancel(MessageBoxIcon.Information, "Eine neue Version steht zur Verfügung. Möchten Sie sie runterladen?");
                                if (result == DialogResult.Yes)
                                {
                                    SetUpdateShowed(false);
                                    DownloadFile(version, progressBar);
                                }
                                else
                                {
                                    SetUpdateShowed(true);
                                }
                            }
                            else
                            {
                                DownloadFile(version, progressBar);
                            }
                        }
                        else if (!Prompt)
                        {
                            MessageHandler.MessagesOK(MessageBoxIcon.Information, "Sie besitzen bereits die aktuellste Version");
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorHelper.LogMessage(ex);
                    }
                }).Start();
            }
        }

        private static void SetUpdateShowed(bool status)
        {
            Properties.Settings.Default.UpdateDialogShowed = status;
            Properties.Settings.Default.Save();
        }

        private static void DownloadFile(string version, ProgressBar progressBar)
        {
            progressBar.Invoke(new MethodInvoker(() =>
            {
                progressBar.Style = ProgressBarStyle.Marquee;
            }));
            using (var client = new WebClient())
            {
                client.DownloadFile(string.Format(Download, version), FileName);

                string path = GetCurrentDirectory();
                string ZipPath = Path.Combine(path, FileName);
                ZipArchive archive = ZipFile.OpenRead(ZipPath);

                foreach (ZipArchiveEntry file in archive.Entries)
                {
                    string completeFileName = Path.Combine(path, file.FullName);
                    if (file.Name == "")
                    {// Assuming Empty for Directory
                        Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                        continue;
                    }
                    file.ExtractToFile(completeFileName, true);
                }
                archive.Dispose();
                File.Delete(ZipPath);
                RestartApp();

            }
        }

        internal static string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        private static void RestartApp()
        {
            string directory = GetCurrentDirectory();
            string BatchPath = Path.Combine(directory, "Updater.bat");
            string ZipFolder = Path.Combine(directory, FileNameWithoutExtension);
            StreamWriter writer = new StreamWriter(BatchPath);

            writer.WriteLine($"move \"{Path.Combine(ZipFolder, "*")}\" \"{directory}\"");
            writer.WriteLine($"start \"\" \"{Path.Combine(directory, AppDomain.CurrentDomain.FriendlyName)}\"");
            writer.WriteLine($"rmdir \"{ZipFolder}\"");
            writer.WriteLine($"del /Q \"{BatchPath}\"");

            writer.Close();
            Process process = new Process();
            process.StartInfo.FileName = BatchPath;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            Application.Exit();

        }
    }
}
