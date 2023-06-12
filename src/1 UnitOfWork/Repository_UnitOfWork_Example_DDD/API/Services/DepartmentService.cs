using Domain.Departments;
using Domain.Interfaces;
using Domain.Salaries;
using Domain.Users;

namespace API.Services;

public class DepartmentService
{
    private readonly IDepartmentRepository _department;
    private readonly ISalaryRepository _salary;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _user;

    public DepartmentService(IUnitOfWork unitOfWork,
        IDepartmentRepository department,
        IUserRepository user,
        ISalaryRepository salary)
    {
        _unitOfWork = unitOfWork;
        _department = department;
        _user = user;
        _salary = salary;
    }

    public async Task<bool> AddAllEntitiesAsync()
    {
        // create new Department
        var departmentName = $"department_{Guid.NewGuid():N}";
        var department = _department.AddDepartment(departmentName);

        // create new User with above Department
        var userName = $"user_{Guid.NewGuid():N}";
        var userEmail = $"{Guid.NewGuid():N}@gmail.com";
        var user = _user.NewUser(userName, userEmail, department);

        // create new Salary with above User
        float coefficientsSalary = new Random().Next(1, 15);
        float workdays = 22;
        var salary = _salary.AddUserSalary(user, coefficientsSalary, workdays);

        // Commit all changes with one single commit
        var saved = await _unitOfWork.CommitAsync();

        return saved > 0;
    }
}