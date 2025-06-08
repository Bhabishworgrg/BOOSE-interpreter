using BOOSE;

namespace BOOSE.Main
{
    /// <summary>
    /// Represents an unrestricted integer evaluation command in BOOSE with reduced restrictions.
    /// </summary>
	///
	/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.Int.html">
	/// BOOSE.Int
	/// </seealso>
    public class UnrestrictedInt : Evaluation, ICommand
    {
        /// <summary>
        /// Compiles the command by adding the variable to the program.
        /// </summary>
        public override void Compile()
        {
            base.Compile();
            base.Program.AddVariable(this);
        }

        /// <summary>
        /// Executes the integer evaluation command, parsing the evaluated expression to an integer.
        /// </summary>
        /// 
		/// <exception cref="StoredProgramException">Thrown if the expression cannot be parsed to an integer or if there is a data loss during conversion from a real number.</exception>
        public override void Execute()
        {
            base.Execute();

            if (int.TryParse(base.evaluatedExpression, out base.value))
            {
                base.Program.UpdateVariable(base.varName, base.value);
                return;
            }

            if (double.TryParse(base.evaluatedExpression, out _))
            {
                throw new StoredProgramException("Can't convert real number to integer without data loss, use cast");
            }

            throw new StoredProgramException("Could not parse integer expression");
        }
    }
}
