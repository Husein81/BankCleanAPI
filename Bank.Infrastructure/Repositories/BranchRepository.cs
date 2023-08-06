using Bank.Application.Repositories;
using Bank.Domain;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using Bank.Infrastructure.Exceptions;
using Microsoft.Extensions.Hosting;

namespace Bank.Infrastructure.Repositories
{
    internal class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Branch> _branch;
        public BranchRepository(AppDbContext context) : base(context) 
        {
            _context = context;
            _branch = _context.Set<Branch>();
        }
        public async Task<IEnumerable<Branch>> GetWholeAsync(CancellationToken cancellationToken)
            => await _branch.Include(x=>x.Customers).ToListAsync(cancellationToken);

        public async Task<Branch> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
            => await _branch.Include(x => x.Customers)
                             .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                        ?? throw new NotFoundException(typeof(Branch).Name, id);
    }
}
