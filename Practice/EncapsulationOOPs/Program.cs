using System;

namespace EncapsulationOOPs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Square s = new Square();
            s.side = 5;
            s.Display();
            Console.ReadLine();

            Rectangle r = new Rectangle();
            r.Acceptdetails();
            r.Display();
            Console.ReadLine();

            Triangle t = new Triangle();
            t.baseoftriangle = 6;
            t.height = 5;
            t.Display();
            Console.ReadLine();
        }
    }

    class Square
    {
        public double side;
        public double GetArea()
        {
            return side * side;
        }
        public void Display()
        {
            Console.WriteLine("Side: {0}", side);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
    class Rectangle
    {
        private double length;
        private double width;

        public void Acceptdetails()
        {
            Console.WriteLine("Enter Length: ");
            length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Width: ");
            width = Convert.ToDouble(Console.ReadLine());
        }
        public double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }

    class Triangle
    {
        internal double baseoftriangle;
        internal double height;

        double GetArea()
        {
            return 0.5* baseoftriangle * height;
        }
        public void Display()
        {
            Console.WriteLine("Base: {0}", baseoftriangle);
            Console.WriteLine("Height: {0}", height);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
}