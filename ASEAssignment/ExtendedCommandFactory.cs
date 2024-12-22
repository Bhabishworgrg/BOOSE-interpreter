using BOOSE;

namespace ASEAssignment
{
	/// <summary>
	/// Extension of the CommandFactory class to allow for additional commands.
	/// </summary>
	/// <seealso cref="BOOSE.CommandFactory"/>
	public class ExtendedCommandFactory : CommandFactory
	{
		/// <summary>
		/// Makes a command based on the <paramref name="commandType"/>.
		/// </summary>
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

            return (base.MakeCommand(commandType));
        }
	}
}
