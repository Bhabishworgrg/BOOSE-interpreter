using BOOSE;

namespace BOOSE.Interpreter
{
    /// <summary>
    /// Command to write text on the canvas.
    /// </summary>
    /// 
    /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.CommandOneParameter.html">
    /// BOOSE.CommandOneParameter
    /// </seealso>
    public class WriteText : CommandOneParameter, ICommand
    {
        private string text = "";

        /// <summary>
        /// Blank constructor for factory instantiation.
        /// </summary>
		public WriteText() { }

        /// <summary>
        /// Write <paramref name="text"/> on the <paramref name="canvas"/> at the current position.
        /// </summary>
        /// 
        /// <param name="canvas">Canvas to write text on.</param>
        /// <param name="text">Text to write on the canvas.</param>
        public WriteText(Canvas canvas, string text) : base(canvas)
        {
            this.text = text;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        ///
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.Command.html#BOOSE_Command_Execute">
        /// BOOSE.Command.Execute
        /// </seealso>
        public override void Execute()
        {
            base.Execute();
           
			// For cases when text has "," in it.
			// Can't use base.Parameters[0] as it will only return the text before ",".
			if (base.Parameters.Length > 1)
			{
				text = base.ParameterList[1..^1];
				base.Canvas.WriteText(text);
				return;
			}

			try
			{
				text = base.Program.EvaluateExpression(base.Parameters[0]);
			}
			catch (StoredProgramException)
			{
				text = base.Program.EvaluateExpressionWithString(base.Parameters[0]);
			}

            base.Canvas.WriteText(text);
        }

        /// <summary>
        /// Ensures that the parameter isn't empty.
        /// </summary>
        /// 
        /// <param name="parameterList">List of parameters.</param>
        /// <exception cref="BOOSE.CommandException">Thrown when the number of parameters is not equal to 1.</exception>
        /// 
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.Command.html#BOOSE_Command_CheckParameters_System_String___">
        /// BOOSE.Command.CheckParameters
        /// </seealso>
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.CommandException.html">
        /// BOOSE.CommandException
        /// </seealso>
        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList[0] == "")
            {
                throw new CommandException($"Invalid number of parameters in {ToString()} :write <text>");
            }
        }

    }
}
