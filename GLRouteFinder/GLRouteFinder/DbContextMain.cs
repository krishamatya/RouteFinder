using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace GLRouteFinder
{
    public class DbContextMain : DbContext
    {
        public DbContextMain(DbContextOptions<DbContextMain> options)
            : base(options)
        {
        }

        public DbSet<airlines> airlines { get; set; }
        public DbSet<airports> airports { get; set; }
        public DbSet<routes> routes { get; set; }
    }
}




