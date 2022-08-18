using System;
using System.Text;
using System.Linq;

namespace StringWithUniqueCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a String : ");
            string input = Console.ReadLine();
            string resultString = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (!resultString.Contains(input[i]))
                {
                    resultString += input[i];
                }
            }
            Console.WriteLine(resultString);
            Console.ReadLine();
        }
    }
}
