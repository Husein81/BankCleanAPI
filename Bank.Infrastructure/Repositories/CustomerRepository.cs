using Bank.Application.Repositories;
using Bank.Domain;

using SQLitePCL;
using Microsoft.EntityFrameworkCore;


namespace Bank.Infrastructure.Repositories
{
    internal class CustomerRepository : BaseRepository<Customer>, IBranchRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Customer> _customer;
        public CustomerRepository(AppDbContext context, DbSet<Customer> customer)
        {
            _context = context;
            _customer = _context.Set<Customer>();
        }
        public async Task<Customer> AddAsync(Customer customer)
        {
            var addedcustomer = await _customer.AddAsync(customer);
            await _context.SaveChangesAsync();
            return addedcustomer;
        }
    }
}
