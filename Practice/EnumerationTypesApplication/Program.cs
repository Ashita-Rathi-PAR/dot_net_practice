using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationTypesApplication
{
    internal class Program
    {
        enum WeekDays
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
        };
        static void Main(string[] args)
        {
            Console.WriteLine(WeekDays.Sunday);
            Console.WriteLine(WeekDays.Monday);
            Console.WriteLine(WeekDays.Tuesday);
            Console.WriteLine(WeekDays.Wednesday);
            Console.WriteLine(WeekDays.Thursday);
            Console.WriteLine(WeekDays.Friday);
            Console.WriteLine(WeekDays.Saturday);

            Console.WriteLine((int)WeekDays.Sunday); //enum to int
            Console.WriteLine((int)WeekDays.Monday);
            Console.WriteLine((int)WeekDays.Tuesday);
            Console.WriteLine((int)WeekDays.Wednesday);
            Console.WriteLine((int)WeekDays.Thursday);
            Console.WriteLine((int)WeekDays.Friday);
            Console.WriteLine((int)WeekDays.Saturday); 

            Console.WriteLine((WeekDays)5); // int to enum

            Console.ReadLine();
        }
    }
}
