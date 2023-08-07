using Microsoft.EntityFrameworkCore;
using Bank.Application.Repositories;
using Bank.Domain;
using Bank.Infrastructure.Exceptions;


namespace Bank.Infrastructure.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
             => await _dbSet.ToListAsync(cancellationToken);
        public async Task<TEntity> GetByIdAsync(int id,CancellationToken cancellationToken) 
            => await _dbSet.FindAsync(new object?[] {id}, cancellationToken)
            ?? throw new NotFoundException(typeof(TEntity).Name,id);

        public async Task<TEntity>AddAsync(TEntity entity,CancellationToken cancellationToken)
        {
            var createdEntity =await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return createdEntity.Entity;
        }
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var deletedentity = await GetByIdAsync(id, cancellationToken);
            _dbSet.Remove(deletedentity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var updatedEntity = _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return updatedEntity.Entity;
        }

    }
}
