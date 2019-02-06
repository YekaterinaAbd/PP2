using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            F1();
        }

        private static void GetInfo(FileSystemInfo fsi, int k)
        {
            string res = new string(' ', k);
            res = res + fsi.Name;
            Console.WriteLine(res);

            if (fsi.GetType() == typeof(DirectoryInfo))
            {
                var items = (fsi as DirectoryInfo).GetFileSystemInfos();
                foreach(var i in items)
                {
                    GetInfo(i, k + 4);
                }
            }

        }

        private static void F1()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\ и\Documents\Visual Studio 2017\Samples");
            GetInfo(dir, 0);
        }

        
    }
}
