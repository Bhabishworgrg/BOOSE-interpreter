using BOOSE;

namespace BOOSE.Main
{
    /// <summary>
    /// Class for drawing shapes and text.
    /// </summary>
    ///
    /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html">
    /// BOOSE.ICanvas
    /// </seealso>
    public class AppCanvas : ICanvas
    {
        private int xPos, yPos;
        private int displayWidth, displayHeight;
        private Color penColour;
        private SolidBrush solidBrush;
        private Pen pen;
        private Font font;
        private Bitmap bitmap;
        private Graphics graphics;
        private const int DEFAULT_WIDTH = 579;
        private const int DEFAULT_HEIGHT = 610;

        /// <summary>
        /// Get/Set the X position of the cursor.
        /// </summary>
        ///
        /// <value>X position of the cursor.</value>
        ///
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_Xpos">
        /// BOOSE.ICanvas.Xpos
        /// </seealso>
        public int Xpos
        {
            get => xPos;
            set => xPos = value;
        }

        /// <summary>
        /// Get/Set the Y position of the cursor.
        /// </summary>
        /// 
        /// <value>Y position of the cursor.</value>
        /// 
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_Ypos">
        /// BOOSE.ICanvas.Ypos
        /// </seealso>
        public int Ypos
        {
            get => yPos;
            set => yPos = value;
        }

        /// <summary>
        /// Get/Set the colour of the pen and brush.
        /// </summary>
        ///
        /// <value>Colour of the pen and brush.</value>
        /// 
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_PenColour">
        /// BOOSE.ICanvas.PenColour
        /// </seealso>
        public object PenColour
        {
            get => penColour;
            set
            {
                penColour = (Color) value;
                solidBrush.Color = penColour;
                pen.Color = penColour;
            }
        }

		/// <summary>
		/// Get the width of the canvas.
		/// </summary>
		public int DisplayWidth 
		{
			get => displayWidth;
		}

		/// <summary>
		/// Get the height of the canvas.
		/// </summary>
		public int DisplayHeight
		{
			get => displayHeight;
		}

        /// <summary>
        /// Constructor for AppCanvas.
        /// </summary>
        public AppCanvas()
        {
            xPos = yPos = 0;

            displayWidth = DEFAULT_WIDTH;
            displayHeight = DEFAULT_HEIGHT;

            penColour = Color.Black;
            solidBrush = new SolidBrush(penColour);
            pen = new Pen(penColour);
            font = new Font("Arial", 12);

            bitmap = new Bitmap(displayWidth, displayHeight);
            graphics = Graphics.FromImage(bitmap);
        }

        /// <summary>
        /// Draws a circle of <paramref name="radius"/>.
        /// </summary>
        /// 
        /// <param name="radius">Radius of the circle.</param>
        /// <param name="filled">Whether the circle is filled or not.</param>
		///	<exception cref="BOOSE.CanvasException">Thrown when the radius is less or equal to zero.</exception>
		///
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_Circle_System_Int32_System_Boolean">
        /// BOOSE.ICanvas.Circle
        /// </seealso>
		/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.CanvasException.html">
		/// BOOSE.CanvasException
		/// </seealso>
        public void Circle(int radius, bool filled)
        {
            if (radius <= 0)
            {
                throw new CanvasException($"Invalid radius in Circle {radius} :circle <radius>");
            }

            if (!filled)
            {
                graphics.DrawEllipse(pen, xPos - radius, yPos - radius, radius * 2, radius * 2);
            }
        }

        /// <summary>
        /// Clears the canvas.
        /// </summary>
        ///
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_Clear">
        /// BOOSE.ICanvas.Clear
        /// </seealso>
        public void Clear()
        {
            graphics.Clear(Color.White);
        }

        /// <summary>
        /// Draws a line from (<see cref="Xpos"/>, <see cref="Ypos"/>) to (<paramref name="x"/>, <paramref name="y"/>).
        /// </summary>
        ///
        /// <param name="x">X position of the end of the line.</param>
        /// <param name="y">Y position of the end of the line.</param>
        /// <exception cref="BOOSE.CanvasException">Thrown when the position is out of bounds of the canvas display.</exception>
		///
        /// <seealso cref="Xpos"/>
        /// <seealso cref="Ypos"/>
        ///
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_DrawTo_System_Int32_System_Int32_">
        /// BOOSE.ICanvas.DrawTo
        /// </seealso>
		/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.CanvasException.html">
		/// BOOSE.CanvasException
		/// </seealso>
        public void DrawTo(int x, int y)
        {
            if (x < 0 || y < 0 || x > displayWidth || y > displayHeight)
            {
                throw new CanvasException($"Invalid position in DrawTo {x},{y} :drawto <x>,<y>");
            }

            graphics.DrawLine(pen, xPos, yPos, x, y);
            xPos = x;
            yPos = y;
        }

        /// <summary>
        /// Get the bitmap of the canvas.
        /// </summary>
        ///
        /// <returns>Bitmap of the canvas.</returns>
        /// 
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_getBitmap">
        /// BOOSE.ICanvas.getBitmap
        /// </seealso>
        public object getBitmap()
        {
            return bitmap;
        }

        /// <summary>
        /// Moves the cursor from (<see cref="Xpos"/>, <see cref="Ypos"/>) to (<paramref name="x"/>, <paramref name="y"/>).
        /// </summary>
        ///
        /// <param name="x">X position to move the cursor to.</param>
        /// <param name="y">Y position to move the cursor to.</param>
        /// <exception cref="BOOSE.CanvasException">Thrown when the position is out of bounds of the canvas display.</exception>
		///
        /// <seealso cref="Xpos"/>
        /// <seealso cref="Ypos"/>
        ///
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_MoveTo_System_Int32_System_Int32_">
        /// BOOSE.ICanvas.MoveTo
        /// </seealso>
		/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.CanvasException.html">
		/// BOOSE.CanvasException
		/// </seealso>
        public void MoveTo(int x, int y)
        {
            if (x < 0 || y < 0 || x > displayWidth || y > displayHeight)
            {
                throw new CanvasException($"Invalid position in MoveTo {x},{y} :moveto <x>,<y>");
            }

            xPos = x;
            yPos = y;
        }


