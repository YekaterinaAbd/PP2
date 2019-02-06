using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            WritePrimes();
        }

        private static bool IsPrime(int a)
        {
            if (a == 1) return false;
            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        private static string F2(string input)
        {
            string primes = "";
            string[] nums = input.Split();
            foreach (var num in nums)
            {
                int x = int.Parse(num);
                if (IsPrime(x))
                {
                    primes = primes + " " + num;
                }
            }
            return primes.Trim();
        }


        private static void WritePrimes(){
            FileStream fs = new FileStream(@"C:\Users\ и\Documents\read\read.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string numbers = sr.ReadLine();

            sr.Close();
            fs.Close();

            string primes = F2(numbers);

            FileStream fs2 = new FileStream(@"C:\Users\ и\Documents\read\write.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs2);
            sw.WriteLine(primes);
            sw.Close();
            fs2.Close();
            
            }
    

           
    }
    }

