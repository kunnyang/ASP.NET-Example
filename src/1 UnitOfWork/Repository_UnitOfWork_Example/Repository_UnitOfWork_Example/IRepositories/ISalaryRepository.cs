using Repository_UnitOfWork_Example.Entities.Models;

namespace Repository_UnitOfWork_Example.IRepositories;

public interface ISalaryRepository /*: IRepository<Salary>*/
{
    Salary AddSalary(User user,
        float coefficientsSalary,
        float workdays);
}