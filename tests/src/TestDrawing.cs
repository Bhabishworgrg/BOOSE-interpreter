using BOOSE.Main;
using BOOSE;
using System.Drawing;

namespace BOOSE.Tests
{
	/// <summary>
	/// Test class to check methods that draw on the canvas.
	/// </summary>
    [TestClass]
    public sealed class TestDrawing
    {
        private AppCanvas appCanvas;
        private Bitmap bitmap;
        private Color penColour;

		/// <summary>
		/// Creates a new instance of the canvas before each test. Also, gets the instance's bitmap and pen colour.
		/// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            appCanvas = new AppCanvas();
            bitmap = (Bitmap) appCanvas.getBitmap();
            penColour = (Color) appCanvas.PenColour;
        }

		/// <summary>
		/// Tests if the Clear method clears the canvas.
		/// It does so by checking if every pixel in the bitmap is white.
		/// </summary>
        [TestMethod]
        public void TestClear()
        {
            // Arrange
            int xPos, yPos;
            int expected = Color.White.ToArgb();

            // Act
            appCanvas.Clear();
            
			int actual(int xPos, int yPos)
			{
				return bitmap.GetPixel(xPos, yPos).ToArgb();
			}

            // Assert
            for (xPos = 0; xPos < bitmap.Width; xPos++)
            {
                for (yPos = 0; yPos < bitmap.Height; yPos++)
                {
                    Assert.AreEqual(expected, actual(xPos, yPos));
                }
            }
        }

