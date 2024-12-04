using System.Diagnostics;
using BOOSE;

namespace ASEAssignment
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
            Debug.WriteLine(AboutBOOSE.about());
        }
    }
}