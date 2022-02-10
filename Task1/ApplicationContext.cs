using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Models;
using Microsoft.EntityFrameworkCore;

namespace Task1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-Q7KMHMBE\\WORK;Database=Test01;Trusted_Connection=True;");
        }
    }
}
