using Microsoft.EntityFrameworkCore;

namespace Repository_UnitOfWork_Example.Data;

public class DbFactory : IDisposable
{
    private bool _disposed;

    public DbFactory(Func<AppDbContext> dbContextFactory)
    {
        DbContext = dbContextFactory.Invoke();
    }

    public DbContext DbContext { get; }

    public void Dispose()
    {
        if (_disposed) return;

        _disposed = true;
        DbContext.Dispose();
    }
}