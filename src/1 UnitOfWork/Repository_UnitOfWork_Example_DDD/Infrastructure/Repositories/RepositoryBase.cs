using System.Linq.Expressions;
using Domain.Base;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly DbFactory _dbFactory;

    public RepositoryBase(DbFactory dbFactory)
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
            ((IDeleteEntity)entity).IsDeleted = true;
            Update(entity);
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

    public IQueryable<T> List(Expression<Func<T, bool>> expression)
    {
        return DbSet.Where(expression);
    }
}