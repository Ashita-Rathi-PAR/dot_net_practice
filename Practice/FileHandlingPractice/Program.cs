using System;
using System.IO;

namespace FileHandlingPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream(@"C:\Users\rathia\practice.txt", FileMode.Open, FileAccess.ReadWrite);
            //StreamWriter s = new StreamWriter(file);
            //s.WriteLine("Nature is beautiful, yet it is.The primary source of life on Earth is the components that exist naturally. Their primary goal is to introduce their children to the benefits of natural beauty. 1234567890");
            //s.Close();

            StreamReader sr = new StreamReader(file);
            string para = sr.ReadLine();
            Console.WriteLine(para);
            int len = para.Length;
            int alphabet = 0;
            int specialchar = 0;
            int digit = 0;

            for (int l = 0; l < len; l++)
            {
                if ((para[l] >= 'a' && para[l] <= 'z') || (para[l] >= 'A' && para[l] <= 'Z'))
                {
                    alphabet++;
                }
                else if (para[l] >= '0' && para[l] <= '9')
                {
                    digit++;
                }
                else
                {
                    specialchar++;
                }
            }

            sr.Close();
            file.Close();
            Console.Write("Number of Alphabets in the string is : {0}\n", alphabet);
            Console.Write("Number of Digits in the string is : {0}\n", digit);
            Console.Write("Number of Special characters in the string is : {0}\n\n", specialchar);
            Console.ReadLine();
        }
    }
}
