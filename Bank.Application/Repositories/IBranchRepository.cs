using Bank.Domain;

namespace Bank.Application.Repositories
{
    public interface IBranchRepository : IBaseRepository<Branch>
    {
        Task<Branch> AddBranchAsync(int id, string name, string address, double assets);
        Task<Branch> DeleteBranchAsync(int id);
    } 
}
