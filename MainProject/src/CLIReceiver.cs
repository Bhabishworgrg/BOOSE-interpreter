using BOOSE;
using System.Diagnostics;

namespace MainProject
{
    public class CLIReceiver
    {
        public void CLIHelp()
        {
            Console.WriteLine("Usage: BOOSE [options] [source files]");
            Console.WriteLine("options:");
            Console.WriteLine("\t-h\tShow this help message");
            Console.WriteLine("\t-v\tShow version information");
            Console.WriteLine("\t-i\tCreate an empty boose project");
            Console.WriteLine("\t-g\tOpen GUI mode");
        }

        public void CLIVersion()
        {
            Console.WriteLine(AboutBOOSE.about());
        }

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
				{"make.bat", "boose src\\*.boose"}
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
