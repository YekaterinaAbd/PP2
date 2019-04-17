using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public enum Tool
    {
        PEN, LINE, RECTANGLE, ELLIPSE, TRIANGLE,
        RIGHTTRIANGLE
    };
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        Point firstPoint, secondPoint;
        Pen pencil = new Pen(Color.Black, 2);
        Tool tool = Tool.PEN;


        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;
            pencil.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pencil.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            tool = Tool.RECTANGLE;
        }

        private void line_Click(object sender, EventArgs e)
        {
            tool = Tool.LINE;
        }

        private void ellipse_Click(object sender, EventArgs e)
        {
            tool = Tool.ELLIPSE;
        }

        private void pen_Click(object sender, EventArgs e)
        {
            tool = Tool.PEN;
        }
        private void triangle_Click(object sender, EventArgs e)
        {
            tool = Tool.TRIANGLE;
        }
        private void righttriangle_Click(object sender, EventArgs e)
        {
            tool = Tool.RIGHTTRIANGLE;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (tool)
            {
                case Tool.PEN:
                    break;
                case Tool.LINE:
                    secondPoint = e.Location;
                    graphics.DrawLine(pencil, firstPoint, secondPoint); //drawing on bitmap with saving picture
                    pictureBox1.Refresh();
                    break;
                case Tool.RECTANGLE:
                    graphics.DrawRectangle(pencil, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tool.ELLIPSE:
                    graphics.DrawEllipse(pencil, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tool.TRIANGLE:
                    graphics.DrawPolygon(pencil, GetTriangle(firstPoint, secondPoint));
                    break;
                case Tool.RIGHTTRIANGLE:
                    graphics.DrawPolygon(pencil, GetrightTriangle(firstPoint, secondPoint));
                    break;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            switch (tool)
            {
                case Tool.PEN:
                    break;
                case Tool.LINE:
                    e.Graphics.DrawLine(pencil, firstPoint, secondPoint);
                    //drawing on picturebox to make the line initially visible, then it disappears
                    break;
                case Tool.RECTANGLE:
                    e.Graphics.DrawRectangle(pencil, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tool.ELLIPSE:
                    e.Graphics.DrawEllipse(pencil, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tool.TRIANGLE:
                    e.Graphics.DrawPolygon(pencil, GetTriangle(firstPoint, secondPoint));
                    break;
                case Tool.RIGHTTRIANGLE:
                    e.Graphics.DrawPolygon(pencil, GetrightTriangle(firstPoint, secondPoint));
                    break;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                secondPoint = e.Location;

                switch (tool)
                {
                    case Tool.PEN:
                        graphics.DrawLine(pencil, firstPoint, secondPoint);
                        firstPoint = secondPoint;
                        break;
                    case Tool.LINE:
                        break;
                    case Tool.RECTANGLE:
                        break;
                    case Tool.ELLIPSE:
                        break;
                }
                pictureBox1.Refresh();
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pencil.Color = colorDialog1.Color;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(saveFileDialog1.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitmap = new Bitmap(openFileDialog1.FileName);
                graphics = Graphics.FromImage(bitmap);
                pictureBox1.Image = bitmap;
            }
        }

        private void rubber_Click(object sender, EventArgs e)
        {
            tool = Tool.PEN;
            pencil.Color = Color.White;
        }


        public Rectangle GetRectangle(Point first, Point second)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.X = Math.Min(first.X, second.X);
            rectangle.Y = Math.Min(first.Y, second.Y);

            rectangle.Width = Math.Abs(second.X - first.X);
            rectangle.Height = Math.Abs(second.Y - first.Y);

            return rectangle;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           
            pencil.Width = decimal.ToInt32(numericUpDown1.Value);
        }

        private void palette_Click(object sender, EventArgs e)
        {
            pencil.Color = Color.FromArgb(bitmap.GetPixel(firstPoint.X, firstPoint.Y).ToArgb());
            
        }

        public Point[] GetTriangle(Point first, Point second)
        {
            Point[] triangle =
            {
                new Point(first.X, first.Y),
                new Point(second.X, first.Y),
                new Point((second.X + firstPoint.X)/2, second.Y)
            };

            return triangle;
        }


        public Point[] GetrightTriangle(Point first, Point second)
        {
            Point[] triangle =
            {
                new Point(first.X, first.Y),
                new Point(second.X, first.Y),
                new Point(first.X, second.Y)
            };
            return triangle;
        }
    }
}
