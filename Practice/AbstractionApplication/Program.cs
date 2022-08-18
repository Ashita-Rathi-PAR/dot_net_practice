using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionApplication
{
    public abstract class Shape
    {
        public abstract void draw();
    }
    public class Rectangle : Shape
    {
        public override void draw()
        {
            Console.WriteLine("Rectangle");
        }
    }
    public class Circle : Shape
    {
        public override void draw()
        {
            Console.WriteLine("Circle");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape s = new Rectangle();
            s.draw();
            Shape s1 = new Circle();
            s1.draw();
            Console.ReadLine();
        }
    }
}
