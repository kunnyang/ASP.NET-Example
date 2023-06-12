using Domain.Departments;
using Domain.Users;

namespace Infrastructure.Repositories;

public class UserRepositoryBase : RepositoryBase<User>, IUserRepository
{
    public UserRepositoryBase(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public User NewUser(string userName,
        string userEmail,
        Department department)
    {
        var user = new User(userName, userEmail, department);

        Add(user);
        return user;
    }
}