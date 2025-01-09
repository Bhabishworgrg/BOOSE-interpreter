using BOOSE;

namespace MainProject
{
	public class UnrestrictedInt : Evaluation, ICommand
	{
		public void Compile()
		{
			base.Compile();
			base.Program.AddVariable(this);
		}

		public void Execute()
		{
			base.Execute();
			
			if (int.TryParse(base.evaluatedExpression, out value))
			{
				base.Program.UpdateVariable(base.varName, base.value);
				return;
			}

			if (double.TryParse(base.evaluatedExpression, out double doubleValue))
			{
				throw new StoredProgramException("Can't convert real number to integer without data loss, use cast");
			}
			
			throw new StoredProgramException("Could not parse integer expression");
		}
	}
}
