﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Episode_Names.Helper
{
    class MessageHandler
    {
        internal static DialogResult? MessagesYesNo(MessageBoxIcon messageBoxIcon, string text)
        {
            string warnung = (messageBoxIcon == MessageBoxIcon.Exclamation) ? "Achtung!" : ((messageBoxIcon == MessageBoxIcon.Error)) ? "Warnung!" : "Frage";
            return MessageBox.Show(text,
                                warnung,
                                MessageBoxButtons.YesNo,
                                messageBoxIcon,
                                MessageBoxDefaultButton.Button1);
        }

        internal static void MessagesOK(MessageBoxIcon messageBoxIcon, string text)
        {
            MessageBox.Show(text,
                            (messageBoxIcon == MessageBoxIcon.Exclamation) ? "Achtung!" : (messageBoxIcon == MessageBoxIcon.Error) ? "Warnung!" : "Info",
                            MessageBoxButtons.OK,
                            messageBoxIcon,
                            MessageBoxDefaultButton.Button1);
        }

        internal static DialogResult MessagesYesNoCancel(MessageBoxIcon messageBoxIcon, string text)
        {
            string warnung = (messageBoxIcon == MessageBoxIcon.Exclamation) ? "Achtung!" : ((messageBoxIcon == MessageBoxIcon.Error)) ? "Warnung!" : "Frage";
            return MessageBox.Show(text,
                                warnung,
                                MessageBoxButtons.YesNoCancel,
                                messageBoxIcon,
                                MessageBoxDefaultButton.Button1);
        }

        internal static void FolderNotFound()
        {
            MessagesOK(MessageBoxIcon.Error, "Die angegebene Ordner existiert nicht!");
        }

        
    }
}
