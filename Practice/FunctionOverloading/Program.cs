using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print p = new Print();
            p.print(1);
            p.print(2,"Ashita");
            p.print(3.4f);
            Console.ReadLine();
        }
    }

    class Print
    { 
        public void print(int a)
        {
            Console.WriteLine(a);
        }
        
        public void print(int a, string b)
        {
            Console.WriteLine(a+b);
        }

        public void print(float c)
        {
            Console.WriteLine(c);
        }
    }
}
