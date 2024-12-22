using BOOSE;

namespace ASEAssignment
{
	public class Tri : CommandTwoParameters
	{
		private int width, height;

		public Tri() {}

		public Tri(Canvas canvas, int width, int height) : base(canvas)
		{
			this.width = width;
			this.height = height;
		}

		public override void Execute()
		{
			base.Execute();
			width = Paramsint[0];
			height = Paramsint[1];
			base.Canvas.Tri(width, height);
		}

		public override void CheckParameters(string[] parameterList)
		{
			if (parameterList.Length != 2)
			{
				throw new CommandException("Invalid number of parameters in " + ToString() + " :tri <width> <height>");
			}
		}
	}
}
