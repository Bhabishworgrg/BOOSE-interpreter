using BOOSE;

namespace ASEAssignment
{
	/// <summary>
	/// Command to draw a triangle on the canvas.
	/// </summary>
	/// <seealso cref="BOOSE.CommandTwoParameters"/>
	public class Tri : CommandTwoParameters
	{
		private int width, height;

		/// <summary>
		/// Blank constructor for factory instantiation.
		/// </summary>
		public Tri() {}

		/// <summary>
		/// Draw a triangle of <paramref name="width"/> and <paramref name="height"/> on the <paramref name="canvas"/>.
		/// </summary>
		/// <param name="canvas">Canvas to draw the triangle on.</param>
		/// <param name="width">Width of the triangle.</param>
		/// <param name="height">Height of the triangle.</param>
		public Tri(Canvas canvas, int width, int height) : base(canvas)
		{
			this.width = width;
			this.height = height;
		}

		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <seealso cref="BOOSE.Command.Execute"/>
		public override void Execute()
		{
			base.Execute();

			width = Paramsint[0];
			height = Paramsint[1];
			base.Canvas.Tri(width, height);
		}

		/// <summary>
		/// Ensures that only two parameters are passed.
		/// </summary>
		/// <param name="parameterList">List of parameters.</param>
		/// <exception cref="CommandException">Thrown when the number of parameters is not equal to 2.</exception>
		/// <seealso cref="BOOSE.Command.CheckParameters"/>
		public override void CheckParameters(string[] parameterList)
		{
			if (parameterList.Length != 2)
			{
				throw new CommandException("Invalid number of parameters in " + ToString() + " :tri <width> <height>");
			}
		}
	}
}
