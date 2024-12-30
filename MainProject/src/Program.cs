using System.Diagnostics;
using BOOSE;

namespace MainProject
{
    /// <summary>
    /// The driver class for the application.
    /// </summary>
    public static class Program
    {
        private static MainForm mainForm = new MainForm();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Debug.WriteLine(AboutBOOSE.about());

            ApplicationConfiguration.Initialize();
            // Get the size of active screen so that form can fill the whole screen. Also consider the taskbar.
            //	Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            //	mainForm.Width = screen.Width;
            //	mainForm.Height = screen.Height;
            //	mainForm.StartPosition = FormStartPosition.Manual;
            //	mainForm.SetBounds(screen.X, screen.Y, screen.Width, screen.Height);

            Application.Run(mainForm);
        }

        /// <summary>
        /// Get the main form of the application.
        /// </summary>
        public static MainForm MainForm => mainForm;
    }
}
