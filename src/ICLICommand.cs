namespace BOOSE.Main
{
    /// <summary>
    /// Represents a command in the CLI that can be executed.
    /// </summary>
    public interface ICLICommand
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        void Execute();
    }
}
