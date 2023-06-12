using Domain.Departments;

namespace Domain.Users;

public interface IUserRepository
{
    User NewUser(string userName,
        string userEmail,
        Department department);
}