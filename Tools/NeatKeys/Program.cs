using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ManagedWinapi.Windows;

namespace NeatKeys
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new MainForm();
            Application.Run();
        }
    }
}