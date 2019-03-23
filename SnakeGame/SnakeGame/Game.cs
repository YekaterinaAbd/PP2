using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace SnakeGame
{
    public enum Collision
    {
        snake, food
    };
    public class Game
    {
        public ConsoleKeyInfo key;
        public Snake snake;
        public Food food;
        public Wall wall;


        List<GameObject> objects;

        public int level = 1;
        public int score = 0;
        public bool alive = true;

        Timer timer = new Timer();


        public Game()
        {
            snake = new Snake('O');
            wall = new Wall('*');
            food = new Food('#');
            food.Generate(snake, wall);

            objects = new List<GameObject>();
            objects.Add(snake);
            objects.Add(wall);
            objects.Add(food);

            wall.LoadLevel(1);
        }

        public void Draw()
        {
            wall.Draw();
            food.Draw();
            snake.Draw();
        }

        public void Start()
        {

            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 36);
            Console.SetBufferSize(80, 36);

            Console.SetCursorPosition(2, 34);
            Console.WriteLine("Press ESC to quit game");
            Console.SetCursorPosition(2, 35);
            Console.WriteLine("Press ENTER to reset game");

            Draw();

            bool alive = true;

            while (alive && key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter)
            {

                key = Console.ReadKey();

            }
        }
        

        public void SnakeCollision()
        {
            Collision collision = Collision.snake;

            if (snake.IsCollision(food))
            {
                collision = Collision.food;
                score = score + 3;
                timer.Interval = Math.Max(60, timer.Interval - 10);

                snake.body.Add(new Point(snake.body[0].x, snake.body[0].y));
                food.Generate(snake, wall);
                food.Draw();

                if (snake.body.Count % 3 == 0)
                {
                    timer.Interval = Math.Max(60, timer.Interval - 20);
                    level++;
                    score += 5;
                    if (level <= 3)
                    {
                        wall.Clear();
                        wall.LoadLevel(level);
                        wall.Draw();
                    }
                    else
                    {
                        if (level > 3)
                        {
                            alive = false;
                            timer.Stop();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(25, 30);
                            Console.WriteLine("GAME OVER. YOU WIN");
                        }
                    }
                    snake.Clear();
                    snake = new Snake('O');
                    snake.Draw();
                }
            }

            if (snake.IsCollision(wall))
            {
                alive = false;
                timer.Stop();
                Console.SetCursorPosition(25, 30);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER. YOU DIED");
            }

            if (collision != Collision.food && snake.CollisionWithItself())

            {
                alive = false;
                timer.Stop();
                Console.SetCursorPosition(25, 30);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER. YOU DIED");
            }

        }

        public void TimerRun()
        {
            timer.Interval = 160;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            food.Draw();
            wall.Draw();
            Start();
        }

        public void Stop()
        {
            Console.Clear();
            timer.Elapsed -= Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            snake.Clear();
            snake.Move(key);
            snake.Draw();
            SnakeCollision();

            Console.SetCursorPosition(2, 31);
            Console.WriteLine("Your score: " + score);
        }
    }
}

