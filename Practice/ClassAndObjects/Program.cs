using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObjects
{
    public class Employee
    {
        public int id;
        public string name;
        public float salary;
        public static string company = "Punchh";
        public Employee(int id, String name, float salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
        public void display()
        {
            Console.WriteLine(id + "  " + name + "  " + salary);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee(101, "Ashita", 990000f);
            Employee e2 = new Employee(201, "Anjali", 690000f);
            e1.display();
            e2.display();
            Console.ReadLine();
        }
    }
}
