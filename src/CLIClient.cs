namespace BOOSE.Interpreter
{
    /// <summary>
    /// Represents the CLI client responsible for processing and executing CLI commands based on user input.
    /// </summary>
    public class CLIClient
    {
        /// <summary>
        /// Executes the specified command option by initializing the appropriate CLI command and invoking it.
        /// </summary>
		/// 
		/// <remarks>
        /// Supported options:
        /// <list type="bullet">
        /// <item><description>-h: Display help information.</description></item>
        /// <item><description>-v: Display the version information.</description></item>
        /// <item><description>-i: Initialize the application.</description></item>
        /// <item><description>-g: Launch the GUI interface.</description></item>
        /// <item><description>Any other input defaults to generating output.</description></item>
        /// </list>
        /// </remarks>
        /// 
		/// <param name="option">The command-line option provided by the user.</param>
        public void Run(string option)
        {
            CLIReceiver receiver = new CLIReceiver();

            ICLICommand command;
            switch (option)
            {
                case "-h":
                    command = new CLIHelp(receiver);
                    break;
                case "-v":
                    command = new CLIVersion(receiver);
                    break;
                case "-i":
                    command = new CLIInit(receiver);
                    break;
                case "-g":
                    command = new CLIGUI(receiver);
                    break;
                default:
                    command = new CLIGenerate(receiver, option);
                    break;
            }

            CLIInvoker invoker = new CLIInvoker();
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }
}
