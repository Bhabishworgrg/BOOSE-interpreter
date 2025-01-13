using BOOSE;
using System.Text.RegularExpressions;

namespace MainProject
{
    public class UnrestrictedParser : IParser
    {
		private ICommandFactory commandFactory;
		private StoredProgram storedProgram;

		public UnrestrictedParser(CommandFactory commandFactory, StoredProgram storedProgram)
		{
			this.commandFactory = commandFactory;
			this.storedProgram = storedProgram;
		}

		public ICommand? ParseCommand(string line)
		{
			if (line[0] == '*')
			{
				return null;
			}

			line = line.Trim();
			line = line.Replace("+", " + ");
			line = line.Replace("*", " * ");
			line = line.Replace("/", " / ");

			// Add spaces around minus signs that are subtraction operators.
			// Ignore minus signs that are part of negative numbers.
			line = Regex.Replace(line, @"(?<=\S)-", " - ");

			string[] elements = line.Split(' ');
			string commandType = elements[0];
			string parameters = line[commandType.Length..].Trim();
			
			if (elements.Length >= 2 && elements[1] == "=")
			{
				parameters = $"{commandType} {parameters.Trim()}";
				
				Evaluation variable = storedProgram.GetVariable(commandType);

				switch (variable)
				{
					case UnrestrictedInt:
						commandType = "int";
						break;
					case UnrestrictedReal:
						commandType = "real";
						break;
				}
			}

			ICommand command = commandFactory.MakeCommand(commandType);
			command.Set(storedProgram, parameters);
			command.Compile();
			
			return command;
		}

        public void ParseProgram(string storedProgram)
        {
			string[] lines = storedProgram.Split('\n');
			for (int lineNo = 1; lineNo < lines.Length + 1; lineNo++)
			{
				string line = lines[lineNo - 1].Trim();
				
				if (line ==	"")
				{
					continue;
				}

				try
				{
					ICommand? command = ParseCommand(line);
				}
				catch (BOOSEException ex)
				{
					throw new ParserException($"{ex.Message} at line {lineNo}.");
				}
			}
		}
    }
}
