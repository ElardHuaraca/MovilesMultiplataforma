using Lab14.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab14.DataContext
{
    public class AppDBContext : DbContext
    {
        string DbPath = string.Empty;

        public AppDBContext(string dbPath)
        {
            this.DbPath = dbPath;
        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }

    }
}
