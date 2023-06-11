using System.Linq.Expressions;

namespace Repository_UnitOfWork_Example.IRepositories;

public interface IRepository<TEntity> where TEntity : class
{
    void Add(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
}