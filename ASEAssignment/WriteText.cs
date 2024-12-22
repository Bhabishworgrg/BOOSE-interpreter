using BOOSE;

namespace ASEAssignment
{
	public class WriteText : CommandOneParameter
	{
		private string text;

		public WriteText() {}

		public WriteText(Canvas canvas, string text) : base(canvas)
		{
			this.text = text;
		}

		public override void Execute()
		{
			text = Parameters[0];
			base.Canvas.WriteText(text);
		}

        public override void CheckParameters(string[] parameterList)
        {
			if (parameterList.Length != 1)
			{
				throw new CommandException("Invalid number of parameters in " + ToString() + " :write <text>");
			}
        }
    
	}
}
