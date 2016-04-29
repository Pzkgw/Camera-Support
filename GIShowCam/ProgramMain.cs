using GIShowCam.Info;
using System;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace GIShowCam
{
    static class ProgramMain
    {

        //private static VlcStartupOptions opt;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FormMain());
        }

    }
}
