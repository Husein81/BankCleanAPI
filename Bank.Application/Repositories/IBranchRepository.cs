using Bank.Domain.Entities;
using Microsoft.Extensions.Hosting;

namespace Bank.Application.Repositories
{
    public interface IBranchRepository : IBaseRepository<Branch>
    {
        public Task<IEnumerable<Branch>> GetWholeAsync(CancellationToken cancellationToken);
        public Task<Branch> GetWholeByIdAsync(int id, CancellationToken cancellationToken);
    } 
}
