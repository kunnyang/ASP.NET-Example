using Repository_UnitOfWork_Example.Data;
using Repository_UnitOfWork_Example.Entities.Models;
using Repository_UnitOfWork_Example.IRepositories;

namespace Repository_UnitOfWork_Example.Repositories;

internal class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public User AddUser(string username,
        string email,
        Department department)
    {
        var user = new User
        {
            UserName = username,
            Email = email,
            DepartmentId = department.Id,
            Department = department
        };
        Add(user);
        return user;
    }
}