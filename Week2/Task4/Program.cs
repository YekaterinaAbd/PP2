using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        { 
        
            string folderName = @"C:\Users\ и\Documents\PPP2";
            string pathString = Path.Combine(folderName, "path");
            pathString = Path.Combine(pathString, "file.txt");

            FileStream fs = File.Create(pathString);
            fs.Close();

            string pathString2 = Path.Combine(folderName, "path2");
            pathString2 = Path.Combine(pathString2, "file.txt");
            

            File.Move(pathString, pathString2);
            File.Delete(pathString);
          

           
        }
    }
}
