using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypesApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var student = new
            {
                Id = 1,
                FirstName = "Ashita",
                LastName = "Rathi",
                Address = new { Id = 1, City = "Jaipur", Country = "India" }
            };
            Console.WriteLine(student.Id);
            Console.WriteLine(student.FirstName); 
            Console.WriteLine(student.LastName);
            Console.WriteLine(typeof(student));

            List<Student> studentList = new List<Student>() 
            {
                new Student() { StudentID = 1, StudentName = "rst" },
                new Student() { StudentID = 2, StudentName = "lmn" },
                new Student() { StudentID = 3, StudentName = "xys" },
                new Student() { StudentID = 4, StudentName = "pqr" },
                new Student() { StudentID = 5, StudentName = "abc" }
            };

            var students = from s in studentList
                           select new { Id = s.StudentID, Name = s.StudentName };

            foreach (var stud in students)
                Console.WriteLine(stud.Id + "-" + stud.Name);
            Console.ReadLine();
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }
}
