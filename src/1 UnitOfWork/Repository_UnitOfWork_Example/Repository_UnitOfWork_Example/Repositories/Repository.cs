using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repository_UnitOfWork_Example.Data;
using Repository_UnitOfWork_Example.Entities.Audit;
using Repository_UnitOfWork_Example.Entities.Delete;
using Repository_UnitOfWork_Example.IRepositories;

namespace Repository_UnitOfWork_Example.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbFactory _dbFactory;


    public Repository(DbFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    private DbSet<T> DbSet => _dbFactory.DbContext.Set<T>();

    public void Add(T entity)
    {
        if (typeof(IAuditEntity).IsAssignableFrom(typeof(T))) ((IAuditEntity)entity).CreatedAt = DateTime.Now;

        DbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        if (typeof(IDeleteEntity).IsAssignableFrom(typeof(T)))
        {
            ((IDeleteEntity)entity).Deleted = true;
            DbSet.Update(entity);
        }
        else
        {
            DbSet.Remove(entity);
        }
    }

    public void Update(T entity)
    {
        if (typeof(IAuditEntity).IsAssignableFrom(typeof(T))) ((IAuditEntity)entity).UpdatedAt = DateTime.Now;
        DbSet.Update(entity);
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return DbSet.Where(expression);
    }
}