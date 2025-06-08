namespace BOOSE.Interpreter
{
    /// <summary>
    /// Represents the CLI command to launch the GUI interface.
    /// </summary>
    public class CLIGUI : ICLICommand
    {
        /// <summary>
        /// The receiver that performs the actual operation for this command.
        /// </summary>
        private CLIReceiver receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="CLIGUI"/> class with the specified receiver.
        /// </summary>
		///
        /// <param name="receiver">The receiver responsible for handling the command logic.</param>
        public CLIGUI(CLIReceiver receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        /// Executes the GUI command by invoking the receiver's corresponding method.
        /// </summary>
        public void Execute()
        {
            receiver.CLIGUI();
        }
    }
}
