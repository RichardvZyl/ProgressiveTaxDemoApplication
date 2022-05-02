namespace Abstractions.Generics;

public interface IGenericRepository<TEntity, TId>
{
    Task<TId> CreateAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(TId id);
    Task<IEnumerable<TEntity>> ListAsync();
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TId id);

    Task<IDictionary<TId, TEntity>> GetTableAsync();
}
