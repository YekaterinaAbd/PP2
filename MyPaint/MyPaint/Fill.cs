using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    class FillPicture
    {
        Queue<Point> queue = new Queue<Point>();
        Bitmap bitmap;
        Color originColor;
        
        void Step(Color fillColor, int x, int y)
        {
            if (x < 0 || x >= bitmap.Width) return;
            if (y < 0 || y >= bitmap.Height) return;
            if (bitmap.GetPixel(x, y) != originColor) return;
            bitmap.SetPixel(x, y, fillColor);
            queue.Enqueue(new Point(x, y));
        }

        public void Fill(Color fillColor, Point originPoint, Bitmap bitmap)
        {
            this.bitmap = bitmap;
            //fill the first pixel and add it to the queue
            originColor = bitmap.GetPixel(originPoint.X, originPoint.Y);
            bitmap.SetPixel(originPoint.X, originPoint.Y, fillColor);
            queue.Enqueue(originPoint);

            //add neighbour points to the queue and fill them
            while(queue.Count != 0)
            {
                Point currPoint = queue.Dequeue();
                Step(fillColor, currPoint.X + 1, currPoint.Y);
                Step(fillColor, currPoint.X - 1, currPoint.Y);
                Step(fillColor, currPoint.X, currPoint.Y + 1);
                Step(fillColor, currPoint.X, currPoint.Y - 1);
            }
        }
    }
}
