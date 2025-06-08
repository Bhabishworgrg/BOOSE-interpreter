using BOOSE;
using BOOSE.Main;
using System.Drawing;

namespace BOOSE.Tests
{
    /// <summary>
    /// Test class to check the unrestricted classes.
    /// </summary>
    [TestClass]
    public sealed class TestUnrestrictedClasses
    {
		private Interpreter interpreter;
	
		/// <summary>
		/// Initializes the test environment.
		/// </summary>
		[TestInitialize]
		public void TestInitialize()
		{
			ICanvas canvas = new AppCanvas();
			Bitmap bitmap = (Bitmap) canvas.getBitmap();
			interpreter = new Interpreter(canvas, bitmap);
		}

		/// <summary>
		/// Test to check the unrestricted int.
		/// </summary>
        [TestMethod]
        public void TestInt()
        {
			// Arrange
			string code = 
				"int radius = 50\n" +
				"int width\n" +
				"width = 2 * radius\n" +
				"int height = 100\n" +
				"int red = 255\n" +
				"int green = 128\n" +
				"pen red, 0, 0\n" +
				"moveto 100, 100\n" +
				"circle radius\n" +
				"pen 0, green, 0\n" +
				"rect width, height\n" +
					"pen red, 0, 0\n" +
				"moveto 150, 150\n" +
				"circle radius\n" +
				"pen 0, green, 0\n" +
				"rect width, height";

			try
			{
				// Act
				interpreter.ExecuteProgram(code);
			}
			catch (Exception ex)
			{
				// Assert
				Assert.Fail(ex.Message);
			}
		}

		/// <summary>
		/// Test to check the unrestricted real.
		/// </summary>
		[TestMethod]
		public void TestReal()
		{
			// Arrange
			string code =
				"pen 0,0,255\n" +
				"real length = 15.5\n" +
				"real width = 10.0\n" +
				"real pi = 3.14159\n" +
				"real radius = 27.7\n" +
				"real circ = 2 * pi * radius\n" +
				"moveto 100,100\n" +
				"write length * width\n" +
				"moveto 100,125\n" +
				"write circ";

			try
			{
				// Act
				interpreter.ExecuteProgram(code);
			}
			catch (Exception ex)
			{
				// Assert
				Assert.Fail(ex.Message);
			}
		}

		/// <summary>
		/// Test to check the unrestricted array.
		/// </summary>
		[TestMethod]
		public void TestArray()
		{
			// Arrange
			string code =
				"int x = 0\n" +
				"real y\n" +
				"real z\n" +
				"array int nums 10\n" +
				"poke nums 5 = 99\n" +
				"peek x = nums 5\n" +
				"circle x\n" +
				"array real prices 10\n" +
				"poke prices 5 = 99.99\n" +
				"peek y = prices 5\n" +
				"pen 0,255,0\n" +
				"write \"£\"+y\n" +
				"array real logs 10\n" +
				"poke logs 5 = 100.001\n" +
				"peek z = logs 5\n" +
				"moveto 0,25\n" +
				"write z";

			try
			{
				// Act
				interpreter.ExecuteProgram(code);
			}
			catch (Exception ex)
			{
				// Assert
				Assert.Fail(ex.Message);
			}
		}

		/// <summary>
		/// Test to check the unrestricted if.
		/// </summary>
		[TestMethod]
		public void TestIf()
		{
			// Arrange
			string code =
				"int control = 50\n" +
				"if control < 10\n" +
				"	if control < 5\n" +
				"		pen 255,0,0\n" +
				"	else\n" +
				"		pen 0,0,255\n" +
				"	end if\n" +
				"	circle 20\n" +
				"	rect 20,20\n" +
				"else\n" +
				"	pen 0,255,0\n" +
				"	circle 100\n" +
				"	rect 100,100\n" +
				"end if";

			try
			{
				// Act
				interpreter.ExecuteProgram(code);
			}
			catch (Exception ex)
			{
				// Assert
				Assert.Fail(ex.Message);
			}
		}

		/// <summary>
		/// Test to check the unrestricted while.
		/// </summary>
		[TestMethod]
		public void TestWhile()
		{
			// Arrange
			string code =
				"moveto 100,100\n" +
				"int width = 90\n" +
				"int height = 150\n" +
				"pen 255,128,128\n" +
				"while height > 50\n" +
				"	circle height\n" +
				"	height = height - 15\n" +
				"	if height < 100\n" +
				"		pen 0,128,255\n" +
				"	end if\n" +
				"end while\n" +	
				"pen 0,255,0\n" +
				"moveto 50,50\n" +
				"height = 50\n" +
				"while height > 10\n" +
				"	rect height, height\n" +
				"	height = height - 10\n" +
				"end while";

			try
			{
				// Act
				interpreter.ExecuteProgram(code);
			}
			catch (Exception ex)
			{
				// Assert
				Assert.Fail(ex.Message);
			}
		}

		/// <summary>
		/// Test to check the unrestricted for.
		/// </summary>
		[TestMethod]
		public void TestFor()
		{
			// Arrange
			string code =
				"pen 255,0,0\n" +
				"moveto 200,200\n" +
				"for count = 1 to 20 step 2\n" +
				"	circle count * 10\n" +
				"end for\n" +
				"pen 0,255,0\n" +
				"moveto 150,150\n" +
				"for count = 20 to 1 step -2\n" +
				"	circle count * 10\n" +
				"end for\n" +
				"pen 0,0,255\n" +
				"for count2 = 30 to 10 step -1\n" +
				"	circle count2 * 20\n" +
				"end for";

			try
			{
				// Act
				interpreter.ExecuteProgram(code);
			}
			catch (Exception ex)
			{
				// Assert
				Assert.Fail(ex.Message);
			}
		}
    }
}
