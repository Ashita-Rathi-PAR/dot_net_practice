using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolApplication.Data;
using System;
using System.Linq;

namespace SchoolApplication.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StudentContext>>()))
            {
                // Look for any movies.
                if (context.Student.Any())
                {
                    return;   // DB has been seeded
                }

                context.Student.AddRange(
                    new Student
                    {
                        Id = 1,
                        DateOfBirth = DateTime.Parse("1989-2-12"),
                        Name = "Prachi",
                        Class = 2
                    },

                    new Student
                    {
                        Id = 2,
                        DateOfBirth = DateTime.Parse("1989-2-12"),
                        Name = "Mango",
                        Class = 6
                    },

                    new Student
                    {
                        Id = 3,
                        DateOfBirth = DateTime.Parse("2001-2-12"),
                        Name = "Tota",
                        Class = 8
                    },

                    new Student
                    {
                        Id = 4,
                        DateOfBirth = DateTime.Parse("2001-5-9"),
                        Name = "Baby",
                        Class = 6
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
