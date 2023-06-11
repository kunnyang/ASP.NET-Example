using Repository_UnitOfWork_Example.Entities.Models;

namespace Repository_UnitOfWork_Example.IRepositories;

public interface IDepartmentRepository : IRepository<Department>
{
    Department AddDepartment(string departmentName);
}