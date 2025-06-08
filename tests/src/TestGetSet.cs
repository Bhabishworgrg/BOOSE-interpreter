using BOOSE.Interpreter;
using BOOSE;
using System.Drawing;

namespace BOOSE.Tests
{
	/// <summary>
	/// Test class to check the methods that get and set the properties of the canvas.
    /// </summary>
	[TestClass]
    public sealed class TestGetSet
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
		/// Tests if getBitmap method returns a bitmap object.
		/// </summary>
        [TestMethod]
        public void TestGetBitmap()
        {
            // Arrange
            Type expected = typeof(Bitmap);

            // Act
            Object actual = appCanvas.getBitmap();

            // Assert
            Assert.IsInstanceOfType(actual, expected);
        }

		/// <summary>
		/// Tests if Reset method resets the canvas to its default state.
		/// Default state is when the pen is at position (0, 0) and the pen colour is black.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Move pen to default position and set a different pen colour</para>
		/// <para>2. Move pen to a different place and set a different pen colour</para>
		/// </remarks>
		///
		/// <param name="x">The x-coordinate to move the pen to.</param>
		/// <param name="y">The y-coordinate to move the pen to.</param>
		[TestMethod]
        [DataRow(0, 0)]
        [DataRow(200, 300)]
        public void TestReset(int x, int y)
        {
            // Arrange
            Color newPenColour = Color.Red;

            Point expectedPosition = new Point(0, 0);
            Color expectedPenColour = Color.Black;

            // Act
            appCanvas.MoveTo(x, y);
            appCanvas.PenColour = newPenColour;
            appCanvas.Reset();
            Point actualPosition = new Point(appCanvas.Xpos, appCanvas.Ypos);
            Color actualPenColour = (Color)appCanvas.PenColour;

            // Assert
            Assert.AreEqual(expectedPosition, actualPosition);
            Assert.AreEqual(expectedPenColour, actualPenColour);
        }

		/// <summary>
		/// Tests if Set method throws an exception when the width of the canvas is invalid.
		/// Invalid width is when the width is less than or equal to zero.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. The width to negative values.</para>
		/// <para>2. The width to zero.</para>
		/// </remarks>
		///
		/// <param name="width">The width of the canvas.</param>
        [TestMethod]
        [DataRow(-100)]
        [DataRow(0)]
        public void TestSet_InvalidWidth(int width)
        {
            // Arrange
            int height = 100;
            string expected = $"Invalid width in Set {width},{height} :set <width>,<height>";

            // Act
            void Action()
			{
				appCanvas.Set(width, height);
			}

            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if Set method throws an exception when the height of the canvas is invalid.
		/// Invalid height is when the height is less than or equal to zero.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. The height to negative values.</para>
		/// <para>2. The height to zero.</para>
		/// </remarks>
		///
		/// <param name="height">The height of the canvas.</param>
        [TestMethod]
        [DataRow(-100)]
        [DataRow(0)]
        public void TestSet_InvalidHeight(int height)
        {
            // Arrange
            int width = 100;
            string expected = $"Invalid height in Set {width},{height} :set <width>,<height>";

            // Act
            void Action()
			{
				appCanvas.Set(width, height);
			}

            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }
		
		/// <summary>
		/// Tests if Set method throws an exception when both the width and height of the canvas are invalid.
		/// Invalid dimensions are when they are less than or equal to zero.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. The width and height to negative values.</para>
		/// <para>2. The width and height to zero.</para>
		/// </remarks>
		///
		/// <param name="width">The width of the canvas.</param>
		/// <param name="height">The height of the canvas.</param>
        [TestMethod]
        [DataRow(-100, -100)]
        [DataRow(0, 0)]
        public void TestSet_InvalidDimensions(int width, int height)
        {
            // Arrange
            string expected = $"Invalid width and height in Set {width},{height} :set <width>,<height>";

            // Act
            void Action()
			{
				appCanvas.Set(width, height);
			}

            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if Set method sets the width and height of the canvas to valid values.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. The width and height to positive values.</para>
		/// </remarks>
		///
		/// <param name="width">The width of the canvas.</param>
		/// <param name="height">The height of the canvas.</param>
        [TestMethod]
        [DataRow(100, 200)]
        public void TestSet_ValidDimensions(int width, int height)
        {
            // Arrange
            int expectedWidth = width;
            int expectedHeight = height;

            // Act
            appCanvas.Set(width, height);
            int actualWidth = appCanvas.DisplayWidth;
            int actualHeight = appCanvas.DisplayHeight;

            // Assert
            Assert.AreEqual(width, actualWidth);
            Assert.AreEqual(height, actualHeight);
        }

		/// <summary>
		/// Tests if SetColour method throws an exception when the colour is invalid.
		/// Invalid colour is when any of the RGB values are less than zero or greater than 255.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. The red value less than 0.</para>
		/// <para>2. The green value less than 0.</para>
		/// <para>3. The blue value less than 0.</para>
		/// <para>4. All RGB values less than 0.</para>
		/// <para>5. The red value greater than 255.</para>
		/// <para>6. The green value greater than 255.</para>
		/// <para>7. The blue value greater than 255.</para>
		/// <para>8. All RGB values greater than 255.</para>
		/// </remarks>
		///
		/// <param name="red">The red value of the colour.</param>
		/// <param name="green">The green value of the colour.</param>
		/// <param name="blue">The blue value of the colour.</param>
        [TestMethod]
        [DataRow(-100, 100, 100)]
        [DataRow(100, -100, 100)]
        [DataRow(100, 100, -100)]
        [DataRow(-100, -100, -100)]
        [DataRow(1000, 100, 100)]
        [DataRow(100, 1000, 100)]
        [DataRow(100, 100, 1000)]
        [DataRow(1000, 1000, 1000)]
        public void TestSetColour_InvalidColour(int red, int green, int blue)
        {
            // Arrange
            string expected = $"Invalid colour in SetColour {red},{green},{blue} :setcolour <red>,<green>,<blue>";

            // Act
            void Action()
			{
				appCanvas.SetColour(red, green, blue);
			}

            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if SetColour method sets the colour of the pen to a valid colour.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. The red, green and blue values to 0.</para>
		/// <para>2. The red, green and blue values to positive values.</para>
		/// <para>3. The red, green and blue values to 255.</para>
		/// </remarks>
		///
		/// <param name="red">The red value of the colour.</param>
		/// <param name="green">The green value of the colour.</param>
		/// <param name="blue">The blue value of the colour.</param>
        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(50, 100, 150)]
        [DataRow(255, 255, 255)]
        public void TestSetColour_ValidColour(int red, int green, int blue)
        {
            // Arrange
            Color expected = Color.FromArgb(red, green, blue);

            // Act
            appCanvas.SetColour(red, green, blue);
            Color actual = (Color)appCanvas.PenColour;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

