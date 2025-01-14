using BOOSE;

namespace MainProject
{
	public class UnrestrictedPoke : UnrestrictedArray, ICommand
	{
		public UnrestrictedPoke() { }

		public override void CheckParameters(string[] parameter)
		{
			if (parameterList.Length != 2 && parameterList.Length != 3)
			{
				throw new CommandException("Invalid array parameters");
			}
		}

		public override void Compile()
		{
			ProcessArrayParametersCompile(true);
		}

		public override void Execute()
		{
			ProcessArrayParametersExecute(true);
		}

		public override void Set(StoredProgram Program, string Params)
		{
			base.Set(Program, Params);
		}
	}
}
