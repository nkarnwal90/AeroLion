using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroLion.Models
{
    public class dbcontext: DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options):base(options)
        {

        }
        public DbSet<customers> customers { get; set; }
        public DbSet<Flights> flights { get; set; }
    }
}
