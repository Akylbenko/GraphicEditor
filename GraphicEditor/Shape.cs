using System;
using System.Drawing;

namespace GraphicEditor
{
    public abstract class Shape
    {
        private Color _color;
        private Point _location;
        private bool _isSelected;
        private float _penWidth;

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

        public float PenWidth
        {
            get { return _penWidth; }
            set { _penWidth = value; }
        }

        protected Shape(Color color, Point location)
        {
            _color = color;
            _location = location;
            _isSelected = false;
            _penWidth = 2.0f;
        }

        public abstract void Draw(Graphics graphics);

        public virtual bool Contains(Point point)
        {
            return Math.Abs(point.X - _location.X) < 10 &&
                   Math.Abs(point.Y - _location.Y) < 10;
        }

        public virtual void Move(int deltaX, int deltaY)
        {
            _location = new Point(_location.X + deltaX, _location.Y + deltaY);
        }
    }
}