using System;
using System.Text.RegularExpressions;

namespace RegexPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter PIN:");
            string pin = Console.ReadLine();
            if (Regex.IsMatch(pin, "^(\\d{4}|\\d{6})$"))
            {
                Console.WriteLine("Valid ATM PIN");
            }
            else
            {
                Console.WriteLine("InValid ATM PIN");
            }
            Console.ReadLine();
        }
    }
}
   