using BOOSE;

namespace BOOSE.Interpreter
{
    /// <summary>
    /// Represents an unrestricted End command in BOOSE, used to end control structures such as If, While, and For.
    /// </summary>
	///
	/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.End.html">
	/// BOOSE.End
	/// </seealso>
    public class UnrestrictedEnd : CompoundCommand, ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnrestrictedEnd"/> class, reducing restrictions for the command.
        /// </summary>
        public UnrestrictedEnd()
        {
            ReduceRestrictions();
        }

        /// <summary>
		/// Override the restrictions to remove them.
        /// </summary>
        public override void Restrictions() { }

        /// <summary>
        /// Compiles the End command by checking for matching control structures like If, While, or For.
        /// </summary>
		///
        /// <exception cref="CommandException">Thrown if there is a mismatch between the End command and its corresponding control structure.</exception>
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

            if (base.CorrespondingCommand is UnrestrictedFor && !base.ParameterList.Contains("for"))
            {
                throw new CommandException("Mismatched end, should be end for");
            }

            base.LineNumber = base.Program.Count;
            base.CorrespondingCommand.EndLineNumber = base.LineNumber;
        }

        /// <summary>
        /// Executes the End command, controlling the flow of execution in control structures such as While and For loops.
        /// </summary>
		///
        /// <exception cref="CommandException">Thrown if there is an issue with the loop control or variable updates in For loops.</exception>
        public override void Execute()
        {
            if (base.CorrespondingCommand is UnrestrictedWhile)
            {
                base.Program.PC = base.CorrespondingCommand.LineNumber - 1;
            }
            else if (base.CorrespondingCommand is UnrestrictedFor forCmd)
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
			else if (base.CorrespondingCommand is UnrestrictedMethod)
			{
				base.Program.PC = base.CorrespondingCommand.ReturnLineNumber;
			}
        }
    }
}
