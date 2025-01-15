namespace MainProject
{
	public class CLIGUI : ICLICommand
	{
		private CLIReceiver receiver;

		public CLIGUI(CLIReceiver receiver)
		{
			this.receiver = receiver;
		}

		public void Execute()
		{
			receiver.CLIGUI();
		}
	}
}
