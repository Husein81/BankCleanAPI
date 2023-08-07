using Bank.Application.Repositories;

using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using Bank.Infrastructure.Exceptions;
using Bank.Domain.Entities;

namespace Bank.Infrastructure.Repositories
{
    internal class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Customer> _customer;
        public CustomerRepository(AppDbContext context) : base(context) 
        {
            _context = context;
            _customer = _context.Set<Customer>();
        }
        public async Task<IEnumerable<Customer>> GetWholeAsync(CancellationToken cancellationToken)
            => await _customer.ToListAsync(cancellationToken);

        public async Task<Customer> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
            => await _customer.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                ?? throw new NotFoundException(typeof(Customer).Name, id);

    }
}
