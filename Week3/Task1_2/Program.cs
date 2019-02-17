using System;
using System.IO;

namespace Task1_2
{
    class Program
    {

        static void Draw(FileSystemInfo[] Content, int selectedItem)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            for (int i = 0; i < Content.Length; i++)
            {
                for (int j = i + 1; j < Content.Length; j++)
                {

                    if (Content[j].GetType() == typeof(DirectoryInfo) && Content[i].GetType() == typeof(FileInfo))
                    {
                        var t = Content[j];
                        Content[j] = Content[i];
                        Content[i] = t;
                    }

                }
            }

            for (int i = 0; i < Content.Length; i++)
            {
                if (i == selectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else Console.BackgroundColor = ConsoleColor.Black;

                if (Content[i].GetType() == typeof(DirectoryInfo))
                {

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine(i + 1 + ". " + Content[i].Name);
            }
        }


        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\ и\Documents\PPP2");
            FileSystemInfo[] Content = dir.GetFileSystemInfos();
            int selectedItem = 0;
            Draw(Content, selectedItem);
        }
    }
}


