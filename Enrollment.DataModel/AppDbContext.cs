using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment.DataModel
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=XAVIER\\MSSQLSERVER01;" +
                "Database=xavier_entprog;Integrated Security=SSPI;" +
                "TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().ToTable("tblStudent");
            modelBuilder.Entity<Student>().Property(p => p.LastName).HasColumnName("Surname");
            modelBuilder.Entity<Student>().Property(p => p.FirstName).HasColumnName("Given Name");
            modelBuilder.Entity<Student>().Property(p => p.LastName).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Student>().Property(p => p.FirstName).HasColumnType("nvarchar(50)");

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                LastName = "Zapata",
                FirstName = "Xavier"
            });

            modelBuilder.Entity<Subject>().Property(p => p.Code).HasColumnType("nvarchar(7)");
            modelBuilder.Entity<Subject>().Property(p => p.Discription).HasColumnType("nvarchar(7)");
            modelBuilder.Entity<Subject>().Property(p => p.Units).HasColumnType("decimal(18, 1)");


        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}
