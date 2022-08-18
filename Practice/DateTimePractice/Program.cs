using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter date in format {mm/dd/yyyy}:");
            string input_date = Console.ReadLine();
            DateTime dt;

            var isValidDate = DateTime.TryParse(input_date, out dt);

            if (isValidDate)
            {
                Console.WriteLine("Today:"+ dt.ToShortDateString());
                TimeSpan ts = new TimeSpan(7, 0, 0, 0);
                DateTime weekDate = dt.Add(ts);
                Console.WriteLine("One Week Later:"+weekDate.ToShortDateString());
            }
            else
            {
                Console.WriteLine("Enter a valid date");
            }
            Console.ReadLine();

        }
    }
}
