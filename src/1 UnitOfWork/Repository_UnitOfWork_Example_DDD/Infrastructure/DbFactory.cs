using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DbFactory : IDisposable
{
    private readonly Func<AppDbContext> _func;
    private DbContext? _dbContext;
    private bool _disposed;

    public DbFactory(Func<AppDbContext> func)
    {
        _func = func;
    }

    public DbContext DbContext
    {
        get
        {
            if (_dbContext is null)
            {
                Console.WriteLine("invoke");

                _dbContext = _func.Invoke();
            }

            return _dbContext;
        }
    }

    public void Dispose()
    {
        if (_disposed || _dbContext is null) return;
        _disposed = true;
        _dbContext?.Dispose();
    }
}