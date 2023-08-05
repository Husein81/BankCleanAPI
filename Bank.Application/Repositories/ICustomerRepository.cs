using Bank.Domain;

namespace Bank.Application.Repositories
{
   public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetWholeAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Customer>> GetWholeByIdAsync(int id,CancellationToken cancellationToken);
    }
}
