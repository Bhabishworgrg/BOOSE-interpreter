using BOOSE;

namespace MainProject
{
	public class UnrestrictedPeek : UnrestrictedArray
	{
		public UnrestrictedPeek() { }

		public override void CheckParameters(string[] Parameters)
		{
			if (Parameters.Length != 2 && Parameters.Length != 3)
			{
				throw new CommandException("sth 2");
			}
		}

		public override void Compile()
		{
			ProcessArrayParametersCompile(peekOrPoke: false);
		}

		public override void Execute()
		{
			ProcessArrayParametersExecute(peekOrPoke: false);
			if (base.type == "int")
			{
				base.Program.UpdateVariable(peekVar, valueInt);
				return;
			}

			if (base.type == "real")
			{
				base.Program.UpdateVariable(peekVar, valueReal);
				return;
			}

			throw new CommandException("sth 3");
		}
	}
}