        /// <summary>
        /// Draws a rectangle of <paramref name="width"/> and <paramref name="height"/>.
        /// </summary>
        /// 
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        /// <param name="filled">Whether the rectangle is filled or not.</param>
        /// <exception cref="BOOSE.CanvasException">Thrown when the width or height is less than or equal to zero.</exception>
		///
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_Rect_System_Int32_System_Int32_System_Boolean_">
        /// BOOSE.ICanvas.Rect
        /// </seealso>
		/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.CanvasException.html">
		/// BOOSE.CanvasException
		/// </seealso>
        public void Rect(int width, int height, bool filled)
        {
            if (width <= 0 && height <= 0)
            {
                throw new CanvasException($"Invalid width and height in Rect {width},{height} :rect <width>,<height>");
            }
            else if (height <= 0)
            {
                throw new CanvasException($"Invalid height in Rect {width},{height} :rect <width>,<height>");
            }
            else if (width <= 0)
            {
                throw new CanvasException($"Invalid width in Rect {width},{height} :rect <width>,<height>");
            }

            if (!filled)
            {
                graphics.DrawRectangle(pen, xPos, yPos, width, height);
            }
        }

        /// <summary>
        /// Resets the position of the cursor and the colour of the pen and brush.
        /// </summary>
        ///
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_Reset">
        /// BOOSE.ICanvas.Reset
        /// </seealso>
        public void Reset()
        {
            xPos = yPos = 0;
            PenColour = Color.Black;
        }

        /// <summary>
        /// Sets the canvas size.
        /// </summary>
        ///
        /// <param name="width">Width of the canvas.</param>
        /// <param name="height">Height of the canvas.</param>
        /// <exception cref="BOOSE.CanvasException">Thrown when the width or height is less than or equal to zero.</exception>
		///
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_Set_System_Int32_System_Int32_">
        /// BOOSE.ICanvas.Set
        /// </seealso>
		/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.CanvasException.html">
		/// BOOSE.CanvasException
		/// </seealso>
        public void Set(int width, int height)
        {
			if (width <= 0 && height <= 0)
			{
				throw new CanvasException($"Invalid width and height in Set {width},{height} :set <width>,<height>");
			}
			else if (height <= 0)
			{
				throw new CanvasException($"Invalid height in Set {width},{height} :set <width>,<height>");
			}
			else if (width <= 0)
			{
				throw new CanvasException($"Invalid width in Set {width},{height} :set <width>,<height>");
			}

            displayWidth = width;
            displayHeight = height;
        }

        /// <summary>
        /// Sets the colour of the pen and brush.
        /// </summary>
        ///
        /// <param name="red">Red value of the colour.</param>
        /// <param name="green">Green value of the colour.</param>
        /// <param name="blue">Blue value of the colour.</param>
		/// <exception cref="BOOSE.CanvasException">Thrown when the colour values are out of bounds.</exception>
        /// 
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_SetColour_System_Int32_System_Int32_System_Int32_">
        /// BOOSE.ICanvas.SetColour
        /// </seealso>
		/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.CanvasException.html">
		/// BOOSE.CanvasException
		/// </seealso>
        public void SetColour(int red, int green, int blue)
        {
            if (red < 0 || red > 255 || green < 0 || green > 255 || blue < 0 || blue > 255)
            {
                throw new CanvasException($"Invalid colour in SetColour {red},{green},{blue} :setcolour <red>,<green>,<blue>");
            }

            PenColour = Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// Draws a triangle of <paramref name="width"/> and <paramref name="height"/>.
        /// </summary>
        ///
        /// <param name="width">Width of the triangle.</param>
        /// <param name="height">Height of the triangle.</param>
        /// <exception cref="CanvasException">Thrown when the width or height is invalid.</exception>
		///
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_Tri_System_Int32_System_Int32_">
        /// BOOSE.ICanvas.Tri
        /// </seealso>
		/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.CanvasException.html">
		/// BOOSE.CanvasException
		/// </seealso>
        public void Tri(int width, int height)
        {
            if (width <= 0 && height <= 0)
            {
                throw new CanvasException($"Invalid width and height in Tri {width},{height} :tri <width>,<height>");
            }
            else if (height <= 0)
            {
                throw new CanvasException($"Invalid height in Tri {width},{height} :tri <width>,<height>");
            }
            else if (width <= 0)
            {
                throw new CanvasException($"Invalid width in Tri {width},{height} :tri <width>,<height>");
            }

            Point[] points = new Point[3];
            points[0] = new Point((xPos + width) / 2, yPos);
            points[1] = new Point(xPos, yPos + height);
            points[2] = new Point(xPos + width, yPos + height);

            graphics.DrawPolygon(pen, points);
        }

        /// <summary>
        /// Writes <paramref name="text"/> on the current position.
        /// </summary>
        ///
        /// <param name="text">Text to write on the canvas.</param>
        /// 
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.ICanvas.html#BOOSE_ICanvas_WriteText_System_String_">
        /// BOOSE.ICanvas.WriteText
        /// </seealso>
        public void WriteText(string text)
        {
            graphics.DrawString(text, font, solidBrush, xPos, yPos);
        }
    }
}
