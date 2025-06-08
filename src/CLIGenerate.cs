namespace BOOSE.Main
{
    /// <summary>
    /// Represents the CLI command to generate output.
    /// </summary>
    public class CLIGenerate : ICLICommand
    {
		private string option;

        /// <summary>
        /// The receiver that performs the actual operation for this command.
        /// </summary>
        private CLIReceiver receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="CLIGenerate"/> class with the specified receiver.
        /// </summary>
		///
        /// <param name="receiver">The receiver responsible for handling the command logic.</param>
        public CLIGenerate(CLIReceiver receiver, string option)
        {
            this.receiver = receiver;
			this.option = option;
        }

        /// <summary>
        /// Executes the generate command by invoking the receiver's corresponding method.
        /// </summary>
        public void Execute()
        {
            receiver.CLIGenerate(option);
        }
    }
}
