namespace BOOSE.Main
{
    /// <summary>
    /// Represents the command to retrieve and display the CLI version.
    /// </summary>
    public class CLIVersion : ICLICommand
    {
        private CLIReceiver receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="CLIVersion"/> class.
        /// </summary>
		///
        /// <param name="receiver">The <see cref="CLIReceiver"/> that handles the version retrieval.</param>
        public CLIVersion(CLIReceiver receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        /// Executes the command to retrieve and display the CLI version.
        /// </summary>
        public void Execute()
        {
            receiver.CLIVersion();
        }
    }
}
