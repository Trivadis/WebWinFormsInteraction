using System;
using System.Windows.Forms;

namespace WinFormsFrontend
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // IMPORTANT REMARK:
            // The installed Nuget-Package SignalR.Client has to be compatible with the SignalR Hub Version.
            // It is not possible (according to my experience) to connect a WinForms App with a .Net Core SignalR Hub.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
