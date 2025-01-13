using BOOSE;

namespace MainProject
{
	public class UnrestrictedEnd : CompoundCommand
	{
		public UnrestrictedEnd()
		{
			ReduceRestrictions();
		}
        
		public override void Restrictions() { }

		public override void Compile()
		{
			base.CorrespondingCommand = base.Program.Pop();

			if (base.CorrespondingCommand is UnrestrictedIf && !base.ParameterList.Contains("if"))
			{
				throw new CommandException("Mismatched end, should be end if");
			}

			if (base.CorrespondingCommand is UnrestrictedWhile && !base.ParameterList.Contains("while"))
			{
				throw new CommandException("Mismatched end, should be end while");
			}

			if (base.CorrespondingCommand is For && !base.ParameterList.Contains("for"))
			{
				throw new CommandException("Mismatched end, should be end for");
			}

			base.LineNumber = base.Program.Count;
			base.CorrespondingCommand.EndLineNumber = base.LineNumber;
		}

		public override void Execute()
		{
			if (base.CorrespondingCommand is UnrestrictedWhile)
			{
				base.Program.PC = base.CorrespondingCommand.LineNumber - 1;
			}
			else if (base.CorrespondingCommand is For forCmd)
			{
				Evaluation loopControlV = forCmd.LoopControlV;
				int num = loopControlV.Value + forCmd.Step;
				
				if (!base.Program.VariableExists(loopControlV.VarName))
				{
					throw new CommandException($"Variable {loopControlV.VarName} does not exist");
				}

				base.Program.UpdateVariable(loopControlV.VarName, num);
				if ((forCmd.From > forCmd.To && forCmd.Step >= 0) || (forCmd.From < forCmd.To && forCmd.Step <= 0))
				{
					throw new CommandException("Infinite for loop");
				}

				if ((num < forCmd.To && forCmd.Step > 0) || (num > forCmd.To && forCmd.Step < 0))
				{
					base.Program.PC = base.CorrespondingCommand.LineNumber;
				}
			}
		}
	}
}
