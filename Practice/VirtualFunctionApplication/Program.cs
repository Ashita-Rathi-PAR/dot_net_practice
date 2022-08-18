using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFunctionApplication
{
    class Shape
    {
        protected int width, height;

        public Shape(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public virtual void area()
        {
            Console.WriteLine("Parent class area :");
        }
    }
    class Rectangle : Shape
    {
        public Rectangle(int width, int heigt) : base(width, heigt)
        {

        } 
        public override void area()
        {
            Console.WriteLine("Rectangle class area :");
            Console.WriteLine(width * height);
        }
    }
    class Triangle : Shape
    {
        public Triangle(int width, int heigt) : base(width, heigt)
        {
        }
        public override void area()
        {
            Console.WriteLine("Triangle class area :");
            Console.WriteLine(width * height / 2);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(10, 10);
            r.area();
            Triangle t = new Triangle(10, 11);
            t.area();
            Console.ReadLine();
        }
    }
}
