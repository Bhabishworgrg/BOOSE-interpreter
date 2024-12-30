using MainProject;
using BOOSE;
using System.Drawing;

namespace TestProject
{
    [TestClass]
    public sealed class TestCommand
    {
        private MainForm mainForm;

        [TestInitialize]
        public void TestInitialize() => mainForm = new MainForm();

        [TestMethod]
        [DataRow("circle 50\nmoveto 0,100\nrect 100, 200")]
        [DataRow("\ncircle 50\nmoveto 0,100\nrect 100, 200\n")]
        public void TestMultilineCommands(string multilineCommands)
        {
            try
            {
                // Act
                mainForm.ExecuteCommand(multilineCommands);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }
        }
    }
}

