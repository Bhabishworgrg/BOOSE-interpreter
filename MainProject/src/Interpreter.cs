using BOOSE;

namespace MainProject
{
	public class Interpreter
	{
		private Bitmap bitmap;
		private CommandFactory commandFactory;
        private StoredProgram storedProgram;
        private IParser parser;
		
		public Interpreter(ICanvas canvas, Bitmap bitmap)
		{
			this.bitmap = bitmap;
			commandFactory = new ExtendedCommandFactory();
			storedProgram = new UnrestrictedStoredProgram(canvas);
			parser = new UnrestrictedParser(commandFactory, storedProgram);
		}

		/// <summary>
		/// Executes the input program to returns the output image.
		/// </summary>
		///
		/// <param name="input">The program to execute.</param>
		/// <returns>The output image of the program.</returns>
		public void ExecuteProgram(string input)
        {
			storedProgram.ResetProgram();
            parser.ParseProgram(input);
            storedProgram.Run();
        }

		public void BuildImage(string path)
		{
			bitmap.Save(path);
		}
	}
}
