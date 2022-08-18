using System;
using System.Linq;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice = "yes";
            while (choice.Equals("yes") || choice.Equals("Yes"))
            {
                Console.WriteLine("Enter a number");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Length:");
                int len = Convert.ToInt32(Console.ReadLine());

                int[] array_of_multiples = new int[len];
                for (int i = 0; i < len; i++) 
                {
                    array_of_multiples[i] = num * (i+1);
                }

                foreach(int i in array_of_multiples)
                {
                    Console.Write(i+" ");
                }

                Console.WriteLine(array_of_multiples.Max());
                Console.WriteLine(array_of_multiples.Min());
                Console.WriteLine(array_of_multiples.Average());
                //Array.Sort(array_of_multiples);
                //Console.WriteLine(array_of_multiples);
                Array.Reverse(array_of_multiples);

                foreach (int i in array_of_multiples)
                {
                    Console.Write(i + " ");
                }
                
                Console.WriteLine("\n\nEnter Choice:");
                choice = Console.ReadLine();

            }

        }
    }
}
