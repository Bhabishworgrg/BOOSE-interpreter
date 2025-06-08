namespace BOOSE.Main
{
    /// <summary>
    /// Represents the invoker in the command design pattern, responsible for executing a command.
    /// </summary>
    public class CLIInvoker
    {
        /// <summary>
        /// The command to be executed.
        /// </summary>
        private ICLICommand? command = null;

        /// <summary>
        /// Sets the command to be executed.
        /// </summary>
		///
        /// <param name="command">The command to set.</param>
        public void SetCommand(ICLICommand command)
        {
            this.command = command;
        }

        /// <summary>
        /// Executes the set command if it is not null.
        /// </summary>
        public void ExecuteCommand()
        {
            if (command != null)
            {
                command.Execute();
            }
        }
    }
}
