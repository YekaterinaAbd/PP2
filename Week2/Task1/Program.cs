using System;
using System.IO;

namespace Task1
{
    class Program
    {

        static void Main(string[] args)
        {
            F1();
        }

        private static bool isPal(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[s.Length - i - 1]) return false;
            }
            return true;

        }
        private static void F1()
        {
            FileStream fs = new FileStream(@"C:\Users\ и\Documents\read\read.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            sr.Close();
            fs.Close();

            if (isPal(line)) Console.WriteLine("Yes");
            else Console.WriteLine("No");
            
        }
    }
}

        

