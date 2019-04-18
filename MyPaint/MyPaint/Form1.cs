using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public enum Tool
    {
        PEN,
        LINE,
        RECTANGLE,
        ELLIPSE,
        TRIANGLE,
        RIGHTTRIANGLE,
        STAR,
        FILL,
        GDIFILL
    };
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        Point firstPoint, secondPoint;
        Pen pencil = new Pen(Color.Black, 2);
        SolidBrush brush = new SolidBrush(Color.White);
        Tool tool = Tool.PEN;


        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;

            pencil.StartCap = LineCap.Round;
            pencil.EndCap = LineCap.Round;
        }
        //buttons click, change of tool
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
        private void star_Click(object sender, EventArgs e)
        {
            tool = Tool.STAR;
        }
        private void fill_Click(object sender, EventArgs e)
        {
            //tool = Tool.FILL;
            tool = Tool.GDIFILL;
        }


        //mouse click
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;

            //fill picture
            if(tool == Tool.FILL)
            {
                FillPicture fill = new FillPicture();
                fill.Fill(pencil.Color, e.Location, bitmap);
            }
            if(tool == Tool.GDIFILL)
            {
                MapFill mapFill = new MapFill();
                mapFill.Fill(graphics, e.Location, pencil.Color, ref bitmap);
                graphics = Graphics.FromImage(bitmap);
                pictureBox1.Image = bitmap;
            }
        }

        //when отпускаем мышь
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // drawing on bitmap with saving picture
            switch (tool)
            {
                case Tool.LINE:
                    secondPoint = e.Location;
                    graphics.DrawLine(pencil, firstPoint, secondPoint); 
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
                case Tool.STAR:
                    GraphicsPath path = new GraphicsPath(FillMode.Winding);
                    path.AddPolygon(GetStar(firstPoint, secondPoint));
                    graphics.DrawPath(pencil, path);
                    graphics.FillPath(brush, path);
                    break;
                case Tool.FILL:
                    break;
                case Tool.GDIFILL:
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //drawing on picturebox to make the line initially visible, then it disappears
            switch (tool)
            {
                case Tool.LINE:
                    e.Graphics.DrawLine(pencil, firstPoint, secondPoint);
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
                case Tool.STAR:
                    GraphicsPath path = new GraphicsPath(FillMode.Winding);
                    path.AddPolygon(GetStar(firstPoint, secondPoint));
                    e.Graphics.DrawPath(pencil, path);
                    e.Graphics.FillPath(brush, path);
                    break;
                case Tool.FILL:
                    break;
                default:
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
                }
                pictureBox1.Refresh();
            }
        }

        //select a color
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pencil.Color = colorDialog1.Color;
            }
        }

        //save picture
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an image file";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(saveFileDialog1.FileName);
            }
        }

        //open picture
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitmap = new Bitmap(openFileDialog1.FileName);
                graphics = Graphics.FromImage(bitmap);
                pictureBox1.Image = bitmap;
            }
        }

        //rubber
        private void rubber_Click(object sender, EventArgs e)
        {
            tool = Tool.PEN;
            pencil.Color = Color.White;
        }

        //pencil width
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pencil.Width = decimal.ToInt32(numericUpDown1.Value);
        }

        //пипетка
        private void palette_Click(object sender, EventArgs e)
        {
            pencil.Color = Color.FromArgb(bitmap.GetPixel(firstPoint.X, firstPoint.Y).ToArgb());

        }

        //function for dwawing a rectungle
        public Rectangle GetRectangle(Point first, Point second)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.X = Math.Min(first.X, second.X);
            rectangle.Y = Math.Min(first.Y, second.Y);

            rectangle.Width = Math.Abs(second.X - first.X);
            rectangle.Height = Math.Abs(second.Y - first.Y);

            return rectangle;
        }


        //function for drawing a triangle
        public Point[] GetTriangle(Point first, Point second)
        {
            Point[] triangle =
            {
                new Point(first.X, Math.Max( first.Y, second.Y)),
                new Point(second.X, Math.Max( first.Y, second.Y)),
                new Point((second.X + firstPoint.X)/2, Math.Min(first.Y, second.Y))
            };

            return triangle;
        }


        //function for drawing right triangle
        public Point[] GetrightTriangle(Point first, Point second)
        {
            Point[] triangle =
            {
                new Point(Math.Min( first.X, second.X), Math.Min( first.Y, second.Y)),
                new Point( first.X, Math.Max( first.Y, second.Y)),
                new Point(second.X, Math.Max( first.Y, second.Y))
            };
            return triangle;
        }

        //function for drawing a star
        public Point[] GetStar(Point first, Point second) 
        {
            Rectangle bounds = new Rectangle();
            bounds.X = first.X;
            bounds.Y = Math.Min(first.Y, second.Y);
            bounds.Width = second.X - first.X;
            bounds.Height = Math.Abs(second.Y - first.Y);

            Point[] star =
            {
                //new Point(first.X + bounds.Width/2, first.Y),
                new Point(first.X + bounds.Width/2, Math.Min(first.Y, second.Y)),

                //new Point(second.X - bounds.Width/6, second.Y),
                new Point(second.X - bounds.Width/6, Math.Max(first.Y, second.Y)),

                //new Point(first.X, first.Y + bounds.Height/3),
                new Point(first.X, Math.Min(first.Y + bounds.Height/3, second.Y + bounds.Height/3)),

                //new Point(second.X, first.Y + bounds.Height/3),
                new Point(second.X, Math.Min(first.Y + bounds.Height/3, second.Y + bounds.Height/3)),

               //new Point(first.X + bounds.Width/6, first.Y + bounds.Height)
                new Point(first.X + bounds.Width/6, Math.Max( first.Y, second.Y))
            };
            return star;
        }
    }
}
