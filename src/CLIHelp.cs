namespace BOOSE.Main
{
    /// <summary>
    /// Represents the CLI command to display help information.
    /// </summary>
    public class CLIHelp : ICLICommand
    {
        /// <summary>
        /// The receiver that performs the actual operation for this command.
        /// </summary>
        private CLIReceiver receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="CLIHelp"/> class with the specified receiver.
        /// </summary>
		///
		/// <param name="receiver">The receiver responsible for handling the command logic.</param>
        public CLIHelp(CLIReceiver receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        /// Executes the help command by invoking the receiver's corresponding method.
        /// </summary>
        public void Execute()
        {
            receiver.CLIHelp();
        }
    }
}
