using Bank.Application.Repositories;
using Bank.Domain;

using SQLitePCL;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Repositories
{
    internal class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Branch> _branch;
        public BranchRepository(AppDbContext context, DbSet<Branch> branch)
        {
            _context = context;
            _branch = _context.Set<Branch>();
        }
        public async Task<Branch> AddAsync(Branch branch)
        {
            var addedbranch=await _branch.AddAsync(branch);
            await _context.SaveChangesAsync();
            return addedbranch;
        }
    }
}
