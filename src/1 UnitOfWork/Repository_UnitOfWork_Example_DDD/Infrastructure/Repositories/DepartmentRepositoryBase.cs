using Domain.Departments;

namespace Infrastructure.Repositories;

public class DepartmentRepositoryBase : RepositoryBase<Department>, IDepartmentRepository
{
    public DepartmentRepositoryBase(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public Department AddDepartment(string departmentName)
    {
        var department = new Department(departmentName);
        Add(department);
        return department;
    }
}