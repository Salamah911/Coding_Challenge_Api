using Coding.Challenge.Migration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Coding.Challenge.Migration
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Currencies> Currencies { get; set; }
    }
}