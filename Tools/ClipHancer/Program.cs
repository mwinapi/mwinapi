using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClipHancer
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
            ApplicationContext ac = new ApplicationContext();
            MainForm mf = new MainForm(ac);
            Application.Run(ac);
        }
    }
}