using Repository_UnitOfWork_Example.IRepositories;

namespace Repository_UnitOfWork_Example.Services;

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
        var addDepartment = _department.AddDepartment($"{Guid.NewGuid():N}");

        var addUser = _user
            .AddUser($"{Guid.NewGuid()}:N", $"{Guid.NewGuid():N}@gmail.com", addDepartment);
        var coefficientsSalary = new Random().Next(1, 15);
        const float workdays = 22;

        _salary.AddSalary(addUser, coefficientsSalary, workdays);

        return await _unitOfWork.CommitAsync() > 0;
    }
}