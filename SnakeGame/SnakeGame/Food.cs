using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Food:GameObject
    {
        public Food(char sign):base(sign) { }

        public void Generate(Snake snake, Wall wall)
        {

            bool ok = false;
            while (!ok)
            {
                Random random = new Random();
                body.Clear();
                body.Add(new Point(random.Next(2, 58), random.Next(2, 28)));
                ok = true;

                if (IsCollision(wall) || IsCollision(snake))
                {
                    ok = false;
                    Generate(snake, wall);
                }
            }
        }
    }
}
