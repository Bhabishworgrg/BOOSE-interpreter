using MainProject;
using BOOSE;
using System.Drawing;

namespace TestProject
{
    [TestClass]
    public sealed class TestPosition
    {
        private AppCanvas appCanvas;
        
        [TestInitialize]
        public void TestInitialize() => appCanvas = new AppCanvas();

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
            void Action() => appCanvas.DrawTo(x, y);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

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
            void Action() => appCanvas.MoveTo(x, y);
            Exception ex = Assert.ThrowsException<CanvasException>(Action);
            string actual = ex.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

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

