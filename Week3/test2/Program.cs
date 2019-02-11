using System;
using System.IO;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = @"C:\Users\ и\Documents\PPP2";
            DirectoryInfo fsi2 = new DirectoryInfo(folder);
            //string folder2 = Path.Combine(folder, "filetorename.txt");
            //FileStream fs = File.Create(folder2);
            //fs.Close();
            string folder3 = Path.Combine(folder, Console.ReadLine());
            //string folder3 = Path.Combine(folder, "renamedfile.txt");
            //File.Move(folder2, folder3);

            string folder12 = Path.Combine(folder, "foldertorename");
            Directory.CreateDirectory(folder12);
            Directory.Move(folder12, folder3);
        }
    }
}
