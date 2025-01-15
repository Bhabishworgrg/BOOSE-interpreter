namespace MainProject
{
	public class CLIHelp : ICLICommand
	{
		private CLIReceiver receiver;

		public CLIHelp(CLIReceiver receiver)
		{
			this.receiver = receiver;
		}

		public void Execute()
		{
			receiver.CLIHelp();
		}
	}
}
