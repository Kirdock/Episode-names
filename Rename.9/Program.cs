﻿using System;
using System.Linq;
using System.Windows.Forms;

namespace Episode_Names
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args.FirstOrDefault()));
        }

       
    }
}
