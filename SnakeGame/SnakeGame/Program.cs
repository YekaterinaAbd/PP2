using System;
using System.IO;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Username: ");
            string name = Console.ReadLine();

            Game game = new Game();
            game.TimerRun();

            bool ok = true;
            while (ok)
            {
                ConsoleKeyInfo info = Console.ReadKey();

                if (info.Key == ConsoleKey.Enter)
                {
                    game.Stop();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    game = new Game();
                    game.TimerRun();
                }

                if (info.Key == ConsoleKey.Escape)
                {
                    ok = false;
                    game.Stop();

                    FileStream fs = new FileStream(@"C:\Users\ и\Documents\Visual Studio 2017\Projects\SnakeGame\SnakeGame\score.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(string.Format("{0} score: {1}", name, game.score));
                    sw.Close();
                    fs.Close();
                }
                else
                {
                    game.snake.Move(info);
                }


            }

        }

    }
}

