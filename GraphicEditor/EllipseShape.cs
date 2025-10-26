using System.Drawing;

namespace GraphicEditor
{
    public class EllipseShape : Shape
    {
        private int _width;
        private int _height;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public EllipseShape(Color color, Point location, int width, int height)
            : base(color, location)
        {
            _width = width;
            _height = height;
        }

        public override void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(Color, PenWidth))
            {
                graphics.DrawEllipse(pen, Location.X, Location.Y, Width, Height);
            }
        }

        public override bool Contains(Point point)
        {
            return point.X >= Location.X && point.X <= Location.X + Width &&
                   point.Y >= Location.Y && point.Y <= Location.Y + Height;
        }
    }
}