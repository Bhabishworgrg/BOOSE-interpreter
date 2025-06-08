using BOOSE;
using System.Text.RegularExpressions;

namespace MainProject
{
    /// <summary>
    /// A parser that interprets and parses unrestricted commands in the BOOSE language.
    /// </summary>
	///
	/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.IParser.html">
	/// BOOSE.IParser
	/// </seealso>
    public class UnrestrictedParser : IParser
    {
        private ICommandFactory commandFactory;
        private StoredProgram storedProgram;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnrestrictedParser"/> class.
        /// </summary>
        /// 
		/// <param name="commandFactory">The command factory used to create commands.</param>
        /// <param name="storedProgram">The stored program to retrieve variables and manage the program state.</param>
        public UnrestrictedParser(CommandFactory commandFactory, StoredProgram storedProgram)
        {
            this.commandFactory = commandFactory;
            this.storedProgram = storedProgram;
        }

        /// <summary>
        /// Parses a single line of the program and returns the corresponding command.
        /// </summary>
        /// 
		/// <param name="line">The line of code to parse.</param>
        /// <returns>The parsed command, or null if the line is a comment.</returns>
        public ICommand? ParseCommand(string line)
        {
            if (line[0] == '*')
            {
                return null; // Comment line, skip it
            }

            line = line.Trim();
            line = line.Replace("+", " + ");
            line = line.Replace("*", " * ");
            line = line.Replace("/", " / ");

            // To only replace the subtraction operator and not the negative sign.
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
					default:
						throw new ParserException("Invalid variable type");
                }
            }

            ICommand command = commandFactory.MakeCommand(commandType);
            command.Set(storedProgram, parameters);
            command.Compile();

            return command;
        }

        /// <summary>
        /// Parses the entire program and executes each line as a command.
        /// </summary>
        ///
		/// <param name="storedProgram">The program to parse, containing multiple lines of code.</param>
        /// <exception cref="ParserException">Thrown when an error occurs while parsing the program.</exception>
        public void ParseProgram(string storedProgram)
        {
            storedProgram += "\nint endofprogram = 0";

            string[] lines = storedProgram.Split('\n');
            for (int lineNo = 1; lineNo < lines.Length + 1; lineNo++)
            {
                string line = lines[lineNo - 1].Trim();

                if (line == "")
                {
                    continue; // Skip empty lines
                }

                try
                {
                    ICommand? command = ParseCommand(line);
					
					if (command is UnrestrictedMethod && command != null)
                    {
                        UnrestrictedMethod method = (UnrestrictedMethod) command;
                        command = ParseCommand($"{method.Type} {method.MethodName}");
                        this.storedProgram.Remove(command);
                        
                        foreach (string variable in method.LocalVariables)
                        {
                            command = ParseCommand(variable);
                            ((Evaluation) command!).Local = true;
                            this.storedProgram.Remove(command);
                        }
                    }
                }
                catch (BOOSEException ex)
                {
                    throw new ParserException($"{ex.Message} at line {lineNo}.");
                }
            }
        }
    }
}
