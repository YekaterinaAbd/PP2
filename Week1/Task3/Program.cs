using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading the first line and converting it to int
            //reading the second line
            int number = int.Parse(Console.ReadLine());
            string a = Console.ReadLine();

            //creation array of strings by separating every number using split
            string[] nums = a.Split();
            
            //converting every element to int printing every element two times
            foreach(string num in nums)
            {
                int.Parse(num);
                Console.Write(num + " " + num + " " );
            }
        }
    }
}
