using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonClass
{
    public sealed class Singleton // sealed class
    {
        public int a;
        private Singleton() { } // private and parameterless constructor
        private static Singleton instance = null; // static variable to hold the single created instance
        public static Singleton Instance //public and static way of getting the reference to the created instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Singleton in = new Singleton();
            Singleton instance = Singleton.Instance;
            instance.a = 10;
            Console.WriteLine(instance.a);
            Console.ReadLine();
        }
    }
}
