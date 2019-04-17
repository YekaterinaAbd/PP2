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

namespace Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //drawing stars
            Random random = new Random();
            int[] x = new int[8];
            int[] y = new int[8];
            for (int i = 0; i < 8; i++)
            {
                x[i] = random.Next(0, pictureBox1.Width - 20);
                y[i] = random.Next(0, pictureBox1.Height - 20);
            }
            for (int i = 0; i < 8; i++)
                e.Graphics.FillEllipse(new Pen(Color.White).Brush, new Rectangle(x[i], y[i], 20, 20));


            //drawing text
            string text = "Level: 1 Score: 200 Live: ***";
            Font font = new Font("Times New Roman", 11, FontStyle.Bold);

            Rectangle rectangle = new Rectangle(515, 5, 200, 25);
            Pen pen = new Pen(Color.WhiteSmoke);
            e.Graphics.FillRectangle(pen.Brush, rectangle);

            pen = new Pen(Color.Black);
            e.Graphics.DrawString(text, font, pen.Brush, rectangle);


            //drawing spaceship
            Pen pen2 = new Pen(Color.Yellow);
            Point[] spaceship =
            {
                new Point(350, 148),
                new Point(388, 170),
                new Point(388, 206),
                new Point(350, 224),
                new Point(314, 206),
                new Point(314, 170)
            };
            e.Graphics.FillPolygon(pen2.Brush, spaceship);

            //drawing gun
            GraphicsPath gun = new GraphicsPath(FillMode.Winding);
            gun.AddRectangle(new Rectangle(342, 180, 16, 20));

            Point[] triangle =
            {
                new Point(335, 180),
                new Point(365, 180),
                new Point(350, 168)
            };
            gun.AddPolygon(triangle);
            Pen pen3 = new Pen(Color.Green);
            e.Graphics.FillPath(pen3.Brush, gun);

            //drawing bullet
            Point[] bullet =
            {
                new Point(350, 140),
                new Point(355, 130), 
                new Point(365, 125),
                new Point(355, 120),
                new Point(350, 110),
                new Point(345, 120),
                new Point(335, 125),
                new Point(344, 130)
            };
            Pen pen4 = new Pen(Color.Black);
            GraphicsPath bullets = new GraphicsPath(FillMode.Winding);
            bullets.AddClosedCurve(bullet);
            e.Graphics.FillPath(pen4.Brush, bullets);

            //drawing asteroids

            GraphicsPath asteroid = new GraphicsPath(FillMode.Winding);

            Point[] coordinates =
            {
                new Point(80, 100),
                new Point(150, 250),
                new Point(550, 150),
                new Point(450, 320)
            };

            int l = 50;
        
            foreach(var c in coordinates)
            {
                PointF[] asteroid11 =
           {
                new PointF(c.X, c.Y),
                new PointF(c.X + l, c.Y),
                new PointF(c.X + l/2, c.Y - 3*l/4)
            };
                e.Graphics.FillPolygon(new Pen(Color.Red).Brush, asteroid11);
                PointF[] asteroid22 =
                {
                new PointF(c.X, c.Y - l/2),
                new PointF(c.X + l/2, c.Y + l/4),
                new PointF(c.X + l, c.Y - l/2),
            };
                e.Graphics.FillPolygon(new Pen(Color.Red).Brush, asteroid22);
            }
            
        }
    }
}
