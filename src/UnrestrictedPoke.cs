using BOOSE;

namespace BOOSE.Main
{
    /// <summary>
    /// Represents the unrestricted 'poke' command for modifying array elements.
    /// </summary>
	///
	/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.Poke.html">
	/// BOOSE.Poke
	/// </seealso>
    public class UnrestrictedPoke : UnrestrictedArray, ICommand
    {
		/// <summary>
		/// Blank constructor for factory instantiation.
		/// </summary>
        public UnrestrictedPoke() { }

        /// <summary>
        /// Checks the parameters for validity in the 'poke' command.
        /// </summary>
		///
        /// <param name="parameter">The parameters passed to the 'poke' command.</param>
        /// <exception cref="CommandException">Thrown if the parameters are invalid.</exception>
        public override void CheckParameters(string[] parameter)
        {
            if (parameterList.Length != 2 && parameterList.Length != 3)
            {
                throw new CommandException("Invalid array parameters");
            }
        }

        /// <summary>
        /// Compiles the 'poke' command, processing array parameters for modification.
        /// </summary>
        public override void Compile()
        {
            ProcessArrayParametersCompile(true); // true means poke (as opposed to peek)
        }

        /// <summary>
        /// Executes the 'poke' command, modifying the array with the specified value.
        /// </summary>
        public override void Execute()
        {
            ProcessArrayParametersExecute(true); // true means poke (as opposed to peek)
        }

        /// <summary>
        /// Sets the program and parameters for the 'poke' command.
        /// </summary>
       	/// 
		/// <param name="Program">The stored program instance.</param>
        /// <param name="Params">The parameters passed to the command.</param>
        public override void Set(StoredProgram Program, string Params)
        {
            base.Set(Program, Params);
        }
    }
}
