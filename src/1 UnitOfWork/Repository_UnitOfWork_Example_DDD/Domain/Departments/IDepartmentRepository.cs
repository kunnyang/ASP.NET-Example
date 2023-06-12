namespace Domain.Departments;

public interface IDepartmentRepository
{
    Department AddDepartment(string departmentName);
}