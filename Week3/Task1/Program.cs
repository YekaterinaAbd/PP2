using System;
using System.IO;
namespace Task1
{
    class Level
    {
        public FileSystemInfo[] Content
        {
            get;
            set;
        }
        public int selectedItem;
       

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < Content.Length; i++)
            {
                for (int j = i + 1; j < Content.Length; j++)
                {
                    {
                        if (Content[j].GetType() == typeof(DirectoryInfo) && Content[i].GetType() == typeof(FileInfo))
                        {
                            var t = Content[j];
                            Content[j] = Content[i];
                            Content[i] = t;
                        }
                    }
                }
            }

            for (int i = 0; i < Content.Length; ++i) { 
            
                if (i == selectedItem)
                Console.BackgroundColor = ConsoleColor.DarkGray;
                else
                Console.BackgroundColor = ConsoleColor.Black;

                if (Content[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine(i + 1 + ". " + Content[i].Name);
                }
            }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\ и\Documents\PPP2");
            Level l = new Level
            {
                Content = dir.GetFileSystemInfos(),
                selectedItem = 0
            };
                
            l.Draw();
        }
    }
}
