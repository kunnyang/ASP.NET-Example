using Microsoft.EntityFrameworkCore;
using Repository_UnitOfWork_Example.Data;
using Repository_UnitOfWork_Example.IRepositories;
using Repository_UnitOfWork_Example.Repositories;
using Repository_UnitOfWork_Example.Services;

namespace Repository_UnitOfWork_Example.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(o =>
        {
            o.UseSqlServer(configuration.GetConnectionString("AppDbContext"));
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IUnitOfWork,UnitOfWork>()
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<IDepartmentRepository, DepartmentRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ISalaryRepository, SalaryRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<DepartmentService>();

        return services;
    }
}