using System.Linq.Expressions;

namespace Domain.Interfaces;

public interface IRepositoryBase<T>
{
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    IQueryable<T> List(Expression<Func<T, bool>> expression);
}