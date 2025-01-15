namespace MainProject
{
	public class CLIInvoker
	{
		private ICLICommand command;

		public void SetCommand(ICLICommand command)
		{
			this.command = command;
		}

		public void ExecuteCommand()
		{
			if (command != null)
			{
				command.Execute();
			}
		}
	}
}
