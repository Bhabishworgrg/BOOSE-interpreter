namespace MainProject
{
	public class CLIInit : ICLICommand
	{
		private CLIReceiver receiver;

		public CLIInit(CLIReceiver receiver)
		{
			this.receiver = receiver;
		}

		public void Execute()
		{
			receiver.CLIInit();
		}
	}
}
