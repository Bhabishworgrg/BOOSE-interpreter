using BOOSE;

namespace BOOSE.Interpreter
{
    /// <summary>
    /// Represents the unrestricted 'peek' command for accessing array elements.
    /// </summary>
	///
	/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.Peek.html">
	/// BOOSE.Peek
	/// </seealso>
    public class UnrestrictedPeek : UnrestrictedArray, ICommand
    {
		/// <summary>
		/// Blank constructor for factory instantiation.
		/// </summary>
        public UnrestrictedPeek() { }

        /// <summary>
        /// Checks the parameters for validity in the 'peek' command.
        /// </summary>
		///
        /// <param name="Parameters">The parameters passed to the 'peek' command.</param>
        /// <exception cref="CommandException">Thrown if the parameters are invalid.</exception>
        public override void CheckParameters(string[] Parameters)
        {
            if (Parameters.Length != 2 && Parameters.Length != 3)
            {
                throw new CommandException("Invalid array parameters");
            }
        }

        /// <summary>
        /// Compiles the 'peek' command, processing array parameters.
        /// </summary>
        public override void Compile()
        {
            ProcessArrayParametersCompile(false); // false means peek (as opposed to poke)
        }

        /// <summary>
        /// Executes the 'peek' command, updating the variable with the value from the array.
        /// </summary>
        public override void Execute()
        {
            ProcessArrayParametersExecute(false); // false means peek (as opposed to poke)

            switch (base.type)
            {
                case "int":
                    base.Program.UpdateVariable(base.peekVar, base.valueInt);
                    break;
                case "real":
                    base.Program.UpdateVariable(base.peekVar, base.valueReal);
                    break;
                default:
                    throw new CommandException("Invalid array type");
            }
        }
    }
}
