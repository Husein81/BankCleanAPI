using Microsoft.EntityFrameworkCore;
using Bank.Domain.Entities;

namespace Bank.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public AppDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Branches.db"));
        }

    }
}
