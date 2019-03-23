using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnakeGame
{
    public class Wall : GameObject
    {

        public Wall(char sign) : base(sign)
        {
        }

        public void LoadLevel(int level)
        {
            string name = string.Format(@"C:\Users\ и\Documents\Visual Studio 2017\Projects\SnakeGame\SnakeGame\Levels\Level{0}.txt", level);
            StreamReader sr = new StreamReader(name);
            body = new List<Point>();
            int y = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] == '*')
                    {
                        body.Add(new Point(x, y));
                    }
                }
                y++;

            }
            sr.Close();
        }
    }
}
