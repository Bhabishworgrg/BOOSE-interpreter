namespace MainProject
{
	public class CLIGenerate : ICLICommand
	{
		private CLIReceiver receiver;

		public CLIGenerate(CLIReceiver receiver)
		{
			this.receiver = receiver;
		}

		public void Execute()
		{
			receiver.CLIGenerate();
		}
	}
}
