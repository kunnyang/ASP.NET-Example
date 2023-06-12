namespace Domain.Departments;

public partial class Department
{
    public Department(string? departmentName)
    {
        DepartmentName = departmentName;
    }

    public bool ValidOnAdd()
    {
        return !string.IsNullOrWhiteSpace(DepartmentName);
    }
}