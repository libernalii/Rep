using BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class SchooleContext : DbContext
    {
        public SchooleContext(DbContextOptions<SchooleContext> options)
        : base(options)
        {

        }
        public SchooleContext()
        {

        }
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolDB;Integrated Security=True;");
            }
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Student>().Property(s => s.Grade).HasDefaultValue(0).IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Student>().HasOne<Teacher>().WithMany().HasForeignKey(s => s.TeacherId).IsRequired();
            //modelBuilder.Entity<Student>().HasOne<Student>().WithMany().IsRequired();


            modelBuilder.Entity<Teacher>().HasKey(s => s.Id);
            modelBuilder.Entity<Teacher>().Property(s => s.Subject).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Teacher>().Property(s => s.Name).HasMaxLength(100).IsRequired();
        }
    }
}
