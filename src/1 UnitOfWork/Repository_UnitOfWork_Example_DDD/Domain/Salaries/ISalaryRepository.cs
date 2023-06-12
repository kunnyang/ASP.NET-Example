using Domain.Users;

namespace Domain.Salaries;

public interface ISalaryRepository
{
    Salary AddUserSalary(User user,
        float coefficientsSalary,
        float workdays);
}