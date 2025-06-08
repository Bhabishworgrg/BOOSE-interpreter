namespace BOOSE.Main
{
    /// <summary>
    /// The driver class for the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
				RunCLIBOOSE(args.First());
				return;
            }

            Console.WriteLine("Starting BOOSE interpreter...");
			RunGUIBOOSE();
        }

		public static void RunCLIBOOSE(string option)
		{
                CLIClient client = new CLIClient();
                client.Run(option);
		}

		public static void RunGUIBOOSE()
		{
            CLISetup setup = new CLISetup();
            string filePath = "C:\\Windows\\boose.bat";

            if (setup.HasAdminRights())
            {
                Console.WriteLine("Administrative rights detected. Creating batch file...");
                setup.CreateBatchFile(filePath);
                Console.WriteLine("Batch file created. BOOSE is now a command-line tool.");
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Prompting user to enable BOOSE as a command-line tool...");

                DialogResult option = MessageBox.Show(
                    "Do you want to enable BOOSE as a command-line tool too? " +
                    "This is optional and not required for using the BOOSE interpreter.",
                    "Enable BOOSE in CLI?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (option == DialogResult.Yes)
                {
                    setup.RestartAsAdmin();
                    return;
                }

                Console.WriteLine("User declined.");
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
		}
    }
}
