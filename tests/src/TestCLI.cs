using BOOSE.Interpreter;

namespace BOOSE.Tests
{
    /// <summary>
    /// Test class to check execution of CLI BOOSE commands.
    /// </summary>
    [TestClass]
    public sealed class TestCLI
    {
        CLIReceiver cliReceiver;

        /// <summary>
        /// Creates a new instance of the CLI receiver before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            cliReceiver = new CLIReceiver();
        }

        /// <summary>
        /// Tests whether the CLI receiver can display help information.
        /// </summary>
        [TestMethod]
        public void TestCLIHelp()
        {
            try
            {
                // Act
                cliReceiver.CLIHelp();
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Tests whether the CLI receiver can display version information.
        /// </summary>
        [TestMethod]
        public void TestCLIVersion()
        {
            try
            {
                // Act
                cliReceiver.CLIVersion();
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Tests whether the CLI receiver can display the GUI interface.
        /// </summary>
        [TestMethod]
        public void TestCLIGUI()
        {
            try
            {
                // Act
                cliReceiver.CLIGUI();
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Tests whether the CLI receiver can generate output.
        /// </summary>
        [TestMethod]
        public void TestCLIGenerate()
        {
            // Arrange
            string fileName = "test.boose";
            File.Create(fileName).Close();

            try
            {
                // Act
                cliReceiver.CLIGenerate(fileName);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Tests whether the CLI receiver can initialize a new BOOSE project.
        /// </summary>
        [TestMethod]
        public void TestCLIInit()
        {
            try
            {
                // Act
                cliReceiver.CLIInit();
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }
        }
    }
}
