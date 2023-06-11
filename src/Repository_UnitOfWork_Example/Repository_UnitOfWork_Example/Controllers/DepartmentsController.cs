using Microsoft.AspNetCore.Mvc;
using Repository_UnitOfWork_Example.Services;

namespace Repository_UnitOfWork_Example.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly DepartmentService _departmentService;


    public DepartmentsController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await _departmentService.AddAllEntitiesAsync();
        return Ok();
    }
}