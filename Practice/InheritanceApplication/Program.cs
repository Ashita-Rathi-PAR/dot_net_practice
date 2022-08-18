using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Puppy puppy = new Puppy();
            puppy.Name = "Lovely";
            puppy.cry();
            puppy.bark();
            puppy.eat();
            Console.ReadLine();

        }
    }

    class Animal 
    {
        public string Name { get; set; }
        public void eat() 
        {
            Console.WriteLine("Eating");
        }
    }

    class Dog : Animal
    {
        public void bark()
        {
            Console.WriteLine("Barking");
        }
    }

    class Puppy : Dog
    {
        public void cry()
        {
            Console.WriteLine("Crying");
        }
    }

} 
