using System;
using System.Drawing;

namespace GraphicEditor
{
    public class LineShape : Shape
    {
        private Point _startpoint;
        private Point _endPoint;

        public Point EndPoint
        {
            get { return _endPoint; }
            set { _endPoint = value; }
        }

        public Point StartPoint
        {
            get { return Location; }
            set { Location = value; }
        }

        public LineShape(Color color, Point startPoint, Point endPoint)
            : base(color, startPoint)
        {
            _endPoint = endPoint;
        }

        public override void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(Color, PenWidth))
            {
                graphics.DrawLine(pen, StartPoint, EndPoint);
            }
        }
    }
}