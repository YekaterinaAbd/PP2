using System;
using System.IO;

namespace Task2_1
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

        enum Farmode
        {
            DirectiryView,
            FileView
        }


        static void Main(string[] args)
        {
            string way = @"C:\Users\ и\Documents\PPP2";
            DirectoryInfo dir = new DirectoryInfo(way);
            FileSystemInfo[] Content = dir.GetFileSystemInfos();
            int selectedItem = 0;


            Farmode farmode = Farmode.DirectiryView;

            bool escape = false;
            while (!escape)
            {

                if (farmode == Farmode.DirectiryView)

                    Draw(Content, selectedItem);

                ConsoleKeyInfo consoleKey = Console.ReadKey();

                if (consoleKey.Key == ConsoleKey.UpArrow)
                {
                    if (selectedItem <= 0)
                    {
                        selectedItem = Content.Length - 1;
                    }
                    else selectedItem--;
                }

                if (consoleKey.Key == ConsoleKey.DownArrow)
                {
                    if (selectedItem >= Content.Length - 1)
                    {
                        selectedItem = 0;
                    }
                    else selectedItem++;
                }

                if (consoleKey.Key == ConsoleKey.Delete)
                {
                    FileSystemInfo fsi = Content[selectedItem];
                    if (fsi.GetType() == typeof(DirectoryInfo))
                    {
                        var folder = fsi as DirectoryInfo;
                        Directory.Delete(folder.FullName, true);
                        Content = folder.Parent.GetFileSystemInfos();

                    }
                    else if (fsi.GetType() == typeof(FileInfo))
                    {
                        var file = fsi as FileInfo;
                        File.Delete(fsi.FullName);
                        Content = file.Directory.GetFileSystemInfos();
                    }
                }

                if (consoleKey.Key == ConsoleKey.F2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("New name: ");

                    FileSystemInfo fsi2 = Content[selectedItem];
                    if (fsi2.GetType() == typeof(DirectoryInfo))
                    {
                        var folder2 = fsi2 as DirectoryInfo;
                        string path = Path.Combine(folder2.Parent.FullName, Console.ReadLine());
                        Directory.Move(folder2.FullName, path);
                        Content = folder2.Parent.GetFileSystemInfos();
                    }
                    else
                    {
                        var file2 = fsi2 as FileInfo;
                        string path2 = Path.Combine(file2.Directory.FullName, Console.ReadLine());
                        File.Move(file2.FullName, path2);
                        Content = file2.Directory.GetFileSystemInfos();
                    }
                }

                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    
                    FileSystemInfo fsi3 = Content[selectedItem];

                    if (fsi3.GetType() == typeof(DirectoryInfo))
                    {
                        var folder3 = fsi3 as DirectoryInfo;

                        if (folder3.GetFileSystemInfos().Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.SetCursorPosition(folder3.Name.Length + 5, selectedItem);
                            Console.Write("Folder is empty");
                            Console.ReadKey();
                        }
                        else
                        {
                            Content = folder3.GetFileSystemInfos();
                            selectedItem = 0;
                        }
                    }

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
                }

                if (consoleKey.Key == ConsoleKey.Backspace)
                {
                    FileSystemInfo fsi4 = Content[selectedItem];
                    if (fsi4.GetType() == typeof(DirectoryInfo))
                    {
                        DirectoryInfo folder4 = fsi4 as DirectoryInfo;
                        string current = folder4.Parent.Parent.FullName;
                        bool b = current.Contains(way);

                        if (b == true)
                        {
                            Content = folder4.Parent.Parent.GetFileSystemInfos();
                            selectedItem = 0;
                        }

                        else { }                     
                        
                    }
                        if (fsi4.GetType() == typeof(FileInfo))
                        {
                            var file4 = fsi4 as FileInfo;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            farmode = Farmode.DirectiryView;

                            Content = file4.Directory.GetFileSystemInfos();
                        }
                    }
                    if (consoleKey.Key == ConsoleKey.Escape)
                        escape = true;
                }
            }

        }
    }


/*works:
 * Delete 
 * F2 
 * UppArrow 
 * DownArrow 
 * Enter 
 */

// Backspace works only if i don't open empty folders