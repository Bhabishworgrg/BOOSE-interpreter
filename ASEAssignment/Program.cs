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
            Debug.WriteLine(AboutBOOSE.about());
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}