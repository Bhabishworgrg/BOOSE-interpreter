using BOOSE;

namespace BOOSE.Main
{
    /// <summary>
    /// Represents an unrestricted array command in BOOSE that allows array manipulation.
    /// </summary>
	///
	/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.Array.html">
	/// BOOSE.Array
	/// </seealso>
    public class UnrestrictedArray : BOOSE.Array, ICommand
    {
        /// <summary>
        /// Checks the parameters for the array command to ensure they are valid.
        /// </summary>
		///
        /// <param name="parameterList">Array of parameters to be checked.</param>
        /// <exception cref="CommandException">Thrown if the array declaration is invalid.</exception>
        public override void CheckParameters(string[] parameterList)
        {
            base.Parameters = base.ParameterList.Trim().Split(' ');
            if (base.Parameters.Length != 3 && base.Parameters.Length != 4)
            {
                throw new CommandException("Invalid array declaration");
            }
        }

        /// <summary>
        /// Processes the parameters for the array command during compilation.
        /// </summary>
        /// 
		/// <param name="peekOrPoke">Indicates whether the operation is Peek (false) or Poke (true).</param>
        /// <exception cref="CommandException">Thrown if the array parameters are invalid.</exception>
        protected override void ProcessArrayParametersCompile(bool peekOrPoke)
        {
            int index;
            int index2;

            // Peek is false, Poke is true.
            if (peekOrPoke)
            {
                // When Poke is called e.g. poke x 0 = 10
                // index2 takes reference to the array element i.e. x 0
                // index takes the value of the array element i.e. 10
                index = 1;
                index2 = 0;
            }
            else
            {
                // When Peek is called e.g. peek y = x 0
                // index takes reference to the array element i.e. y
                // index2 takes the value of the array element i.e. x 0
                index = 0;
                index2 = 1;
            }

            string[] elements = base.parameterList.Split('=');
            string[] valueRef = elements[index2].Trim().Split(' ');

            if (elements.Length < 2 || valueRef.Length < 1)
            {
                throw new CommandException("Invalid array parameters");
            }

            base.varName = valueRef[0].Trim();
            if (!base.Program.VariableExists(base.varName))
            {
                throw new CommandException("No such array");
            }

            base.peekVar = base.pokeValue = elements[index].Trim();

            base.rowS = valueRef[1];
            if (valueRef.Length == 3)
            {
                base.columnS = valueRef[2];
            }
        }
    }
}
