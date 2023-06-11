using Microsoft.EntityFrameworkCore;
using Repository_UnitOfWork_Example.Entities.Models;

namespace Repository_UnitOfWork_Example.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Department> Departments { get; set; } = default!;
    public DbSet<Salary> Salaries { get; set; } = default!;
}