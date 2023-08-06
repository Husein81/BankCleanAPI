using Bank.Application.Repositories;
using Bank.Domain;

using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using Bank.Infrastructure.Exceptions;


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
            => await _customer.Include(x => x.Branches).ToListAsync(cancellationToken);

        public async Task<Customer> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
            => await _customer.Include(x => x.Id).FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                ?? throw new NotFoundException(typeof(Customer).Name, id);

        Task<IEnumerable<Customer>> ICustomerRepository.GetWholeByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
