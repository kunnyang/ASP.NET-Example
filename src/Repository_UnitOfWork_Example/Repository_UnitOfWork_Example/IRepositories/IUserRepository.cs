using Repository_UnitOfWork_Example.Entities.Models;

namespace Repository_UnitOfWork_Example.IRepositories;

public interface IUserRepository : IRepository<User>
{
    User AddUser(string username,
        string email,
        Department department);
}