		/// <summary>
		/// Tests if Circle method throws an exception when an invalid radius is passed.
		/// Invalid radius is any value less than or equal to zero.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Circle with radius zero.</para>
		/// <para>2. Circle with negative radius.</para>
		///	</remarks>
		///
		/// <param name="radius">The radius of the circle.</param>
        [TestMethod]
        [DataRow(0)]
        [DataRow(-100)]
        public void TestCircle_InvalidRadius(int radius)
        {
            // Arrange
            bool filled = false;
            string expected = $"Invalid radius in Circle {radius} :circle <radius>";

            // Act
            void Action()
			{
				appCanvas.Circle(radius, filled);
			}
			
			Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if Circle method draws a circle.
		/// It does so by checking if the colour of the pixels in the bitmap are the same as the pen colour.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Circle with positive radius.</para>
		/// </remarks>
		///
		/// <param name="radius">The radius of the circle.</param>
        [TestMethod]
        [DataRow(100)]
        public void TestCircle_ValidRadius(int radius)
        {
            // Arrange
            int xPos, yPos;
            double yPosDouble;
            bool filled = false;
            int expected = penColour.ToArgb();

            // Act
            appCanvas.Circle(radius, filled);
            
			int actual(int xPos, int yPos)
			{
				return bitmap.GetPixel(xPos, yPos).ToArgb();
			}

            // Assert
            for (xPos = 0; xPos <= radius; xPos++)
            {
                yPosDouble = Math.Sqrt((radius * radius) - (xPos * xPos));
                if (yPosDouble % 1 == 0)
                {
                    yPos = (int)yPosDouble;
                    Assert.AreEqual(expected, actual(xPos, yPos));
                }
            }
        }

		/// <summary>
		/// Tests if Rect method throws an exception when an invalid width is passed.
		/// Invalid width is any value less than or equal to zero.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Rectangle with width zero.</para>
		/// <para>2. Rectangle with negative width.</para>
		///	</remarks>
		///
		/// <param name="width">The width of the rectangle.</param>
        [TestMethod]
        [DataRow(0)]
        [DataRow(-100)]
        public void TestRect_InvalidWidth(int width)
        {
            // Arrange
            int height = 100;
            bool filled = false;
            string expected = $"Invalid width in Rect {width},{height} :rect <width>,<height>";

            // Act
            void Action()
			{
				appCanvas.Rect(width, height, filled);
			}

            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if Rect method throws an exception when an invalid height is passed.
		/// Invalid height is any value less than or equal to zero.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Rectangle with height zero.</para>
		/// <para>2. Rectangle with negative height.</para>
		/// </remarks>
		///
		/// <param name="height">The height of the rectangle.</param>
        [TestMethod]
        [DataRow(0)]
        [DataRow(-100)]
        public void TestRect_InvalidHeight(int height)
        {
            // Arrange
            int width = 100;
            bool filled = false;
            string expected = $"Invalid height in Rect {width},{height} :rect <width>,<height>";

            // Act
            void Action()
			{
				appCanvas.Rect(width, height, filled);
			}

			Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if Rect method throws an exception when both width and height are invalid.
		/// Invalid dimensions are any value less than or equal to zero.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Rectangle with width and height zero.</para>
		/// <para>2. Rectangle with negative width and height.</para>
		/// </remarks>
		///
		/// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
		[TestMethod]
        [DataRow(0, 0)]
        [DataRow(-100, -100)]
        public void TestRect_InvalidDimensions(int width, int height)
        {
            // Arrange
            bool filled = false;
            string expected = $"Invalid width and height in Rect {width},{height} :rect <width>,<height>";

            // Act
            void Action()
			{
				appCanvas.Rect(width, height, filled);
			}

			Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if Rect method draws a rectangle.
		/// It does so by checking if the colour of the pixels in the bitmap are the same as the pen colour.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Rectangle with positive width and height.</para>
		/// </remarks>
		///
		/// <param name="width">The width of the rectangle.</param>
		/// <param name="height">The height of the rectangle.</param>
        [TestMethod]
        [DataRow(100, 200)]
        public void TestRect_ValidDimensions(int width, int height)
        {
            // Arrange
            int xPos, yPos;
            bool filled = false;
            int expected = penColour.ToArgb();

            // Act
            appCanvas.Rect(width, height, filled);
            
			int actual(int xPos, int yPos)
			{
				return bitmap.GetPixel(xPos, yPos).ToArgb();
			}

            // Assert
            for (xPos = 0; xPos < width; xPos++)
            {
                Assert.AreEqual(expected, actual(xPos, 0));
                Assert.AreEqual(expected, actual(xPos, height));
            }

            for (yPos = 0; yPos < height; yPos++)
            {
                Assert.AreEqual(expected, actual(0, yPos));
                Assert.AreEqual(expected, actual(width, yPos));
            }
        }

		/// <summary>
		/// Tests if Tri method throws an exception when an invalid width is passed.
		/// Invalid width is any value less than or equal to zero.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Triangle with width zero.</para>
		/// <para>2. Triangle with negative width.</para>
		/// </remarks>
		///
		/// <param name="width">The width of the triangle.</param>
        [TestMethod]
        [DataRow(-100)]
        [DataRow(0)]
        public void TestTri_InvalidWidth(int width)
        {
            // Arrange
            int height = 100;
            string expected = $"Invalid width in Tri {width},{height} :tri <width>,<height>";

            // Act
            void Action()
			{
				appCanvas.Tri(width, height);
			}

			Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if Tri method throws an exception when an invalid height is passed.
		/// Invalid height is any value less than or equal to zero.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Triangle with height zero.</para>
		/// <para>2. Triangle with negative height.</para>
		/// </remarks>
		///
		/// <param name="height">The height of the triangle.</param>
        [TestMethod]
        [DataRow(-100)]
        [DataRow(0)]
        public void TestTri_InvalidHeight(int height)
        {
            // Arrange
            int width = 100;
            string expected = $"Invalid height in Tri {width},{height} :tri <width>,<height>";

            // Act
			void Action()
			{
				appCanvas.Tri(width, height);
			}

            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if Tri method throws an exception when both width and height are invalid.
		/// Invalid dimensions are any value less than or equal to zero.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Triangle with width and height zero.</para>
		/// <para>2. Triangle with negative width and height.</para>
		/// </remarks>
		///
		/// <param name="width">The width of the triangle.</param>
		/// <param name="height">The height of the triangle.</param>
        [TestMethod]
        [DataRow(-100, -100)]
        [DataRow(0, 0)]
        public void TestTri_InvalidDimensions(int width, int height)
        {
            // Arrange
            string expected = $"Invalid width and height in Tri {width},{height} :tri <width>,<height>";

            // Act
            void Action()
			{
				appCanvas.Tri(width, height);
			}
            
			Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
		/// Tests if Tri method draws a triangle.
		/// It does so by checking if the colour of pixels on vertices of the triangle are the same as the pen colour.
        /// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Triangle with positive width and height.</para>
		/// </remarks>
		///
		/// <param name="width">The width of the triangle.</param>
		/// <param name="height">The height of the triangle.</param>
		[TestMethod]
        [DataRow(100, 200)]
        public void TestTri_ValidDimensions(int width, int height)
        {
            // Arrange
            int expected = penColour.ToArgb();

            // Act
            appCanvas.Tri(width, height);
            int actual(int xPos, int yPos) => bitmap.GetPixel(xPos, yPos).ToArgb();

            // Assert
            Assert.AreEqual(expected, actual(width / 2, 0));
            Assert.AreEqual(expected, actual(0, height));
            Assert.AreEqual(expected, actual(width, height));
        }

		/// <summary>
		/// Tests if WriteText method executes without any errors.
		/// </summary>
		///
		/// <remarks>
		/// <para>Commands passed for the test:</para>
		/// <para>1. Empty string.</para>
		/// <para>2. Non-empty string.</para>
		/// </remarks>
		///
		/// <param name="text">The text to write on the canvas.</param>
		[TestMethod]
        [DataRow("")]
        [DataRow("Hello, World!")]
        public void TestWriteText(string text)
        {
            try
            {
                // Act
                appCanvas.WriteText(text);
            }
            catch (CanvasException ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }
        }
    }
}

