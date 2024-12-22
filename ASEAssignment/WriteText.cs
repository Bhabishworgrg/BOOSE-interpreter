using BOOSE;

namespace ASEAssignment
{
	/// <summary>
	/// Command to write text on the canvas.
	/// </summary>
	/// <seealso cref="BOOSE.CommandOneParameter"/>
	public class WriteText : CommandOneParameter
	{
		private string text;

		/// <summary>
		/// Blank constructor for factory instantiation.
		/// </summary>
		public WriteText() {}

		/// <summary>
		/// Write <paramref name="text"/> on the <paramref name="canvas"/> at the current position.
		/// </summary>
		/// <param name="canvas">Canvas to write text on.</param>
		/// <param name="text">Text to write on the canvas.</param>
		public WriteText(Canvas canvas, string text) : base(canvas)
		{
			this.text = text;
		}

		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <seealso cref="BOOSE.Command.Execute"/>
		public override void Execute()
		{
			text = Parameters[0];
			base.Canvas.WriteText(text);
		}

		/// <summary>
		/// Ensures that only one parameter is passed.
		/// </summary>
		/// <param name="parameterList">List of parameters.</param>
		/// <exception cref="CommandException">Thrown when the number of parameters is not equal to 1.</exception>
		/// <seealso cref="BOOSE.Command.CheckParameters"/>
        public override void CheckParameters(string[] parameterList)
        {
			if (parameterList.Length != 1)
			{
				throw new CommandException("Invalid number of parameters in " + ToString() + " :write <text>");
			}
        }
    
	}
}
