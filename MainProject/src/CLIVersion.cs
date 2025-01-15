namespace MainProject
{
	public class CLIVersion : ICLICommand
	{
		private CLIReceiver receiver;

		public CLIVersion(CLIReceiver receiver)
		{
			this.receiver = receiver;
		}

		public void Execute()
		{
			receiver.CLIVersion();
		}
	}
}
