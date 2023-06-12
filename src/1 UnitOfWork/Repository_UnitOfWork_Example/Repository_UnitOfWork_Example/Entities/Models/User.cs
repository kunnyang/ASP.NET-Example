using System.ComponentModel.DataAnnotations;
using Repository_UnitOfWork_Example.Entities.Delete;

namespace Repository_UnitOfWork_Example.Entities.Models;

public class User : DeleteEntity<int>
{
    public string UserName { get; set; } = null!;

    [EmailAddress]
    public string? Email { get; set; }

    public short DepartmentId { get; set; }

    /*[ForeignKey(nameof(DepartmentId))] */
    public virtual Department? Department { get; set; }

    public virtual ICollection<Salary>? Salaries { get; set; }
}