using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexersApplication
{
    class Indexers
    {

        private string[] val = new string[3];

        public string this[int index]
        {

            get
            {
                return val[index];
            }

            set
            {
                val[index] = value+1;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Indexers i = new Indexers();
            i[0] = "1";
            i[1] = "2";
            i[2] = "3";

            Console.WriteLine("First value = {0}", i[0]);
            Console.WriteLine("Second value = {0}", i[1]);
            Console.WriteLine("Third value = {0}", i[2]);
            Console.ReadLine();
        }
    }
}
