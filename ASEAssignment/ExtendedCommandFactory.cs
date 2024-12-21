using BOOSE;

namespace ASEAssignment
{
	public class ExtendedCommandFactory : CommandFactory
	{
        public override ICommand MakeCommand(string commandType)
        {
			commandType = commandType.ToLower().Trim();
			switch (commandType)
			{
				case "write":
					return new WriteText();
				case "tri":
					return new Tri();
			}

            return (base.MakeCommand(commandType));
        }
    
	}
}
