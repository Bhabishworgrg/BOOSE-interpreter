using BOOSE;

namespace ASEAssignment
{
    public partial class MainForm : Form
    {
        ICanvas canvas;
        CommandFactory commandFactory;
        StoredProgram storedProgram;
        Parser parser;

        public MainForm()
        {
            InitializeComponent();
            canvas = new AppCanvas();
            commandFactory = new ExtendedCommandFactory();
            storedProgram = new StoredProgram(canvas);
            parser = new Parser(commandFactory, storedProgram);
		}

        private void picbox_output_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
			Bitmap bm = (Bitmap)canvas.getBitmap();
            graphics.DrawImageUnscaled(bm, 0, 0);
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            String input = txtbox_input.Text;
			parser.ParseProgram(input);
			storedProgram.Run();
			Refresh();
		}
    }
}
