using BOOSE;

namespace MainProject
{
	/// <summary>
	/// Main form of the interpreter.
	/// </summary>
	///
	/// <seealso cref="System.Windows.Forms.Form"/>
    public partial class MainForm : Form
    {
        private ICanvas canvas;
		private Bitmap bitmap;
		private CommandFactory commandFactory;
        private StoredProgram storedProgram;
        private IParser parser;
		
		/// <summary>
		/// Constructor for the main form.
		/// </summary>
        public MainForm()
        {
            InitializeComponent();

			canvas = new AppCanvas();
			bitmap = (Bitmap) canvas.getBitmap();
			commandFactory = new ExtendedCommandFactory();
            storedProgram = new UnrestrictedStoredProgram(canvas);
            parser = new UnrestrictedParser(commandFactory, storedProgram);
		}

		/// <summary>
		/// Repaints the picture box <c>picbox_output</c> when the interpreter is run.
		/// </summary>
		/// 
		/// <param name="sender">Source of the event i.e. <c>picbox_output</c>.</param>
		/// <param name="e">Arguments for the event.</param>
        private void picbox_output_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImageUnscaled(bitmap, 0, 0);
        }

        /// <summary>
        /// Runs the interpreter to display the output.
        /// </summary>
		///
        /// <param name="sender">Source of the event i.e. <c>btn_run</c>.</param>
        /// <param name="e">Arguments for the event.</param>
		/// <exception cref="Exception">Thrown when there is an error in the user input command.</exception>
        private void btn_run_Click(object sender, EventArgs e)
        {
            try
            {
                ExecuteCommand(txtbox_input.Text);
            }
            catch (BOOSEException ex)
            {
                MessageBox.Show(
						ex.Message,
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
						);
            }
        }

		/// <summary>
		/// Executes the input command to display the output.
		/// </summary>
		///
		/// <param name="input">Input command to execute.</param>
        public void ExecuteCommand(string input)
        {
			storedProgram.ResetProgram();
            parser.ParseProgram(input);
            storedProgram.Run();
            Refresh();
        }
    }
}
