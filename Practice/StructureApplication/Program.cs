using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureApplication
{
    struct Employee
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public string Location { get; set; }

        /*public Employee()
        {
            this.Name = "ashita";    
        }*/
        public Employee(string Name, int EmployeeId, string Location)
        {
            this.Name = Name;
            this.EmployeeId = EmployeeId;
            this.Location = Location;
        }
    };
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee("Ashita",1,"Jaipur");
            Console.WriteLine(employee1.Name + " "+ employee1.EmployeeId + " " + employee1.Location);
            Console.ReadLine();
        }
    }
}
