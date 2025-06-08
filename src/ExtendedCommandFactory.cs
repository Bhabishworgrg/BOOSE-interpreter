using BOOSE;

namespace BOOSE.Interpreter
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
				case "int":
					return new UnrestrictedInt();
				case "real":
					return new UnrestrictedReal();
				case "array":
					return new UnrestrictedArray();
				case "poke":
					return new UnrestrictedPoke();
				case "peek":
					return new UnrestrictedPeek();
				case "if":
					return new UnrestrictedIf();
				case "else":
					return new UnrestrictedElse();
				case "while":
					return new UnrestrictedWhile();
				case "for":
					return new UnrestrictedFor();
				case "end":
					return new UnrestrictedEnd();
				case "method":
					return new UnrestrictedMethod();
			}	

            return base.MakeCommand(commandType);
        }
    }
}
