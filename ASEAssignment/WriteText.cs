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
	}
}
