using System.Security.Principal;
using System.Diagnostics;

namespace MainProject
{
    /// <summary>
    /// Provides methods for checking administrative rights and restarting the application with administrative privileges.
    /// </summary>
    public class CLISetup
    {
        /// <summary>
        /// Checks if the current process has administrative rights.
        /// </summary>
        /// 
		/// <returns>True if the current process is running with administrative rights, otherwise false.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while checking for administrative rights.</exception>
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
                Console.WriteLine($"Failed to check for administrative rights: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Restarts the current application with administrative privileges.
        /// </summary>
		///
        /// <exception cref="Exception">Thrown if an error occurs while restarting the application.</exception>
        public void RestartAsAdmin()
        {
            ProcessModule? module = Process.GetCurrentProcess().MainModule;
            if (module == null)
            {
                Console.WriteLine("Failed to restart as administrator: Could not get main module.");
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
                Console.WriteLine($"Failed to restart as administrator: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a batch file that launches the application with command-line arguments.
        /// </summary>
		///
        /// <param name="filePath">The full path to the batch file to create.</param>
        /// <exception cref="Exception">Thrown if an error occurs while creating the batch file.</exception>
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
                Console.WriteLine($"Failed to create {filePath}: {ex.Message}");
            }
        }
    }
}
