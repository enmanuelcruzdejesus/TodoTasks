using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoTasks.Models;

namespace TodoTasks.Services
{
    public class DatabaseContext: DbContext
    {
        private string _dbPath;
        public DbSet<Tasks> Tasks { get; set; }
        public DatabaseContext(string dbPath)
        {
            this._dbPath = dbPath;
            Database.EnsureCreated();

        }

        public DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tasks>()
           .HasKey(c => c.taskid);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
