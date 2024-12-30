using MainProject;
using BOOSE;
using System.Drawing;

namespace TestProject
{
    [TestClass]
    public sealed class TestGetSet
    {
        private AppCanvas appCanvas;

        [TestInitialize]
        public void TestInitialize() => appCanvas = new AppCanvas();

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

        [TestMethod]
        [DataRow(-100)]
        [DataRow(0)]
        public void TestSet_InvalidWidth(int width)
        {
            // Arrange
            int height = 100;
            string expected = $"Invalid width in Set {width},{height} :set <width>,<height>";

            // Act
            void Action() => appCanvas.Set(width, height);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(-100)]
        [DataRow(0)]
        public void TestSet_InvalidHeight(int height)
        {
            // Arrange
            int width = 100;
            string expected = $"Invalid height in Set {width},{height} :set <width>,<height>";

            // Act
            void Action() => appCanvas.Set(width, height);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(-100, -100)]
        [DataRow(0, 0)]
        public void TestSet_InvalidDimensions(int width, int height)
        {
            // Arrange
            string expected = $"Invalid width and height in Set {width},{height} :set <width>,<height>";

            // Act
            void Action() => appCanvas.Set(width, height);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

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
            void Action() => appCanvas.SetColour(red, green, blue);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

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

