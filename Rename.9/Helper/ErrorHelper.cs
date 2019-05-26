using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Episode_Names.Helper
{
    class ErrorHelper : MessageHandler
    {
        private static readonly string path = Path.Combine(Updater.GetCurrentDirectory(), "Logs.log");
        private static readonly string ErrorMessage = "Es ist ein Fehler aufgetreten!\nBitte kontaktieren Sie Ihren Administrator.";

        public static void HandleException(Exception exception)
        {
            string message = null;
            if (exception is DirectoryNotFoundException)
            {
                message = "Das Verzeichnis wurde nicht gefunden";
            }

            else if (exception is FileNotFoundException)
            {
                message = "Die Datei konnte nicht gefunden werden";
            }


            else if (exception is UnauthorizedAccessException)
            {
                message = "Der Zugriff wurde verweigert!";
            }

            else if (exception is PathTooLongException)
            {
                message = "Der Pfad ist zu lang";
            }

            else if (exception is NotSupportedException)
            {
                message = "Der Vorgang wird nicht unterstützt";
            }

            else if (exception is UriFormatException)
            {
                message = "Ungültige Url";
            }

            else if (exception is System.Net.WebException)
            {
                message = "Die Webseite wurde nicht gefunden";
            }

            if(message != null)
            {
                MessagesOK(MessageBoxIcon.Error, message);
            }
            else
            {
                MessagesOK(MessageBoxIcon.Error, "Unbekannter Fehler aufgetreten");
            }

            LogMessage(exception);


        }

        internal static void LogMessage(Exception exception)
        {
            try
            {
                File.AppendAllText(path, exception.ToString() + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessagesOK(MessageBoxIcon.Error,ErrorMessage + '\n' + ex.ToString());
            }

        }
    }
}
