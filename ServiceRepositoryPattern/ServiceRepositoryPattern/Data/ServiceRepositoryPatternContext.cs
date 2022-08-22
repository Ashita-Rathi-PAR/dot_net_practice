using Microsoft.EntityFrameworkCore;
using ServiceRepositoryPattern.Models;

namespace ServiceRepositoryPattern.Data
{
    public class ServiceRepositoryPatternContext : DbContext
    {

        public ServiceRepositoryPatternContext(DbContextOptions<ServiceRepositoryPatternContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FoodItem>? FoodItem { get; set; }
        public virtual DbSet<Ticket>? Ticket{ get; set; }
    }
}
