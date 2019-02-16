using System;
using System.IO;

namespace Task2_1
{
    class Level
    {
        //private FileSystemInfo[] content;
        public FileSystemInfo[] Content
        {
            get; //{return content}
            set; //{content = value}
        }
        public int selectedItem;

        public void Up()
        {
            if (selectedItem <= 0)
            {
                selectedItem = Content.Length - 1;
            }
            else selectedItem--;
        }

        public void Down()
        {
            if (selectedItem >= Content.Length-1)
            {
                selectedItem = 0;
            }
            else selectedItem++;
        }

        public void Draw()
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
    }
    enum Farmode
    {
        DirectiryView,
        FileView
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
            Farmode farmode = Farmode.DirectiryView;
            bool escape = false;
            while (!escape)
            {
                if (farmode == Farmode.DirectiryView)
                    l.Draw();

                ConsoleKeyInfo consoleKey = Console.ReadKey();

                if (consoleKey.Key == ConsoleKey.DownArrow)
                {
                    l.Down();
                }

                if (consoleKey.Key == ConsoleKey.UpArrow)
                {
                    l.Up();
                }

                if (consoleKey.Key == ConsoleKey.Delete)
                {


                    FileSystemInfo fsi = l.Content[l.selectedItem];
                    if (fsi.GetType() == typeof(DirectoryInfo))
                    {
                        var folder = fsi as DirectoryInfo;
                        Directory.Delete(folder.FullName, true);
                        l.Content = folder.Parent.GetFileSystemInfos();

                    }
                    else if (fsi.GetType() == typeof(FileInfo))
                    {
                        var file = fsi as FileInfo;
                        File.Delete(fsi.FullName);
                        l.Content = file.Directory.GetFileSystemInfos();
                    }
                }

                if (consoleKey.Key == ConsoleKey.F2)
                {
                    Console.Write("New name: ");
                    FileSystemInfo fsi2 = l.Content[l.selectedItem];
                    if (fsi2.GetType() == typeof(DirectoryInfo))
                    {
                        var folder2 = fsi2 as DirectoryInfo;
                        string path = Path.Combine(folder2.Parent.FullName, Console.ReadLine());
                        Directory.Move(folder2.FullName, path);
                        l.Content = folder2.Parent.GetFileSystemInfos();
                    }
                    else
                    {
                        var file2 = fsi2 as FileInfo;
                        string path2 = Path.Combine(file2.Directory.FullName, Console.ReadLine());
                        File.Move(file2.FullName, path2);
                        l.Content = file2.Directory.GetFileSystemInfos();
                    }
                }

                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    FileSystemInfo fsi3 = l.Content[l.selectedItem];
                    if (fsi3.GetType() == typeof(FileInfo))
                    {
                        farmode = Farmode.FileView;
                        FileStream fs = new FileStream(fsi3.FullName, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Console.Write(sr.ReadToEnd());
                        sr.Close();
                        fs.Close();
                    }

                    if (fsi3.GetType() == typeof(DirectoryInfo))
                    {
                        var folder3 = fsi3 as DirectoryInfo;
                        l.Content = folder3.GetFileSystemInfos();
                        l.selectedItem = 0;
                    }
                }

                if (consoleKey.Key == ConsoleKey.Backspace)
                {
                    FileSystemInfo fsi4 = l.Content[l.selectedItem];
                    if (fsi4.GetType() == typeof(DirectoryInfo))
                    {
                        DirectoryInfo folder4 = fsi4 as DirectoryInfo;
                        l.Content = folder4.Parent.Parent.GetFileSystemInfos();
                        l.selectedItem = 0;


                    }
                    if (fsi4.GetType() == typeof(FileInfo))
                    {
                        var file4 = fsi4 as FileInfo;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        farmode = Farmode.DirectiryView;

                    }
                }
                if (consoleKey.Key == ConsoleKey.Escape)
                    escape = true;
            }
        }
    }
}