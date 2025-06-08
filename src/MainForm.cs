using BOOSE;

namespace BOOSE.Main
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
        private Interpreter interpreter;

		/// <summary>
		/// Constructor for the main form.
		/// </summary>
        public MainForm()
        {
            InitializeComponent();

            canvas = new AppCanvas();
            bitmap = (Bitmap) canvas.getBitmap();
            interpreter = new Interpreter(canvas, bitmap);
			
			Console.WriteLine("BOOSE interpreter started.");
			Console.WriteLine(AboutBOOSE.about());
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
                interpreter.ExecuteProgram(txtbox_input.Text);
				Refresh();
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

    }
}
