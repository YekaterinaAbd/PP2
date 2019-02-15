using System;
using System.Collections.Generic;
using System.IO;
namespace Task2
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


            for (int i = 0; i < Content.Length; ++i)
            {

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
                else Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(i + 1 + ". " + Content[i].Name);
            }
        }
    }


    enum FarMode
    {
        FileView,
        DirectoryView
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
            FarMode farMode = FarMode.DirectoryView;

            while (true) { 

                if (farMode == FarMode.DirectoryView)
                {
                    history.Peek().Draw();
                }

                int x = history.Peek().SelectedItem;

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--;
                        break;

                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;
                        break;


                    case ConsoleKey.Enter:
                        FileSystemInfo fsi = history.Peek().Content[x];

                        if(fsi.GetType() == typeof(DirectoryInfo)){
                            DirectoryInfo directoryInfo = fsi as DirectoryInfo;
                            history.Push(
                                new Level
                                {
                                    Content = directoryInfo.GetFileSystemInfos(),
                                    SelectedItem = 0
                                }
                                );
                        }
                        else
                        {
                            farMode = FarMode.FileView;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Clear();
                            FileStream fs = new FileStream(fsi.FullName, FileMode.Open, FileAccess.Read);
                            StreamReader read = new StreamReader(fs);
                            Console.WriteLine(read.ReadToEnd());
                            read.Close();
                        }
                        break;


                    case ConsoleKey.Backspace:
                        if (farMode == FarMode.DirectoryView)
                        {
                            history.Pop();
                        }
                        else if(farMode == FarMode.FileView)
                        {
                            farMode = FarMode.DirectoryView;
                        }
                        break;


                    case ConsoleKey.Delete:
                       FileSystemInfo fsi2 = history.Peek().Content[x];
                        if (fsi2.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directoryInfo = fsi2 as DirectoryInfo;
                            Directory.Delete(fsi2.FullName, true);
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos();
                        }

                        else
                        { 
                            FileInfo fileInfo = fsi2 as FileInfo;
                            fsi2.Delete();
                            history.Peek().Content = fileInfo.Directory.GetFileSystemInfos();
                        }
                        break;

                    case ConsoleKey.F2:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("New name: ");
                       
                        FileSystemInfo toRename = history.Peek().Content[x];

                        if (toRename.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo folder = toRename as DirectoryInfo;
                            string newfolder = Path.Combine(folder.Parent.FullName, Console.ReadLine());
                            Directory.Move(folder.FullName, newfolder);
                            history.Peek().Content = folder.Parent.GetFileSystemInfos();
                        }
                           
                        else if(toRename.GetType() == typeof(FileInfo))
                        {
                            FileInfo file = toRename as FileInfo;
                            string newfile = Path.Combine(file.Directory.FullName, Console.ReadLine());
                            file.MoveTo(newfile);
                            history.Peek().Content = file.Directory.GetFileSystemInfos();
                        }
                        break;
                }
            }
        }
    }
}
