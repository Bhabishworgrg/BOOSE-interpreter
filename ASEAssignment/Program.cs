using System.Diagnostics;
using BOOSE;

namespace ASEAssignment
{
	/// <summary>
	/// The driver class for the application.
	/// </summary>
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Debug.WriteLine(AboutBOOSE.about());

			ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
