using Microsoft.EntityFrameworkCore;


namespace Banks
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public CustomerDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Branches.db"));
        }

    }
}
