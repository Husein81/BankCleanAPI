using Bank.Domain;

namespace Bank.Application.Repositories
{
   public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> AddCustomerAsync(int id,string name,string address);
        Task<Customer> RemoveCustomerAsync(int id);
    }
}
