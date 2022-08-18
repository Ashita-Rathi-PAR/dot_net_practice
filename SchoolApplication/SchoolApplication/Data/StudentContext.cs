using Microsoft.EntityFrameworkCore;
using SchoolApplication.Models;

namespace SchoolApplication.Data
{
    public class StudentContext : DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        //public DbSet<SchoolApplication.Models.Student> Student { get; set; } = default!;

        public virtual DbSet<Student> Student { get; set; }
    }
}
