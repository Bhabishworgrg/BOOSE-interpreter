using BOOSE;

namespace MainProject
{
    /// <summary>
    /// Extension of the CommandFactory class to allow for additional commands.
    /// </summary>
    ///
    /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.CommandFactory.html">
    /// BOOSE.CommandFactory
    /// </seealso>
    public class ExtendedCommandFactory : CommandFactory
    {
        /// <summary>
        /// Makes a command based on the <paramref name="commandType"/>.
        /// </summary>
        ///
        /// <param name="commandType">Type of command to make.</param>
        /// <returns>Object of the command type.</returns>
        public override ICommand MakeCommand(string commandType)
        {
            commandType = commandType.ToLower().Trim();
            switch (commandType)
            {
                case "write":
                    return new WriteText();
                case "tri":
                    return new Tri();
            }

            return base.MakeCommand(commandType);
        }
    }
}
