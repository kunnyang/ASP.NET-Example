using Repository_UnitOfWork_Example.Data;
using Repository_UnitOfWork_Example.Entities.Models;
using Repository_UnitOfWork_Example.IRepositories;

namespace Repository_UnitOfWork_Example.Repositories;

internal class SalaryRepository : Repository<Salary>, ISalaryRepository
{
    public SalaryRepository(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public Salary AddSalary(User user,
        float coefficientsSalary,
        float workdays)
    {
        var salary = new Salary
        {
            CoefficientsSalary = coefficientsSalary,
            WorkDays = workdays,

            UserId = user.Id,
            User = user,
            TotalSalary = (decimal)(workdays * 100 * coefficientsSalary)
        };
        Add(salary);
        return salary;
    }
}