using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class GameObject
    {
        public char sign;
        public List<Point> body = new List<Point>();
        public GameObject() { }
        public GameObject(char sign)
        {
            this.sign = sign;
        }

        public void Draw()
        {
            foreach(var p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public void Clear()
        {
            foreach(var p in body)
            {
               Console.SetCursorPosition(p.x, p.y);
                Console.Write(' ');
            }
        }

        public bool IsCollision(GameObject obj)
        {
            foreach (Point p in obj.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }
    }
}
