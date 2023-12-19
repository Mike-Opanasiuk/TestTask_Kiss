using Api.Entities.Abstract;

namespace Api.Repository.Abstract;

public interface IRepository<TEntity> where TEntity : IEntity
{
    IQueryable<TEntity> Get();
    Task<TEntity> FindAsync(Guid id);
    Task<TEntity> InsertAsync(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
}