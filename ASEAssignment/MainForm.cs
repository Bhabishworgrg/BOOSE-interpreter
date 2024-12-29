using BOOSE;

namespace ASEAssignment
{
	/// <summary>
	/// Main form of the interpreter.
	/// </summary>
	///
	/// <seealso cref="System.Windows.Forms.Form"/>
    public partial class MainForm : Form
    {
        private ICanvas canvas;
		private CommandFactory commandFactory;
        private StoredProgram storedProgram;
        private Parser parser;

		/// <summary>
		/// Constructor for the main form.
		/// </summary>
        public MainForm()
        {
            InitializeComponent();

			canvas = new AppCanvas();
			commandFactory = new ExtendedCommandFactory();
            storedProgram = new StoredProgram(canvas);
            parser = new Parser(commandFactory, storedProgram);
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
			Bitmap bm = (Bitmap)canvas.getBitmap();
            graphics.DrawImageUnscaled(bm, 0, 0);
        }

        /// <summary>
        /// Runs the interpreter to display the output.
        /// </summary>
		///
        /// <param name="sender">Source of the event i.e. <c>btn_run</c>.</param>
        /// <param name="e">Arguments for the event.</param>
        private void btn_run_Click(object sender, EventArgs e)
        {
            try
            {
                String input = txtbox_input.Text;
                parser.ParseProgram(input);
                storedProgram.Run();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
