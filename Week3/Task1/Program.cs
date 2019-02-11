using System;
using System.Collections.Generic;
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
        int selectedItem;
        public int SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (value >= Content.Length)
                {
                    selectedItem = 0;

                }
                else if (value < 0)
                {
                    selectedItem = Content.Length - 1;
                }
                else selectedItem = value;
            }
        }

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
            
                if (i == SelectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }


                if (Content[i].GetType() == typeof(DirectoryInfo))
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                    Console.WriteLine(i + 1 + " " + Content[i].Name);
                }
            }
    }
    


    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\ и\Documents\PPP2";
            DirectoryInfo dir = new DirectoryInfo(path);
            Stack<Level> history = new Stack<Level>();
            history.Push(
                new Level
                {
                    Content = dir.GetFileSystemInfos(),
                    SelectedItem = 0
                }
                );
            history.Peek().Draw();
            
           
        
        }
    }
}
