using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        //creation of a function which checks if the number is prime
        
        static bool IsPrime(int n)
        {
            if (n == 1) return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)

                    return false;

            }

            return true;

        }
        static void Main(string[] args)
        {
            //reading the first and the second line from console
            //converting the first string to int 
            int line1 = int.Parse(Console.ReadLine());
            string line2 = Console.ReadLine();

            //creating the array of strings - separation the elements of a string using Split function
            string[] nums = line2.Split();

            //creating a container list, where prime numbers of array nums will be kept
            List<int> primes = new List<int>(); 

            //converting every element of the array from string to int, checking if the number is prime
            //adding prime numbers to the list
            for (int i = 0; i < nums.Length; i++)
            {
                int x = int.Parse(nums[i]);
                if (IsPrime(x))
                {
                    primes.Add(x);
                }

            }
            //printing the quantity of prime numbers
            Console.WriteLine(primes.Count);

            //printing all prime numbers
            foreach(int prime in primes)
            {
                Console.Write(prime + " ");
            }

        }
    }
}

