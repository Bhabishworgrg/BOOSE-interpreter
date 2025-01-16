namespace MainProject
{
    /// <summary>
    /// The driver class for the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
				RunCLIBOOSE(args.First());
				return;
            }

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
                setup.CreateBatchFile(filePath);
            }

            if (!File.Exists(filePath))
            {

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

            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
		}
    }
}
