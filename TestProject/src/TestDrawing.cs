using MainProject;
using BOOSE;
using System.Drawing;

namespace TestProject
{
    [TestClass]
    public sealed class TestDrawing
    {
        private AppCanvas appCanvas;
        private Bitmap bitmap;
        private Color penColour;

        [TestInitialize]
        public void TestInitialize()
        {
            appCanvas = new AppCanvas();
            bitmap = (Bitmap)appCanvas.getBitmap();
            penColour = (Color)appCanvas.PenColour;
        }

        [TestMethod]
        public void TestClear()
        {
            // Arrange
            int xPos, yPos;
            int expected = Color.White.ToArgb();

            // Act
            appCanvas.Clear();
            int actual(int xPos, int yPos) => bitmap.GetPixel(xPos, yPos).ToArgb();

            // Assert
            for (xPos = 0; xPos < bitmap.Width; xPos++)
            {
                for (yPos = 0; yPos < bitmap.Height; yPos++)
                {
                    Assert.AreEqual(expected, actual(xPos, yPos));
                }
            }
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-100)]
        public void TestCircle_InvalidRadius(int radius)
        {
            // Arrange
            bool filled = false;
            string expected = $"Invalid radius in Circle {radius} :circle <radius>";

            // Act
            void Action() => appCanvas.Circle(radius, filled);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

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
            int actual(int xPos, int yPos) => bitmap.GetPixel(xPos, yPos).ToArgb();

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
            void Action() => appCanvas.Rect(width, height, filled);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

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
            void Action() => appCanvas.Rect(width, height, filled);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(-1, -1)]
        public void TestRect_InvalidDimensions(int width, int height)
        {
            // Arrange
            bool filled = false;
            string expected = $"Invalid width and height in Rect {width},{height} :rect <width>,<height>";

            // Act
            void Action() => appCanvas.Rect(width, height, filled);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

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
            int actual(int xPos, int yPos) => bitmap.GetPixel(xPos, yPos).ToArgb();

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

        [TestMethod]
        [DataRow(-100)]
        [DataRow(0)]
        public void TestTri_InvalidWidth(int width)
        {
            // Arrange
            int height = 100;
            string expected = $"Invalid width in Tri {width},{height} :tri <width>,<height>";

            // Act
            void Action() => appCanvas.Tri(width, height);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(-100)]
        [DataRow(0)]
        public void TestTri_InvalidHeight(int height)
        {
            // Arrange
            int width = 100;
            string expected = $"Invalid height in Tri {width},{height} :tri <width>,<height>";

            // Act
            void Action() => appCanvas.Tri(width, height);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(-100, -100)]
        [DataRow(0, 0)]
        public void TestTri_InvalidDimensions(int width, int height)
        {
            // Arrange
            string expected = $"Invalid width and height in Tri {width},{height} :tri <width>,<height>";

            // Act
            void Action() => appCanvas.Tri(width, height);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

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
            Assert.AreNotEqual(expected, actual(width, 0));
            Assert.AreNotEqual(expected, actual(0, 0));
        }

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

