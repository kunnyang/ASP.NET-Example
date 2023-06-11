using System.Linq.Expressions;
using Repository_UnitOfWork_Example.Data;
using Repository_UnitOfWork_Example.Entities.Audit;
using Repository_UnitOfWork_Example.Entities.Delete;
using Repository_UnitOfWork_Example.IRepositories;

namespace Repository_UnitOfWork_Example.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        if (typeof(IAuditEntity).IsAssignableFrom(typeof(T))) ((IAuditEntity)entity).CreatedAt = DateTime.Now;

        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        if (typeof(IDeleteEntity).IsAssignableFrom(typeof(T)))
        {
            ((IDeleteEntity)entity).Deleted = true;
            _context.Set<T>().Update(entity);
        }
        else
        {
            _context.Set<T>().Remove(entity);
        }
    }

    public void Update(T entity)
    {
        if (typeof(IAuditEntity).IsAssignableFrom(typeof(T))) ((IAuditEntity)entity).UpdatedAt = DateTime.Now;
        _context.Set<T>().Update(entity);
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }
}