using System.Security.Principal;
using System.Diagnostics;

namespace MainProject
{
	public class CLISetup
	{
        public bool HasAdminRights()
        {
			try
			{
				using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
				{
					WindowsPrincipal principal = new WindowsPrincipal(identity);
					return principal.IsInRole(WindowsBuiltInRole.Administrator);
				}
			}
			catch (Exception ex)
			{
				return false;
			}
        }

        public void RestartAsAdmin()
        {
			ProcessModule? module = Process.GetCurrentProcess().MainModule;
			if (module == null)
			{
				return;
			}

			ProcessStartInfo startInfo = new ProcessStartInfo(module.FileName)
            {
				UseShellExecute = true,
                Verb = "runas"
            };

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
            }
        }

		public void CreateBatchFile(string filePath)
		{
			try
			{
				File.WriteAllText(
					filePath,
					$"@echo off\n\"{AppDomain.CurrentDomain.BaseDirectory}MainProject.exe\" %*"
				);
			}
			catch (Exception ex)
			{
			}
		}
	}
}
