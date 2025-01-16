namespace MainProject
{
    /// <summary>
    /// Represents the CLI command to initialize the application.
    /// </summary>
    public class CLIInit : ICLICommand
    {
        /// <summary>
        /// The receiver that performs the actual operation for this command.
        /// </summary>
        private CLIReceiver receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="CLIInit"/> class with the specified receiver.
        /// </summary>
		///
        /// <param name="receiver">The receiver responsible for handling the command logic.</param>
        public CLIInit(CLIReceiver receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        /// Executes the initialization command by invoking the receiver's corresponding method.
        /// </summary>
        public void Execute()
        {
            receiver.CLIInit();
        }
    }
}
