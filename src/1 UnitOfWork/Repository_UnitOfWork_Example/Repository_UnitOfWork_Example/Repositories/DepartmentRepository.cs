using Repository_UnitOfWork_Example.Data;
using Repository_UnitOfWork_Example.Entities.Models;
using Repository_UnitOfWork_Example.IRepositories;

namespace Repository_UnitOfWork_Example.Repositories;

internal class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public Department AddDepartment(string departmentName)
    {
        var department = new Department
        {
            DepartmentName = departmentName
        };
        Add(department);

        return department;
    }
}