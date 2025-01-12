using BOOSE;

namespace MainProject
{
	public class UnrestrictedPoke : UnrestrictedArray
	{
		public UnrestrictedPoke() { }

		public override void CheckParameters(string[] parameter)
		{
			if (parameterList.Length != 2 && parameterList.Length != 3)
			{
				throw new CommandException("sth 1");
			}
		}

		public override void Compile()
		{
			ProcessArrayParametersCompile(peekOrPoke: true);
		}

		public override void Execute()
		{
			ProcessArrayParametersExecute(peekOrPoke: true);
		}

		public override void Set(StoredProgram Program, string Params)
		{
			base.Set(Program, Params);
		}
	}
}
