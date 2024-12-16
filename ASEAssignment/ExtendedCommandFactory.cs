using BOOSE;

namespace ASEAssignment
{
	public class ExtendedCommandFactory : CommandFactory
	{
        public override ICommand MakeCommand(string commandType)
        {
			commandType = commandType.ToLower().Trim();
			if (commandType == "write")
			{
				return new WriteText();
			}

            return (base.MakeCommand(commandType));
        }
    
	}
}
