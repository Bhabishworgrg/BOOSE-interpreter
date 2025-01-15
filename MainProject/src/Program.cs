using System.Diagnostics;
using BOOSE;

namespace MainProject
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
        public static void Main(string[] args)
        {
            Debug.WriteLine(AboutBOOSE.about());
			if (args.Length > 0)
            {
				CLIClient client = new CLIClient();
				client.Run(args.First());
				return;
			}

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
	}
}
