using Domain.Salaries;
using Domain.Users;

namespace Infrastructure.Repositories;

public class SalaryRepositoryBase : RepositoryBase<Salary>, ISalaryRepository
{
    public SalaryRepositoryBase(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public Salary AddUserSalary(User user,
        float coefficientsSalary,
        float workdays)
    {
        var salary = new Salary(user, coefficientsSalary, workdays);
        Add(salary);
        return salary;
    }
}