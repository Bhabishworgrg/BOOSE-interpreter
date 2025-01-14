using BOOSE;

namespace MainProject
{
	public class UnrestrictedPeek : UnrestrictedArray, ICommand
	{
		public UnrestrictedPeek() { }

		public override void CheckParameters(string[] Parameters)
		{
			if (Parameters.Length != 2 && Parameters.Length != 3)
			{
				throw new CommandException("Invalid array parameters");
			}
		}

		public override void Compile()
		{
			ProcessArrayParametersCompile(false);
		}

		public override void Execute()
		{
			ProcessArrayParametersExecute(false);

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
