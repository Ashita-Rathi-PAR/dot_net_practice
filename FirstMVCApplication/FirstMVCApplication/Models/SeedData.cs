using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FirstMVCApplication.Data;
using System;
using System.Linq;

namespace FirstMVCApplication.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FirstMVCApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FirstMVCApplicationContext>>()))
            {
                // Look for any movies.
                if (context.Girl.Any())
                {
                    return;   // DB has been seeded
                }

                context.Girl.AddRange(
                    new FirstMVCApplication.Models.Girl
                    {
                        Id = 1,
                        Name = "Ashita",
                        DateOfBirth = DateTime.Parse("2001-1-05"),
                    },

                    new FirstMVCApplication.Models.Girl
                    {
                        Id = 2,
                        Name = "Priya",
                        DateOfBirth = DateTime.Parse("2001-1-15"),
                    },

                    new FirstMVCApplication.Models.Girl
                    {
                        Id = 3,
                        Name = "Anjali",
                        DateOfBirth = DateTime.Parse("2000-7-12"),
                    },

                    new FirstMVCApplication.Models.Girl
                    {
                        Id = 4,
                        Name = "Kajal",
                        DateOfBirth = DateTime.Parse("2000-12-22"),
                    },

                    new FirstMVCApplication.Models.Girl
                    {
                        Id = 5,
                        Name = "Bhavika",
                        DateOfBirth = DateTime.Parse("2001-04-15"),
                    },

                    new FirstMVCApplication.Models.Girl
                    {
                        Id = 6,
                        Name = "Aakansha",
                        DateOfBirth = DateTime.Parse("2000-0-5"),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}