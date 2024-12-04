using BOOSE;

namespace ASEAssignment
{
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

		public int Xpos
		{ 
			get => xPos; 
			set => xPos = value;
		}

		public int Ypos
		{
			get => yPos;
			set => yPos = value;
		}

        public object PenColour
		{ 
			get => penColour;
			set
			{
				penColour = (Color)value;
				solidBrush.Color = penColour;
				pen.Color = penColour;
			}
		}

		public AppCanvas()
		{
			xPos = yPos = 0;

			displayWidth = 640;
			displayHeight = 480;
			
			penColour = Color.Black;
			solidBrush = new SolidBrush(penColour);
			pen = new Pen(penColour);
			font = new Font("Arial", 12);

			bitmap = new Bitmap(displayWidth, displayHeight);
			graphics = Graphics.FromImage(bitmap);
		}

        public void Circle(int radius, bool filled)
        {
			if (filled)
			{
				graphics.FillEllipse(solidBrush, xPos, yPos, radius, radius);
			}
			else
			{
				graphics.DrawEllipse(pen, xPos, yPos, radius, radius);
			}
        }

        public void Clear()
        {
			graphics.Clear(Color.White);
        }

        public void DrawTo(int x, int y)
        {
			graphics.DrawLine(pen, xPos, yPos, x, y);
			xPos = x;
			yPos = y;
        }

        public object getBitmap()
        {
			return bitmap;
        }

        public void MoveTo(int x, int y)
        {
			xPos = x;
			yPos = y;
        }

        public void Rect(int width, int height, bool filled)
        {
			if (filled)
			{
				graphics.FillRectangle(solidBrush, xPos, yPos, width, height);
			}
			else
			{
				graphics.DrawRectangle(pen, xPos, yPos, width, height);
			}
        }

        public void Reset()
        {
			xPos = yPos = 0;
        	PenColour = Color.Black;
		}

        public void Set(int width, int height)
        {
			displayWidth = width;
			displayHeight = height;
        }

        public void SetColour(int red, int green, int blue)
        {
			PenColour = Color.FromArgb(red, green, blue);
        }

        public void Tri(int width, int height)
        {
			Point[] points = new Point[3];
			points[0] = new Point((xPos + width) / 2, yPos);
			points[1] = new Point(xPos, yPos + height);
			points[2] = new Point(xPos + width, yPos + height);

			graphics.FillPolygon(solidBrush, points);
        }

        public void WriteText(string text)
        {
			graphics.DrawString(text, font, solidBrush, xPos, yPos);
        }
    }
}
