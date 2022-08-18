using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Address address = new Address("Rajasthan","Jaipur",2);
            Employee employee = new Employee(1,"Ashita",address);
            employee.Display();
            Console.ReadLine();
        }
    }

    class Address
    {
        public string state { get; set; }
        public string city { get; set; }
        public int number { get; set; }
        public Address(string state, string city, int number)
        {
            this.state = state;
            this.city = city;
            this.number = number;
        }
    }

    class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public Address address { get; set; }

        public Employee(int id, string name, Address address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }

        public void Display()
        {
            Console.WriteLine(id + " " + name + " " + address.number + " " + address.city + " " + address.state);
        }
    }

}
