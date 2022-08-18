using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paramsParameterApplication
{
    internal class Program
    {
        public void Show(params int[] val)
        {
            for (int i = 0; i < val.Length; i++)
            {
                Console.WriteLine(val[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Show(1, 2, 4, 5, 3, 6, 7, 8, 9);
            p.Show(5, 6, 7);
            Console.ReadLine();
        }
    }
}
