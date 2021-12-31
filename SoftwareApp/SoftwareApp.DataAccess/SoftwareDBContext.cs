using Microsoft.EntityFrameworkCore;
using SoftwareApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareApp.DataAccess
{
    public class SoftwareDBContext : DbContext
    {
        public SoftwareDBContext(string connectionString) : base(GetOptions(connectionString))
        {

        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }

        public DbSet<Software> Software { get; set; }

        public DbSet<Platform> Platform { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<SoftwareType> SoftwareType { get; set; }

    }
}
