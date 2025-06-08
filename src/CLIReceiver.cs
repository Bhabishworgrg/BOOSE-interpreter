using BOOSE;
using System.Diagnostics;

namespace BOOSE.Main
{
    /// <summary>
    /// Represents the receiver in the command design pattern, containing the actual logic for CLI operations.
    /// </summary>
    public class CLIReceiver
    {
        /// <summary>
        /// Displays help information for using the BOOSE application.
        /// </summary>
        public void CLIHelp()
        {
            Console.Write(
				"Usage: BOOSE [options] [source files]\n" +
                "options:\n" +
                "\t-h\tShow this help message\n" +
                "\t-v\tShow version information\n" +
                "\t-i\tCreate an empty boose project\n" +
                "\t-g\tOpen GUI mode\n"
			);
		}

        /// <summary>
        /// Displays version information about the BOOSE application.
        /// </summary>
        public void CLIVersion()
        {
            Console.Write(AboutBOOSE.about());
        }

        /// <summary>
        /// Creates an empty BOOSE project and notifies the user.
        /// </summary>
        public void CLIInit()
        {
            Console.WriteLine("Creating an empty BOOSE project...");
			
			string mainDir = "BOOSE Project";
			string[] dirs = ["src", "build"];
			
			Dictionary<string, string> files = new Dictionary<string, string>()
			{
				{"src\\program.boose", "write \"hello world\""},
				{".gitignore", "build/"},
				{"README.md", "This is an empty BOOSE project.\nSource files go in the src and output images go in the build. Run make.bat to build the image."},
				{"make.bat", "boose src\\program.boose"}
			};

			Directory.CreateDirectory(mainDir);
			
			foreach (string dir in dirs)
			{
				Directory.CreateDirectory($"{mainDir}\\{dir}");
			}
			
			foreach (KeyValuePair<string, string> f in files)
			{
				File.WriteAllText($"{mainDir}\\{f.Key}", f.Value);
			}

			ProcessStartInfo gitInit = new ProcessStartInfo("git", "init")
			{
				WorkingDirectory = mainDir,
				RedirectStandardError = true,
				RedirectStandardOutput = true,
				UseShellExecute = false
			};

			try
			{
				Process.Start(gitInit);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to initialize git repository: {ex.Message}");
			}

			Console.WriteLine("Empty BOOSE project created.");
        }

        /// <summary>
        /// Launches the GUI mode for the BOOSE application.
        /// </summary>
        public void CLIGUI()
        {
			Program.RunGUIBOOSE();
        }

        /// <summary>
        /// Generates an image and notifies the user upon completion.
        /// </summary>
        public void CLIGenerate(string fileName)
        {
            Console.WriteLine("Generating image...");
			
			string program = File.ReadAllText(fileName);
			ICanvas canvas = new AppCanvas();
			Bitmap bitmap = (Bitmap) canvas.getBitmap();
			Interpreter interpreter = new Interpreter(canvas, bitmap);
			
			interpreter.ExecuteProgram(program);
			
			if (Directory.Exists("build"))
			{
				Console.WriteLine("Image generated in build directory.");
				interpreter.BuildImage("build\\output.png");
			}
			else
			{
				Console.WriteLine("No build directory found. Generating image to current directory.");
				interpreter.BuildImage("output.png");
			}
        }
    }
}
