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

            //creation a new array, where repeated elements will be
            string[] answ = new string[nums.Length * 2];
            
            //nums[0] = answ[0] & answ[1]
            //nums[1] = answ[2] & answ[3]

           for(int i=0; i<nums.Length; i++)
            {
                answ[2 * i] = answ[2 * i + 1] = nums[i];
            }

           //writing each element of an array "answ"
           foreach(string i in answ)
            {
                Console.Write(i + " ");
            }
            
        }
    }
}
