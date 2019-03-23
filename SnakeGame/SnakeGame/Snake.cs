using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public enum Movement
     {
         none, up, down, right, left
     };
     public class Snake: GameObject
     {

         public Snake(char sign):base(sign)
         {
             body.Add(new Point(20, 20));
         }

         Movement movement = Movement.none;

         public void Move(ConsoleKeyInfo key)
         {
             Clear();

             for (int i=body.Count - 1; i>=0; i--)
             {
                 if (i > 0)
                 {
                     body[i].x = body[i - 1].x;
                     body[i].y = body[i - 1].y;
                 }

                 if (key.Key == ConsoleKey.UpArrow && movement != Movement.down)
                     movement = Movement.up;
                 else if (key.Key == ConsoleKey.DownArrow && movement != Movement.up)
                     movement = Movement.down;
                 else if (key.Key == ConsoleKey.RightArrow && movement != Movement.left)
                     movement = Movement.right;
                 else if (key.Key == ConsoleKey.LeftArrow && movement != Movement.right)
                     movement = Movement.left;

                 if (i == 0)
                 {
                     if (movement == Movement.down)
                         body[0].y++;
                     else if (movement == Movement.up)
                         body[0].y--;
                     else if (movement == Movement.right)
                         body[0].x++;
                     else if (movement == Movement.left)
                         body[0].x--;
                 }
             }
         }

         public bool CollisionWithItself()
         {
             for(int i=1; i<body.Count - 1; i++)
             {
                 if (body[i].x == body[0].x && body[0].y == body[i].y)
                     return true;
             }
             return false;
         }

         public void Eat(Point p)
         {
             body.Add(new Point(p.x,p.y));
         }



     }
}
