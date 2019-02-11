using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 3, 5, 7 };
            for(int i=0; i<nums.Length; i++)
            {
                for(int j=i+1; j<nums.Length; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        var t = nums[j];
                        nums[j] = nums[i];
                        nums[i] = t;


                    }
                }
            }
            foreach(int i in nums)
            {
                Console.Write(i + " ");
            }

        }
    }
}
