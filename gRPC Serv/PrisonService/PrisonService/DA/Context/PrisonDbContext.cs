using Microsoft.EntityFrameworkCore;
using PrisonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonService.DA.Context
{
    public class PrisonDbContext : DbContext
    {

        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public PrisonDbContext(DbContextOptions<PrisonDbContext> options) : base(options)
        {

        }

    }
}
