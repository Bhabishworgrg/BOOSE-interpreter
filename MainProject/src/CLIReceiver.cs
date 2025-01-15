using BOOSE;

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
			Console.WriteLine("Empty BOOSE project created.");
		}
	}
}
