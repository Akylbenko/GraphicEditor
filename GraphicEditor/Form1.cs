using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicEditor
{
    public partial class Form1 : Form
    {
        private List<Shape> _shapes;
        private Panel _canvas;
        private Panel _toolPanel;
        private Button _rectangleButton;
        private Button _ellipseButton;
        private Button _lineButton;

        public Form1()
        {
            InitializeComponents();
            _shapes = new List<Shape>();
        }

        private void InitializeComponents()
        {
            this.Text = "Graphic Editor";
            this.Size = new Size(800, 600);

            _toolPanel = new Panel();
            _toolPanel.Dock = DockStyle.Top;
            _toolPanel.Width = 100;
            _toolPanel.Height = 150;
            _toolPanel.BackColor = Color.Gray;

            _canvas = new Panel();
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.White;
            _canvas.Paint += Canvas_Paint;

            _rectangleButton = new Button();
            _rectangleButton.Text = "Прямоугольник";
            _rectangleButton.Location = new Point(10, 20);
            _rectangleButton.Size = new Size(80, 30);
            _rectangleButton.Click += rectangleBtnClick;

            _ellipseButton = new Button();
            _ellipseButton.Text = "Круг";
            _ellipseButton.Location = new Point(10, 60);
            _ellipseButton.Size = new Size(80, 30);
            _ellipseButton.Click += ellipseBtnClick;

            _lineButton = new Button();
            _lineButton.Text = "Линия";
            _lineButton.Location = new Point(10, 100);
            _lineButton.Size = new Size(80, 30);
            _lineButton.Click += lineBtnClick;

            _toolPanel.Controls.Add(_rectangleButton);
            _toolPanel.Controls.Add(_ellipseButton);
            _toolPanel.Controls.Add(_lineButton);

            this.Controls.Add(_canvas);
            this.Controls.Add(_toolPanel);
        }

        private void rectangleBtnClick(object sender, EventArgs e)
        {
            RectangleShape rect = new RectangleShape(Color.Red, new Point(50, 50), 100, 80);
            _shapes.Add(rect);
            _canvas.Invalidate();
        }

        private void ellipseBtnClick(object sender, EventArgs e)
        {
            EllipseShape ellipse = new EllipseShape(Color.Blue, new Point(200, 50), 100, 80);
            _shapes.Add(ellipse);
            _canvas.Invalidate();
        }

        private void lineBtnClick(object sender, EventArgs e)
        {
            LineShape line = new LineShape(Color.Green, new Point(50, 200), new Point(200, 250));
            _shapes.Add(line);
            _canvas.Invalidate();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            foreach (Shape shape in _shapes)
            {
                shape.Draw(e.Graphics);
            }
        }
    }
}