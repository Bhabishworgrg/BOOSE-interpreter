using BOOSE;
using BOOSE.Interpreter;
using System.Drawing;

namespace BOOSE.Tests
{
	/// <summary>
	/// Test class to check execution of user input commands.
	/// </summary>
    [TestClass]
    public sealed class TestCommand
    {
        private MainForm mainForm;

		/// <summary>
		/// Creates a new instance of the main form before each test.
		/// </summary>
        [TestInitialize]
        public void TestInitialize()
		{
			mainForm = new MainForm();
		}

		/// <summary>
		/// Tests whether the interpreter can execute multiline commands.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Commands that span three lines.</para>
		/// <para>2. Commands that span three lines as well as have leading and trailing newlines.</para>
		/// </remarks>
		///
		/// <param name="multilineCommands">The multiline commands to execute.</param>
		/// <exception cref="Exception">An exception is thrown if the test fails.</exception>
        [TestMethod]
        [DataRow("circle 50\nmoveto 0,100\nrect 100, 200")]
        [DataRow("\ncircle 50\nmoveto 0,100\nrect 100, 200\n")]
        public void TestMultilineCommands(string multilineCommands)
        {
            try
            {
                // Act
                ICanvas canvas = new AppCanvas();
                Bitmap bitmap = (Bitmap) canvas.getBitmap();
                Interpreter interpreter = new Interpreter(canvas, bitmap);
                interpreter.ExecuteProgram(multilineCommands);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }
        }
    }
}

