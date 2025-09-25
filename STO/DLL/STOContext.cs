using DLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class STOContext : DbContext
    {
        public STOContext(DbContextOptions<STOContext> options) : base(options)
        {

        }
        public STOContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StoDB;Integrated Security=True;");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasKey(c => c.Id);
            modelBuilder.Entity<Car>().Property(c => c.Brand).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Model).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Year).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Price).IsRequired();
        }
    }
}
