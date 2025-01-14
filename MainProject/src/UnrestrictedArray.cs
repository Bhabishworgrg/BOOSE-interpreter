using BOOSE;

namespace MainProject
{
	public class UnrestrictedArray : BOOSE.Array, ICommand
	{
        public override void CheckParameters(string[] parameterList)
        {
            base.Parameters = base.ParameterList.Trim().Split(' ');
			if (base.Parameters.Length != 3 && base.Parameters.Length != 4)
        	{
				throw new CommandException("Invalid array declaration");
			}
		}

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
