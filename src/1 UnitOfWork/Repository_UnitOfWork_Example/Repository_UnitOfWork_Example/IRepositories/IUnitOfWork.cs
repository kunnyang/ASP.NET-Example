using Repository_UnitOfWork_Example.Data;

namespace Repository_UnitOfWork_Example.IRepositories;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}

internal class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}