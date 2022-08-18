using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputEmail = Console.ReadLine();
            string email = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex r = new Regex(email);
            if r.IsMatch()
            {
                Console.WriteLine("Yes");
            }
        }
    }
}
