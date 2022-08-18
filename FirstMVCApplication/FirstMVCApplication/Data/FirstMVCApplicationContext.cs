using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstMVCApplication.Models;

namespace FirstMVCApplication.Data
{
    public class FirstMVCApplicationContext : DbContext
    {
        public FirstMVCApplicationContext (DbContextOptions<FirstMVCApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<FirstMVCApplication.Models.Girl> Girl { get; set; } = default!;
    }
}
