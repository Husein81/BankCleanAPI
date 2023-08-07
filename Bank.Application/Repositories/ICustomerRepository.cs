using Bank.Domain.Entities;

namespace Bank.Application.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetWholeAsync(CancellationToken cancellationToken);
        Task<Customer> GetWholeByIdAsync(int id,CancellationToken cancellationToken);
    }
}
