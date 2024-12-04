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
            Application.Run(new Form1());
            Debug.WriteLine(AboutBOOSE.about());
        }
    }
}