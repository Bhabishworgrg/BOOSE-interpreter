using BOOSE;

namespace MainProject
{
	/// <summary>
	/// Represents the interpreter for the BOOSE language.
	/// </summary>
	public class Interpreter
	{
		private Bitmap bitmap;
		private CommandFactory commandFactory;
        private StoredProgram storedProgram;
        private IParser parser;
	
		/// <summary>
		/// Initializes a new instance of the <see cref="Interpreter"/> class.
		/// </summary>
		///
		/// <param name="canvas">The canvas to draw on.</param>
		/// <param name="bitmap">The bitmap to draw on.</param>
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

		/// <summary>
		/// Builds the image to the specified path.
		/// </summary>
		///
		/// <param name="path">The path to save the image to.</param>
		public void BuildImage(string path)
		{
			bitmap.Save(path);
		}
	}
}
