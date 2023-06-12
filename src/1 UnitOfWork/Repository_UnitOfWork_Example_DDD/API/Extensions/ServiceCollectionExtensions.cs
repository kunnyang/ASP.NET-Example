using API.Services;
using Domain.Departments;
using Domain.Interfaces;
using Domain.Salaries;
using Domain.Users;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.IServiceCollectionExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataBase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(o =>
        {
            o.UseSqlServer(configuration.GetConnectionString("AppDbContext"));
        });

        // services.AddScoped<Func<AppDbContext>>((provider) => () => provider.GetService<AppDbContext>());
        services.AddScoped<Func<AppDbContext>>(provider => provider.GetRequiredService<AppDbContext>);
        services.AddScoped<DbFactory>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
            .AddScoped<IDepartmentRepository, DepartmentRepositoryBase>()
            .AddScoped<IUserRepository, UserRepositoryBase>()
            .AddScoped<ISalaryRepository, SalaryRepositoryBase>();
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddScoped<DepartmentService>();
    }
}