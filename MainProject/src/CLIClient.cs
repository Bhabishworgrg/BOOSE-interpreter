namespace MainProject
{
	public class CLIClient
	{
		public void Run(string option)
		{
			CLIReceiver receiver = new CLIReceiver();
			
			ICLICommand command = null;
			switch (option)
			{
				case "-h":
					command = new CLIHelp(receiver);
					break;
				case "-v":
					command = new CLIVersion(receiver);
					break;
				case "-i":
					command = new CLIInit(receiver);
					break;
				case "-g":
					command = new CLIGUI(receiver);
					break;
				default:
					command = new CLIGenerate(receiver);
					break;
			}

			CLIInvoker invoker = new CLIInvoker();
			invoker.SetCommand(command);
			invoker.ExecuteCommand();
		}
	}
}
