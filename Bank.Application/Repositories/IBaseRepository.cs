
namespace Bank.Application.Repositories
{
   public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
