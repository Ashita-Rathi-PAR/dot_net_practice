using Microsoft.EntityFrameworkCore;
using CompanyApp.Models;

namespace CompanyApp.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee>? Employee { get; set; }

    }
}
