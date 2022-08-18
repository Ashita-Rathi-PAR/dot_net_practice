using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic d = 1;
            Console.WriteLine("Value: {0}, Type: {1}", d, d.GetType());

            d = "Ashita";
            Console.WriteLine("Value: {0}, Type: {1}", d, d.GetType());

            d = 3.4F;
            Console.WriteLine("Value: {0}, Type: {1}", d, d.GetType());

            d = 123654l;
            Console.WriteLine("Value: {0}, Type: {1}", d, d.GetType());

            d = true;
            Console.WriteLine("Value: {0}, Type: {1}", d, d.GetType());

            d = DateTime.Now;
            Console.WriteLine("Value: {0}, Type: {1}", d, d.GetType());

            Console.ReadLine();
        }
    }
}
