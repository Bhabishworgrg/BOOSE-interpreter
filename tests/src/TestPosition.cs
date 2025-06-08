using BOOSE.Main;
using BOOSE;
using System.Drawing;

namespace BOOSE.Tests
{
	/// <summary>
	/// Test class to check the methods that change the position of the pen.
	/// </summary>
    [TestClass]
    public sealed class TestPosition
    {
        private AppCanvas appCanvas;
        
		/// <summary>
		/// Creates a new instance of the canvas before each test.
		/// </summary>
        [TestInitialize]
        public void TestInitialize()
		{
			appCanvas = new AppCanvas();
		}

		/// <summary>
		/// Tests if DrawTo method throws an exception when an invalid position is passed.
		/// Invalid position is when the x or y coordinate is out of bounds of the canvas.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Draw to a position with x-coordinate less than 0</para>
		/// <para>2. Draw to a position with y-coordinate less than 0</para>
		/// <para>3. Draw to a position with both x and y coordinates less than 0</para>
		/// <para>4. Draw to a position with x-coordinate greater than the width of the canvas</para>
		/// <para>5. Draw to a position with y-coordinate greater than the height of the canvas</para>
		/// <para>6. Draw to a position with both x and y coordinates greater than the width and height of the canvas</para>
		/// </remarks>
		///
		/// <param name="x">The x-coordinate to draw to.</param>
		/// <param name="y">The y-coordinate to draw to.</param>
        [TestMethod]
        [DataRow(-100, 100)]
        [DataRow(100, -100)]
        [DataRow(-100, -100)]
        [DataRow(1000, 100)]
        [DataRow(100, 1000)]
        [DataRow(1000, 1000)]
        public void TestDrawTo_InvalidPosition(int x, int y)
        {
            // Arrange
            string expected = $"Invalid position in DrawTo {x},{y} :drawto <x>,<y>";

            // Act
            void Action()
			{
				appCanvas.DrawTo(x, y);
			}

            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if DrawTo method sets the position of the pen to a valid position.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Draw to a position with x and y coordinates within the bounds of the canvas</para>
		/// <para>2. Draw to the origin of the canvas</para>
		/// </remarks>
		///
		/// <param name="x">The x-coordinate to draw to.</param>
		/// <param name="y">The y-coordinate to draw to.</param>
        [TestMethod]
        [DataRow(200, 300)]
        [DataRow(0, 0)]
        public void TestDrawTo_ValidPosition(int x, int y)
        {
            // Arrange
            Point expected = new Point(x, y);

            // Act
            appCanvas.DrawTo(x, y);
            Point actual = new Point(appCanvas.Xpos, appCanvas.Ypos);

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if MoveTo method throws an exception when an invalid position is passed.
		/// Invalid position is when the x or y coordinate is out of bounds of the canvas.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Move to a position with x-coordinate less than 0</para>
		/// <para>2. Move to a position with y-coordinate less than 0</para>
		/// <para>3. Move to a position with both x and y coordinates less than 0</para>
		/// <para>4. Move to a position with x-coordinate greater than the width of the canvas</para>
		/// <para>5. Move to a position with y-coordinate greater than the height of the canvas</para>
		/// <para>6. Move to a position with both x and y coordinates greater than the width and height of the canvas</para>
		/// </remarks>
		///
		/// <param name="x">The x-coordinate to move the pen to.</param>
		/// <param name="y">The y-coordinate to move the pen to.</param>
        [TestMethod]
        [DataRow(-100, 100)]
        [DataRow(100, -100)]
        [DataRow(-100, -100)]
        [DataRow(1000, 100)]
        [DataRow(100, 1000)]
        [DataRow(1000, 1000)]
        public void TestMoveTo_InvalidPosition(int x, int y)
        {
            // Arrange
            string expected = $"Invalid position in MoveTo {x},{y} :moveto <x>,<y>";

            // Act
            void Action()
			{
				appCanvas.MoveTo(x, y);
			}

            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if MoveTo method sets the position of the pen to a valid position.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Move to a position with x and y coordinates within the bounds of the canvas</para>
		/// <para>2. Move to the origin of the canvas</para>
		/// </remarks>
		///
		/// <param name="x">The x-coordinate to move the pen to.</param>
		/// <param name="y">The y-coordinate to move the pen to.</param>
        [TestMethod]
        [DataRow(200, 300)]
        [DataRow(0, 0)]
        public void TestMoveTo_ValidPosition(int x, int y)
        {
            // Arrange
            Point expected = new Point(x, y);

            // Act
            appCanvas.MoveTo(x, y);
            Point actual = new Point(appCanvas.Xpos, appCanvas.Ypos);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

